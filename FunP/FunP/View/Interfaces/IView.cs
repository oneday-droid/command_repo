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
        void OnRequestResults(ITable table);           //выводит результат запроса в ListBox
        void OnLineAdd(TableValuesLine lineToAdd);                   //добавление новой строки в таблицу результатов, если таковая выведена

        void OnLineEdit(TableValuesLine lineToEdit, TableValuesLine newState);

        void OnLineDelete(TableValuesLine lineToDelete);
    }
}
