using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public interface ISQLTable                                  //предоставляет базовые возможности работы с элементами базы данных (включая хранение описаний таблиц для работы с ними)
    {

        bool SQLLineAdd(TableValuesLine lineToAdd);                                         //добавляет текущую строку в базу
        bool SQLLineEdit(TableValuesLine lineToEdit, TableValuesLine newState);             //ищет текущую строку в базе и заменяет ее на newState
        bool SQLLineDelete(TableValuesLine lineToDelete);                                   //удаляет текущую строку из базы
    }

    public interface ISQLTableInfo
    {
        ITableDesc this[int index] { get; }
        void AddTableDesc(ITableDesc tableDesc);                                     //добавляет описание таблицы в list
        int GetTableDescCount();
        int CheckLine(TableValuesLine line);                            //проверяет входную строку на структурное соответствие одной из таблиц 

        //List<ColDescPair> SQLColsGet();                                                  //получает список колонок и типов
    }

}
