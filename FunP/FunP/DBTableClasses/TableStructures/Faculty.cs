using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public class FacultyTableStruct : BaseTableStruct
    {
        public FacultyTableStruct() : base("Faculties")
        {
            //base.AddCol("ID", Type.GetType("System.Int32"));
            base.AddCol("University ID", Type.GetType("System.Int32"));
            base.AddCol("Faculty name", Type.GetType("System.String"));
            base.AddCol("Dean", Type.GetType("System.String"));
        }

        public override void AddCol(string colName, Type colType)   //запрещает добавление новых элементов
        {
            //do nothing
        }
    }
    

}
