using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public interface IView
    {
        void SetPresenter(IPresenter presenter);                //устанавливает presenter
        void InitializeFields();                                //инициалирует начальные значения элементов формы

        //callback
        void OnRequestResults(List<ITableLine> table);           //выводит результат запроса в ListBox
        void OnLineAdd(ITableLine lineToAdd);                   //добавление новой строки в таблицу результатов, если таковая выведена

        void OnLineEdit(ITableLine lineToEdit, ITableLine newState);

        void OnLineDelete(ITableLine lineToDelete);
        void OnError(string message);
    }
}
