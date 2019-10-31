using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public interface ISQLWork                      //описывает интерфейс модели работы с запросами
    {
        List<string> GetRequestNames();             //возвращает список имен запросов
        List<ITableLine> GetDataFromBase(string requestName, int startIndex, int endIndex, List<Pair> paramPairs);        //реализует сложный запрос request с параметрами paramPairs и возвращает строки от beginLineNum до endLineNum включительно
        ITableLine GetDataLine(int index);
        void AddReqToSheet(string name, ISQLRequest request);
        void DelReqFromSheet(string name);
    }
}
