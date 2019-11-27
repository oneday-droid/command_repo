using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    class DBRequestRepository : IDBRequestRepository, IDBBasicFunc                                            //модель работы со сложными запросами
    {
        private Dictionary<string, IDBRequest> requests = new Dictionary<string, IDBRequest>();

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

            foreach(KeyValuePair<string, IDBRequest> dicPair in requests)
            {
                result.Add(dicPair.Key);
            }

            return result;
        }

        public bool LineAdd(BaseTableStruct tableStruct, TableValuesLine line)
        {
            var reqTableStruct = lastRequestResult.TableStruct;

            if (reqTableStruct.GetTableName() != tableStruct.GetTableName())
                return false;

            if( !DBLineValidator.CheckLineIsCorrectTableStruct(reqTableStruct, line) )
                return false;

            //simple add
            lastRequestResult.AddLine(line);

            return true;
        }

        public bool LineEdit(BaseTableStruct tableStruct, TableValuesLine lineToEdit, TableValuesLine newState)
        {
            var reqTableStruct = lastRequestResult.TableStruct;

            if (reqTableStruct.GetTableName() != tableStruct.GetTableName())
                return false;

            if (!DBLineValidator.CheckLineIsCorrectTableStruct(reqTableStruct, lineToEdit) ||
                !DBLineValidator.CheckLineIsCorrectTableStruct(reqTableStruct, newState))
                return false;

            //поиск столбца ID и извлечение значения
            int idIndex = 0;
            for (int i = 0; i < tableStruct.GetColCount(); i++)
            {
                if (tableStruct.GetColName(i) == BaseTableStruct.IDColName)
                {
                    idIndex = i;
                    break;
                }
            }

            //поиск строки в таблице с ID == lineToAddID
            for (int i = 0; i < reqTableStruct.GetColCount(); i++)
            {
                if( lastRequestResult[i][idIndex] == lineToEdit[idIndex])
                {
                    lastRequestResult[i] = newState;
                }
            }

            return true;
        }

        public bool LineDelete(BaseTableStruct tableStruct, TableValuesLine line)
        {
            return lastRequestResult.DeleteLine(line);
        }

        public ITable GetDataFromBase(string requestName, int startIndex, int endIndex, List<object> reqParams)
        {
            lastRequestResult = requests[requestName].SendRequest(reqParams);    //выполнить новый запрос
            lastRequestParams = reqParams;                                       //сохранить параметры запроса
            lastRequestName = requestName;

            return lastRequestResult;
        }
        public TableValuesLine GetDataLine(int index)
        {
            return lastRequestResult[index];
        }
        public string GetRequestResultTableName()
        {
            return lastRequestResult.TableStruct.GetTableName();
        }
        public List<string> GetRequestResultColNames()
        {
            return lastRequestResult.TableStruct.GetColNamesList();
        }
        public void AddReqToSheet(string name, IDBRequest request)
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
