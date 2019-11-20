using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    class StudentTableDesc : BaseTableDesc
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
}
