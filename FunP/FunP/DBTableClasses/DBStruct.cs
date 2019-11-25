using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace FunP
{
    public class DBStruct : IDBStruct    //DBTableInfo
    {
        private List<BaseTableStruct> bdTablesStructList;            //список структур всех таблиц базы

        public DBStruct()
        {
            bdTablesStructList = new List<BaseTableStruct>();
        }

        public BaseTableStruct this[string tableName]
        {
            get
            {
                BaseTableStruct result = null;

                foreach (var tableStruct in bdTablesStructList)
                {
                    if(tableName == tableStruct.GetTableName() )
                        return tableStruct;
                }

                if (result == null)
                    throw new ArgumentOutOfRangeException("Отсутствует таблица с именем {tableName}");

                return result;
            }
        }

        public void AddTableStruct(BaseTableStruct tableStruct)
        {
            bdTablesStructList.Add(tableStruct);
        }

        public List<string> GetDBTableNamesList()
        {
            var result = new List<string>();

            foreach(var tableStruct in bdTablesStructList)
            {
                result.Add(tableStruct.GetTableName());
            }

            return result;
        }
    }
}
