using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    class SQLWork : ISQLWork                                                    //модель работы со сложными запросами
    {
        private Dictionary<string, ISQLRequest> requests = new Dictionary<string, ISQLRequest>();

        private string          lastRequestName;                                //ключ запроса
        private ITable          lastRequestResult;                                    //хранит данные последнего запроса
        private List<object>    lastRequestParams;                              //хранит параметры последнего запроса

        public List<string> GetRequestNames()
        {
            if(requests.Count <= 0)
            {
                throw new InvalidOperationException("Отсутствуют запросы");
            }
            var result = new List<string>();

            foreach(KeyValuePair<string, ISQLRequest> dicPair in requests)
            {
                result.Add(dicPair.Key);
            }

            return result;
        }
        public ITable GetDataFromBase(string requestName, int startIndex, int endIndex, List<object> reqParams)
        {
            if (reqParams != lastRequestParams || lastRequestName != requestName)                                        
            {
                //если запрос не совпадает, выполняется новый запрос
                lastRequestResult = requests[requestName].SendRequest(reqParams);    //выполнить новый запрос
                lastRequestParams = reqParams;                                       //сохранить параметры запроса
                lastRequestName = requestName;
            }

            ////проверка диапазонов на валидность индексов
            //if (startIndex >= lastRequest.Count || endIndex >= lastRequest.Count ||
            //    startIndex < 0 || endIndex < 0 || startIndex > endIndex)
            //{
            //    startIndex = 0;
            //    endIndex = lastRequest.Count - 1;
            //    //throw new ArgumentOutOfRangeException("Некорректные диапазоны строк запроса");
            //}

            ////формирование результирующей таблицы
            //var result = new List<ITableLine>();

            //for (int i = startIndex; i<= endIndex; i++)
            //{
            //    result.Add(lastRequest[i]);
            //}

            return lastRequestResult;
        }
        public TableValuesLine GetDataLine(int index)
        {
            return lastRequestResult[index];
        }
        public string GetRequestResultTableName()
        {
            return lastRequestResult.GetTableName();
        }
        public List<string> GetRequestResultColNames()
        {
            return lastRequestResult.GetColNames();
        }
        public void AddReqToSheet(string name, ISQLRequest request)
        {
            if( request == null)
            {
                throw new ArgumentNullException();
            }

            requests.Add(name, request);
        }

        public void DelReqFromSheet(string name)
        {
            requests.Remove(name);
        }
    }
}
