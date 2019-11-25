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
        private IView view;

        public Presenter(IView view, IDBStruct dbStruct, IDBBasicFunc dbBasicFunc, IDBRequestRepository dbRequestRepository)
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
            var result = dbRequestRepository.GetDataFromBase(requestName, startIndex, endIndex, reqParams);

            view.OnRequestResults(result);
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
                    view.OnLineAdd(line);
                }
                else { //report error
                }
            }
            else
            {
                //report error
            }     
        }

        public void DBLineEdit(BaseTableStruct tableStruct, TableValuesLine lineToEdit, TableValuesLine newState)
        {
            if (true == DBLineValidator.CheckLineIsCorrectTableStruct(tableStruct, lineToEdit) &&
                true == DBLineValidator.CheckLineIsCorrectTableStruct(tableStruct, newState) )
            {
                if (true == dbBasicFunc.LineEdit(tableStruct, lineToEdit, newState))
                {
                    view.OnLineEdit(lineToEdit, newState);
                }
                else
                { //report error
                }
            }
            else
            {
                //report error
            }
        }

        public void DBLineDelete(BaseTableStruct tableStruct, TableValuesLine lineToDelete)
        {
            if (true == DBLineValidator.CheckLineIsCorrectTableStruct(tableStruct, lineToDelete))
            {
                if (true == dbBasicFunc.LineDelete(tableStruct, lineToDelete))
                {
                    view.OnLineDelete(lineToDelete);
                }
                else
                { //report error
                }
            }
            else
            {
                //report error
            }
        }

        public void SaveAs(string filename)
        {
            //ISave saver = null;

            FileInfo fi = new FileInfo(filename);
            /*if (fi.Extension == ".xml")
                saver = new XMLSaverImpl();

            if (saver != null)
                saver.SaveAs(currentTable, filename);
            else*/
            view.OnError(String.Format("Saving to *{0} not released yet", fi.Extension));
        }
    }
}
