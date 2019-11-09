using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public interface IPresenter             //интерфейс презентера
    {
        List<string> GetRequestSheet();                                                                     //получает список названий запросов
        void SendRequest(string requestName, int startIndex, int endIndex, List<Pair> paramPairs);          //реализует отправку запроса в бд
        ITableLine GetRequestResultLine(int index);                                                         //реализует получение строки результата по индексу
        void SQLLineAdd(ITableLine lineToAdd);                                                              //реализует добавление строки в бд
        void SQLLineEdit(ITableLine lineToEdit, ITableLine newState);                                       //реализует изменение строки в бд
        void SQLLineDelete(ITableLine lineToDelete);                                                        //реализует удаление строки из бд

        void SaveAs(string filename);
    }
}
