using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public class BaseTableStruct
    {
        public const string IDColName = "ID";
        public static string DefaultTableName = "Default";

        protected string tableName;
        private List<string> colNames;
        private List<Type> colTypes;

        public BaseTableStruct(string tableName)
        {
            if (!string.IsNullOrEmpty(tableName))
                this.tableName = tableName;
            else
                this.tableName = DefaultTableName;

            colNames = new List<string>();
            colTypes = new List<Type>();

            colNames.Add(IDColName);
            colTypes.Add(Type.GetType("System.Int32"));
        }

        //возвращает имя таблицы данных
        public string GetTableName()
        {
            return tableName;
        }

        private bool CheckColNameIsExist(string colName)
        {
            foreach(var name in colNames)
            {
                if (name == colName)
                    return true;
            }

            return false;
        }

        //добавляет колонку colName с описанием ее типа colType
        public virtual void AddCol(string colName, Type colType)
        {
            if (colName == null || colType == null || string.IsNullOrEmpty(colName) )
                throw new ArgumentNullException();

            if (CheckColNameIsExist(colName))
                throw new ArgumentException("Столбец с именем {colName} уже присутствует в таблице {this.tableName}");

            colNames.Add(colName);
            colTypes.Add(colType);
        }

        //возвращает количество колонок таблицы
        public int GetColCount()
        {
            return colNames.Count;
        }

        //возвращает имя колонки с номером colNumber
        public string GetColName(int colNumber)
        {
            return colNames[colNumber];
        }

        //возвращает тип колонки с номером colNumber
        public Type GetColType(int colNumber)
        {
            return colTypes[colNumber];
        }

        //возвращает лист из имен всех колонок таблицы
        public List<string> GetColNamesList()
        {
            return colNames;
        }

        //возвращает лист из типов всех колонок таблицы
        public List<Type> GetColTypesList()
        {
            return colTypes;
        }

        
    }
}
