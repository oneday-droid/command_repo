using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    class UniversityTableDesc : BaseTableDesc
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

}
