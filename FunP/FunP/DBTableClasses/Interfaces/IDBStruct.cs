using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public interface IDBStruct  //IDBTableInfo
    {
        BaseTableStruct this[string tableName] { get; }                 //свойство предоставляет доступ к описанию стуктуры таблицы с именем 
        void AddTableStruct(BaseTableStruct tableDesc);                 //добавляет описание таблицы в list
        List<string> GetDBTableNamesList();                             //возвращает list имен таблиц базы данных
    }

}
