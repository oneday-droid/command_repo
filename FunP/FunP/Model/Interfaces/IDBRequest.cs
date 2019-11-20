using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public interface IDBRequest      //описывает шаблон сложного запроса к таблице с набором пар Pair параметров и возвращающую list элементов типа ITableLine
    {
        ITable SendRequest(List<object> reqParams);
    }
}
