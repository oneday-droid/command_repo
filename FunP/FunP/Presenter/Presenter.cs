using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FunP.Savers;

namespace FunP
{
    public class Presenter
    {
        private IDBStruct dbStruct;
        private IDBRequestRepository dbRequestRepository;
        private IDBBasicFunc dbBasicFunc;
        private ITableView view;
        private ITable currentTable;

        public Presenter(ITableView view, IDBStruct dbStruct, IDBBasicFunc dbBasicFunc, IDBRequestRepository dbRequestRepository)
        {
            this.view = view;
            this.dbStruct = dbStruct;
            this.dbBasicFunc = dbBasicFunc;
            this.dbRequestRepository = dbRequestRepository;
        }
        public List<string> GetDBTableNames()
        {
            return dbStruct.GetDBTableNamesList();
        }

        public List<string> GetRequestSheet()
        {
            return dbRequestRepository.GetRequestNames();
        }

        public BaseTableStruct GetTableStructByName(string tableName)
        {
            return dbStruct[tableName];
        }

        public void SendRequest(string requestName, int startIndex, int endIndex, List<object> reqParams)
        {
            currentTable = dbRequestRepository.GetDataFromBase(requestName, startIndex, endIndex, reqParams);

            view.OnRequestResults(currentTable);
        }

        public TableValuesLine GetRequestResultLine(int index)
        {
            return dbRequestRepository.GetDataLine(index);
        }

        public List<string> GetRequestResultColNames()
        {
            return dbRequestRepository.GetRequestResultColNames();
        }

        public string GetRequestResultTableName()
        {
            return dbRequestRepository.GetRequestResultTableName();
        }

        public void DBLineAdd(BaseTableStruct tableStruct, TableValuesLine line)
        {
            if(true == DBLineValidator.CheckLineIsCorrectTableStruct(tableStruct, line))
            {
                if (true == dbBasicFunc.LineAdd(tableStruct, line))
                {
                    var repositotyBasicFunc = (IDBBasicFunc)dbRequestRepository;
                    repositotyBasicFunc.LineAdd(tableStruct, line);
                    view.OnLineAdd(line);
                }
                else 
                {
                    view.OnError("Update table error");
                }
            }
            else
            {
                view.OnError("Incorrect vale at row");
            }     
        }

        public void DBLineEdit(BaseTableStruct tableStruct, TableValuesLine lineToEdit, TableValuesLine newState)
        {
            if (true == DBLineValidator.CheckLineIsCorrectTableStruct(tableStruct, lineToEdit) &&
                true == DBLineValidator.CheckLineIsCorrectTableStruct(tableStruct, newState) )
            {
                if (true == dbBasicFunc.LineEdit(tableStruct, lineToEdit, newState))
                {
                    var repositotyBasicFunc = (IDBBasicFunc)dbRequestRepository;
                    repositotyBasicFunc.LineEdit(tableStruct, lineToEdit, newState);
                    view.OnLineEdit(lineToEdit, newState);
                }
                else
                {
                    view.OnError("Update table error");
                }
            }
            else
            {
                view.OnError("Incorrect vale at selected row");
            }
        }

        public void DBLineDelete(BaseTableStruct tableStruct, TableValuesLine lineToDelete)
        {
            if (true == DBLineValidator.CheckLineIsCorrectTableStruct(tableStruct, lineToDelete))
            {
                if (true == dbBasicFunc.LineDelete(tableStruct, lineToDelete))
                {
                    var repositotyBasicFunc = (IDBBasicFunc)dbRequestRepository;
                    repositotyBasicFunc.LineDelete(tableStruct, lineToDelete);
                    view.OnLineDelete(lineToDelete);
                }
                else
                {
                    view.OnError("Update table error");
                }
            }
            else
            {
                view.OnError("Incorrect vale at deleted row");
            }
        }

        public void SaveAs(string filename)
        {
            if (currentTable != null)
            {
                ISave saver = null;

                FileInfo fi = new FileInfo(filename);
                if (fi.Extension == ".xml")
                    saver = new XMLSaverImpl();

                if (saver != null)
                    saver.SaveAs(currentTable, filename);
                else
                    view.OnError(String.Format("Saving to *{0} not released yet", fi.Extension));
            }
            else
                view.OnError("No data to save");
        }
    }
}
