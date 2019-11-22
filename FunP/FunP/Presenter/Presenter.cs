using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (true == dbBasicFunc.LineAdd(tableStruct, line) )
            {
                view.OnLineAdd(line);
            }          
        }

        public void DBLineEdit(BaseTableStruct tableStruct, TableValuesLine lineToEdit, TableValuesLine newState)
        {
            if (true == dbBasicFunc.LineEdit(tableStruct, lineToEdit, newState) )
            {
                view.OnLineEdit(lineToEdit, newState);
            }
        }

        public void DBLineDelete(BaseTableStruct tableStruct, TableValuesLine lineToDelete)
        {
            if( true == dbBasicFunc.LineDelete(tableStruct, lineToDelete) )
            {
                view.OnLineDelete(lineToDelete);
            }
        }
    }
}
