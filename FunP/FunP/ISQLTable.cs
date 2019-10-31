using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public interface ISQLTable                                  //предоставляет базовые возможности работы с элементами базы данных
    {
        bool SQLLineAdd(ITableLine lineToAdd);                                      //добавляет текущую строку в базу
        bool SQLLineEdit(ITableLine lineToEdit, ITableLine newState);                  //ищет текущую строку в базе и заменяет ее на newState
        bool SQLLineDelete(ITableLine lineToDelete);                                   //удаляет текущую строку из базы
    }

}
