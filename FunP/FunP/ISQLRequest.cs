using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public interface ISQLRequest      //описывает шаблон сложного запроса к таблице с набором пар Pair параметров и возвращающую list элементов типа ITableLine
    {
        List<ITableLine> SendRequest(List<Pair> paramPairs);
    }
}
