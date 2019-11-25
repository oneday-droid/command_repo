using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public class DBLineValidator
    {
        //проверяет строку значений на соответствие структуре таблицы
        public static bool CheckLineIsCorrectTableStruct(BaseTableStruct tableStruct, TableValuesLine line)
        {
            var lineColCount = line.GetColCount();
            var tableColCount = tableStruct.GetColCount();

            if (lineColCount != tableColCount)
                return false;

            for (int i = 0; i < lineColCount; i++)
            {
                if (line[i].GetType() != tableStruct.GetColType(i))
                    return false;
            }

            return true;
        }
    }
}
