using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    class SQLWork : ISQLWork                                                    //модель работы с запросами
    {
        private Dictionary<string, ISQLRequest> requests = new Dictionary<string, ISQLRequest>();

        private string          lastRequestName;                                //ключ запроса
        private List<ITableLine> lastRequest;                                    //хранит данные последнего запроса
        private List<Pair>      lastPairs;                                      //хранит параметры последнего запроса

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
        public List<ITableLine> GetDataFromBase(string requestName, int startIndex, int endIndex, List<Pair> paramPairs)
        {
            if (paramPairs != lastPairs || lastRequestName != requestName)                                        
            {
                //если запрос не совпадает, выполняется новый запрос
                lastRequest = requests[requestName].SendRequest(paramPairs);    //выполнить новый запрос
                lastPairs   = paramPairs;                                       //сохранить параметры запроса
                lastRequestName = requestName;
            }

            //проверка диапазонов на валидность индексов
            if (startIndex >= lastRequest.Count || endIndex >= lastRequest.Count ||
                startIndex < 0 || endIndex < 0 || startIndex > endIndex)
            {
                startIndex = 0;
                endIndex = lastRequest.Count - 1;
                //throw new ArgumentOutOfRangeException("Некорректные диапазоны строк запроса");
            }

            //формирование результирующей таблицы
            var result = new List<ITableLine>();

            for (int i = startIndex; i<= endIndex; i++)
            {
                result.Add(lastRequest[i]);
            }

            return result;
        }
        public ITableLine GetDataLine(int index)
        {
            if(index < 0 || index >= lastRequest.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return lastRequest[index];
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
