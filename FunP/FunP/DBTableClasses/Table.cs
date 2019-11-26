using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    class Table : ITable
    {
        private List<TableValuesLine> data;
        BaseTableStruct TableStruct { public get; private set; }

        //конструктор задает стуктуру таблицы для создаваемого экземпляра
        public Table(BaseTableStruct tableStruct)
        {
            data = new List<TableValuesLine>();
            TableStruct = tableStruct;
        }

        //возвращает поле таблицы по индексам строки и столбца
        public TableValuesLine this[int index]
        {
            get { return data[index]; }
        }

        //возвращает число строк данных в таблице
        public int GetRowCount()
        {
            return data.Count;
        }

        //добавляет строку в таблицу. возвращает false, если line не соответствует стуктуре таблицы
        public bool AddLine(TableValuesLine line)
        {
            if (line.GetColCount() != TableStruct.GetColCount())
                return false;

            data.Add(line);

            return true;
        }
    }
}
