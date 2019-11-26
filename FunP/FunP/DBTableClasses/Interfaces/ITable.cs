using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public interface ITable
    {
        BaseTableStruct TableStruct { get; }                //свойство предоставляет доступ (чтение) к структуре таблицы, включая имя, число колонок, их тип
        TableValuesLine this[int index] { get; set; }            //свойство предоставляет доступ (чтение) поле таблицы по индексам строки и столбца
        int GetRowCount();                                 //возвращает число строк данных
        bool AddLine(TableValuesLine line);                 //добавляет строку в таблицу. возвращает false, если количество или тип элементов line не соответствует внутренним
        bool DeleteLine(TableValuesLine item);                               //удаляет строку из таблицы
    }
}
