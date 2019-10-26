using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public interface IRequestable          //описывает шаблон сложного запроса к таблице с набором параметров strings и возвращающую таблицу значений
    {
        StringDataTable RequestData(params string[] strings);       
    }
    public interface ITableData            //интерфейс работы с таблицей
    {
        bool AddLine(params string[] strings);         //добавляет строку параметров strings в таблицу table
        bool EditLine(int num, params string[] strings);        //изменяет строку номер num в таблице
    }
}
