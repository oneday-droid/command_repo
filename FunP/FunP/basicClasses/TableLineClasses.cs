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
            base.tableName = "University";
        }

        protected override void InitDataPairs()
        {
            base.dataPairs.Add(new Pair("Название", ""));
            base.dataPairs.Add(new Pair("Город", ""));
            base.dataPairs.Add(new Pair("Год основания", ""));
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
            base.tableName = "Faculty";
        }

        protected override void InitDataPairs()
        {
            base.dataPairs.Add(new Pair("Название", ""));
            base.dataPairs.Add(new Pair("Декан", ""));
            base.dataPairs.Add(new Pair("Университет", ""));
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
            base.tableName = "Student";
        }

        protected override void InitDataPairs()
        {
            base.dataPairs.Add(new Pair("Фамилия", ""));
            base.dataPairs.Add(new Pair("Имя", ""));
            base.dataPairs.Add(new Pair("Отчество", ""));
            base.dataPairs.Add(new Pair("Возраст", ""));
            base.dataPairs.Add(new Pair("Факультет", ""));
            base.dataPairs.Add(new Pair("Средний балл", ""));
            base.dataPairs.Add(new Pair("Год поступления", ""));
        }
    }
}
