using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public class Presenter : IPresenter
    {
        private ISQLWork    sqlRequests;
        private ISQLTable   sqlBasicTableFunc;
        private IView       view;

        public Presenter(ISQLWork sqlRequests, ISQLTable sqlBasicTableFunc, IView view)
        {
            this.sqlRequests = sqlRequests;
            this.sqlBasicTableFunc = sqlBasicTableFunc;
            this.view = view;
        }

        public List<string> GetRequestSheet()
        {
            return sqlRequests.GetRequestNames();
        }

        public void         SendRequest(string requestName, int startIndex, int endIndex, List<Pair> paramPairs)
        {
            var result = sqlRequests.GetDataFromBase(requestName, startIndex, endIndex, paramPairs);

            view.OnRequestResults(result);
        }

        public ITableLine   GetRequestResultLine(int index)
        {
            return sqlRequests.GetDataLine(index);
        }

        public void SQLLineAdd(ITableLine lineToAdd)
        {
            if (true == sqlBasicTableFunc.SQLLineAdd(lineToAdd) )
            {
                view.OnLineAdd(lineToAdd);
            }          
        }

        public void SQLLineEdit(ITableLine lineToEdit, ITableLine newState)
        {
            if (true == sqlBasicTableFunc.SQLLineEdit(lineToEdit, newState) )
            {
                view.OnLineEdit(lineToEdit, newState);
            }
        }

        public void SQLLineDelete(ITableLine lineToDelete)
        {
            if( true == sqlBasicTableFunc.SQLLineDelete(lineToDelete) )
            {
                view.OnLineDelete(lineToDelete);
            }
        }
    }
}
