using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public class UniversityLine : TableLine             //реализует строку типизированной таблицы University с заранее определенными колонками
    {
        public UniversityLine() : base(null)
        {
        }

        protected override void InitTableName()
        {
            base.tableName = "Universities";
        }

        protected override void InitDataPairs()
        {
            base.dataPairs.Add(new Pair("ID", -1, Type.GetType("System.Int32")));
            base.dataPairs.Add(new Pair("Name", "", Type.GetType("System.String")));
            base.dataPairs.Add(new Pair("City", "", Type.GetType("System.String")));
            base.dataPairs.Add(new Pair("Year", -1, Type.GetType("System.Int32")));
        }
    }

    //===============================================================
    public class FacultyLine : TableLine            //реализует строку типизированной таблицы Faculty с заранее определенными колонками
    {
        public FacultyLine() : base(null)
        {
        }

        protected override void InitTableName()
        {
            base.tableName = "Faculties";
        }

        protected override void InitDataPairs()
        {
            base.dataPairs.Add(new Pair("ID", -1, Type.GetType("System.Int32")));
            base.dataPairs.Add(new Pair("UniversityID", -1, Type.GetType("System.Int32")));
            base.dataPairs.Add(new Pair("Name", "", Type.GetType("System.String")));
            base.dataPairs.Add(new Pair("Dean", "", Type.GetType("System.String")));
        }
    }

    //===============================================================

    public class StudentLine : TableLine            //реализует строку типизированной таблицы Student с заранее определенными колонками
    {
        public StudentLine() : base(null)
        {
 
        }

        protected override void InitTableName()
        {
            base.tableName = "Students";
        }

        protected override void InitDataPairs()
        {
            base.dataPairs.Add(new Pair("ID", -1, Type.GetType("System.Int32")));
            base.dataPairs.Add(new Pair("FacultyID", -1, Type.GetType("System.Int32")));
            base.dataPairs.Add(new Pair("Surname", "", Type.GetType("System.String")));
            base.dataPairs.Add(new Pair("Name", "", Type.GetType("System.String")));
            base.dataPairs.Add(new Pair("Patronymic", "", Type.GetType("System.String")));
            base.dataPairs.Add(new Pair("Age", -1, Type.GetType("System.Int32")));
            base.dataPairs.Add(new Pair("ReceiptYear", -1, Type.GetType("System.Int32")));
            base.dataPairs.Add(new Pair("AvgGrade", -1.0, Type.GetType("System.Double")));
        }
    }
}
