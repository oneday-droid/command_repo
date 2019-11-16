using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public interface ITable
    {
        TableValuesLine this[int index] { get; }
        bool            AddLine(TableValuesLine line);              //добавляет строку в таблицу. возвращает false, если количество или тип элементов line не соответствует внутренним
        string          GetTableName();                             //возвращаем имя таблицы данных
        object          GetData(int row, int col);                  //получаем элемент по индексам строки и столбца
        int             GetRowsCount();                             //число строк данных
        int             GetColsCount();                             //число столбцов таблицы
        List<string>    GetColNames();                              //возвращает лист названий столбцов
        string          GetColNameByIndex(int index);               //возвращает название столбца по индексу
    }

}
