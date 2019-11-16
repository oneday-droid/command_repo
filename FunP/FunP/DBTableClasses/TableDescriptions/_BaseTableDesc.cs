using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    class BaseTableDesc : ITableDesc
    {
        protected string tableName = "Default";
        protected List<ColDescPair> colNames = new List<ColDescPair>();

        public BaseTableDesc(string tableName)
        {
            if( !string.IsNullOrEmpty(tableName) )
            {
                this.tableName = tableName;
            }            
        }

        public string GetTableName()
        {
            return tableName;
        }
        public virtual void Add(string name, Type type)
        {
            colNames.Add(new ColDescPair(name, type));
        }
        public Type GetColType(int index)
        {
            return colNames[index].Type;
        }

        public int GetColsCount()
        {
            return colNames.Count;
        }

        public List<string> GetColNames()
        {
            var result = new List<string>();
            foreach (var col in colNames)
            {
                result.Add(col.Name);
            }

            return result;
        }

        public string GetColNameByIndex(int index)
        {
            return colNames[index].Name;
        }
    }
}
