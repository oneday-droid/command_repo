using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public class UniversityTableStruct : BaseTableStruct
    {
        public UniversityTableStruct() : base("Universities")
        {
            //base.AddCol("ID", Type.GetType("System.Int32"));
            base.AddCol("University name", Type.GetType("System.String"));
            base.AddCol("City", Type.GetType("System.String"));
            base.AddCol("Year of foundation", Type.GetType("System.Int32"));
        }

        public override void AddCol(string colName, Type colType)   //запрещает добавление новых элементов
        {
        }
    }

}
