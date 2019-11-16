using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public interface ITableDesc                                 //интерфейс класса, описывающего таблицу данных (имя таблицы данных, имена колонок их типы)
    {
        string      GetTableName();                             //возвращаем имя таблицы данных
        void        Add(string name, Type type);                //добавляет колонку name с типом type
        Type        GetColType(int index);                      //возвращает тип колонки с индексом index
        int         GetColsCount();                             //число столбцов таблицы
        List<string> GetColNames();                             //возвращает лист названий столбцов
        string      GetColNameByIndex(int index);               //возвращает название столбца по индексу
    }
}
