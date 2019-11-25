using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public class StudentTableStruct : BaseTableStruct
    {
        public StudentTableStruct() : base("Students")
        {
            //base.AddCol("ID", Type.GetType("System.Int32"));
            base.AddCol("Faculty ID", Type.GetType("System.Int32"));
            base.AddCol("Surname", Type.GetType("System.String"));
            base.AddCol("Name", Type.GetType("System.String"));
            base.AddCol("Middle name", Type.GetType("System.String"));
            base.AddCol("Age", Type.GetType("System.Int32"));
            base.AddCol("Receipts year", Type.GetType("System.Int32"));
            base.AddCol("Average mark", Type.GetType("System.Double"));
        }

        public override void AddCol(string colName, Type colType)   //запрещает добавление новых элементов
        {
        }
    }
}
