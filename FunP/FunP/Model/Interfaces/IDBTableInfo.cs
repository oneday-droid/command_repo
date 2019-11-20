using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public interface IDBTableInfo
    {
        ITableDesc this[int index] { get; }
        void AddTableDesc(ITableDesc tableDesc);                                     //добавляет описание таблицы в list
        int GetTableDescCount();
        int CheckLine(TableValuesLine line);                            //проверяет входную строку на структурное соответствие одной из таблиц 

        //List<ColDescPair> SQLColsGet();                                                  //получает список колонок и типов
    }

}
