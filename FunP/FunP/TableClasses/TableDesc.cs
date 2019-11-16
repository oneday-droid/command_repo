using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    class StudentTableDesc : TableDesc
    {
        public StudentTableDesc() : base("Students")
        {
            base.colNames.Add(new ColDescPair("ID", Type.GetType("System.Int32")));
            base.colNames.Add(new ColDescPair("FacultyID", Type.GetType("System.Int32")));
            base.colNames.Add(new ColDescPair("Surname", Type.GetType("System.String")));
            base.colNames.Add(new ColDescPair("Name", Type.GetType("System.String")));
            base.colNames.Add(new ColDescPair("Patronymic", Type.GetType("System.String")));
            base.colNames.Add(new ColDescPair("Age", Type.GetType("System.Int32")));
            base.colNames.Add(new ColDescPair("ReceiptYear", Type.GetType("System.Int32")));
            base.colNames.Add(new ColDescPair("AvgGrade", Type.GetType("System.Double")));
        }
       
        public override void Add(string name, Type type)   //запрещает добавление новых элементов
        {
        }
    }
    class FacultyTableDesc : TableDesc
    {
        public FacultyTableDesc() : base("Faculties")
        {
            base.colNames.Add(new ColDescPair("ID", Type.GetType("System.Int32")));
            base.colNames.Add(new ColDescPair("UniversityID", Type.GetType("System.Int32")));
            base.colNames.Add(new ColDescPair("Name", Type.GetType("System.String")));
            base.colNames.Add(new ColDescPair("Dean", Type.GetType("System.String")));
        }

        public override void Add(string name, Type type)   //запрещает добавление новых элементов
        {
        }
    }
    class UniversityTableDesc : TableDesc
    {
        public UniversityTableDesc() : base("Universities")
        {
            base.colNames.Add(new ColDescPair("ID", Type.GetType("System.Int32")));
            base.colNames.Add(new ColDescPair("Name", Type.GetType("System.String")));
            base.colNames.Add(new ColDescPair("City", Type.GetType("System.String")));
            base.colNames.Add(new ColDescPair("Year", Type.GetType("System.Int32")));
        }

        public override void Add(string name, Type type)   //запрещает добавление новых элементов
        {
        }
    }

    class TableDesc : ITableDesc
    {
        protected string tableName = "Default";
        protected List<ColDescPair> colNames = new List<ColDescPair>();

        public TableDesc(string tableName)
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
