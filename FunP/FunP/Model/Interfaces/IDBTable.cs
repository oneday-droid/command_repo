using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public interface IDBTable                                  //предоставляет базовые возможности работы с элементами базы данных (включая хранение описаний таблиц для работы с ними)
    {

        bool LineAdd(TableValuesLine lineToAdd);                                         //добавляет текущую строку в базу
        bool LineEdit(TableValuesLine lineToEdit, TableValuesLine newState);             //ищет текущую строку в базе и заменяет ее на newState
        bool LineDelete(TableValuesLine lineToDelete);                                   //удаляет текущую строку из базы
    }
}
