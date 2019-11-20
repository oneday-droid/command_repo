using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    class FacultyTableDesc : BaseTableDesc
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
    

}
