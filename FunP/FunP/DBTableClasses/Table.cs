using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    class Table : ITable
    {
        private ITableDesc tableDesc;
        private List<TableValuesLine> data = new List<TableValuesLine>();
        
        public Table(ITableDesc colsDesc)     
        {
            this.tableDesc = colsDesc;
        }
      
        public bool AddLine(TableValuesLine line)
        {
            if (line.GetColCount() != tableDesc.GetColsCount())
                return false;

            data.Add(line);

            return true;
        }

        public TableValuesLine this[int index]
        {
            get { return data[index]; }
        }

        public string GetTableName()
        {
            return tableDesc.GetTableName();
        }

        public object GetData(int row, int col)
        {
            return data[row][col];
        }

        public int GetRowsCount()
        {
            return data.Count;
        }

        public int GetColsCount()
        {
            return tableDesc.GetColsCount();
        }

        public List<string> GetColNames()
        {
            return tableDesc.GetColNames();
        }

        public string GetColNameByIndex(int index)
        {
            return tableDesc.GetColNameByIndex(index);
        }
    }
}
