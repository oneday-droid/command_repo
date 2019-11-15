using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public interface ITableLine                         //интерфейс базовой табличной строки
    {
        string  GetTableName();                              //имя таблицы, которой принадлежит строка
        void    SetValue(string valueNameToSet, object value);                    //устанавливает полю с именем Pair.name значение Pair.value
        object  GetValue(string name);                  //возвращает значение поля с именем name
        object GetValue(int index);
        Type GetValueType(string name);                 //возвращает тип значения поля с именем name
        Type GetValueType(int index);                 //возвращает тип значения поля с именем name
        List<string> GetColumnNames();                  //возвращает список заголовков
        int     GetSize();                              //возвращает размер
    }

}
