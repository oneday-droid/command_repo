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
        void SendRequest(string requestName, int startIndex, int endIndex, List<object> reqParams);          //реализует отправку запроса в бд

        string GetRequestResultTableName();
        List<string> GetRequestResultColNames();
        TableValuesLine GetRequestResultLine(int index);                                                         //реализует получение строки результата по индексу
        void SQLLineAdd(TableValuesLine lineToAdd);                                                              //реализует добавление строки в бд
        void SQLLineEdit(TableValuesLine lineToEdit, TableValuesLine newState);                                  //реализует изменение строки в бд
        void SQLLineDelete(TableValuesLine lineToDelete);                                                        //реализует удаление строки из бд

        void SaveAs(string filename);
    }

    abstract class BasePresenter
    {
        protected IView view;

        public void AttachView(IView view)
        {
            this.view = view;
        }
    }
}
