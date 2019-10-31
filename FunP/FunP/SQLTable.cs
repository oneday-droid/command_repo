using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    class SQLTable : ISQLTable
    {
        public bool SQLLineAdd(ITableLine lineToAdd)
        {
            //пример доступа к значениям lineToAdd
            var colNames = lineToAdd.GetColumnNames();
            var count = colNames.Count;

            for(int i=0; i< count; i++)
            {
                var value = lineToAdd.GetValue(colNames[i]);    //получение элемента из строки

                //TODO добавление в БД?
            }


            //добавить в таблицу lineToAdd.tableName текущую структуру dataPairs (через поля)

            return true;
        }
        public bool SQLLineEdit(ITableLine lineToEdit, ITableLine newState)
        {
            if (lineToEdit.GetSize() != newState.GetSize() || lineToEdit.GetTableName() != newState.GetTableName())      //если размер строк или имена таблицы не совпадают, не редактировать (некорректный параметр)
            {
                throw new ArgumentException("Входные параметры должны быть одного табличного типа");
                //return false;
            }

            //найти в таблице lineToEdit.tableName структуру lineToEdit.dataPairs и заменить ее на newState.dataPairs

            return true;
        }
        public bool SQLLineDelete(ITableLine lineToDelete)
        {
            //найти в таблице lineToDelete.tableName структуру lineToDelete.dataPairs и удалить ее из таблицы


            return true;
        }
    }
}
