﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FunP.Savers;

namespace FunP
{
    public class Presenter : IPresenter
    {
        private IDBWork sqlRequests;
        private IDBTable sqlBasicTableFunc;
        private ITableView view;

        public Presenter(IDBWork sqlRequests, IDBTable sqlBasicTableFunc, ITableView view)
        {
            this.sqlRequests = sqlRequests;
            this.sqlBasicTableFunc = sqlBasicTableFunc;
            this.view = view;
        }

        public List<string> GetRequestSheet()
        {
            return sqlRequests.GetRequestNames();
        }

        public void SendRequest(string requestName, int startIndex, int endIndex, List<object> reqParams)
        {
            var result = sqlRequests.GetDataFromBase(requestName, startIndex, endIndex, reqParams);

            view.OnRequestResults(result);
        }

        public TableValuesLine GetRequestResultLine(int index)
        {
            return sqlRequests.GetDataLine(index);
        }

        public List<string> GetRequestResultColNames()
        {
            return sqlRequests.GetRequestResultColNames();
        }

        public string GetRequestResultTableName()
        {
            return sqlRequests.GetRequestResultTableName();
        }

        public void SQLLineAdd(TableValuesLine lineToAdd)
        {
            if (true == sqlBasicTableFunc.LineAdd(lineToAdd) )
            {
                view.OnLineAdd(lineToAdd);
            }          
        }

        public void SQLLineEdit(TableValuesLine lineToEdit, TableValuesLine newState)
        {
            if (true == sqlBasicTableFunc.LineEdit(lineToEdit, newState) )
            {
                view.OnLineEdit(lineToEdit, newState);
            }
        }

        public void SQLLineDelete(TableValuesLine lineToDelete)
        {
            if( true == sqlBasicTableFunc.LineDelete(lineToDelete) )
            {
                view.OnLineDelete(lineToDelete);
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
