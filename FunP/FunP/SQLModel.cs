using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public class Students : ITableData          //описывает класс работы с таблицей студентов
    {
        public bool AddLine(params string[] strings)
        {
            if (strings.Length != 7) //проверка количества значений на валидность
                return false;

            //sql Запрос
            
            return true;
        }
        public bool EditLine(int num, params string[] strings)
        {
            int nTableSize = 0;
            //get tablesize from sql

            if (strings.Length != 7 || num > nTableSize) //проверка количества значений на валидность + проверка num на валидность
                return false;

            //sql запрос

            return true;
        }

    }

    public class ReqStudByMark : IRequestable
    {
        public StringDataTable RequestData(params string[] strings)
        {
            return new StringDataTable();       //заглушка
        }
    }

    public class SQLModel
    {
        public Students students = new Students();

    }
}
