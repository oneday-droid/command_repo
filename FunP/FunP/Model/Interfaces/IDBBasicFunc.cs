using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public interface IDBBasicFunc         //IDBTable                         //предоставляет базовые возможности работы с элементами базы данных (включая хранение описаний таблиц для работы с ними)
    {
        bool LineAdd(BaseTableStruct tableStruct, TableValuesLine line);                                      //добавляет строку line в таблицу базы, описанную tableStruct
        bool LineEdit(BaseTableStruct tableStruct, TableValuesLine lineToEdit, TableValuesLine newState);     //ищет текущую строку lineToEdit в таблице базы, описанной tableStruct, и заменяет ее на строку newState
        bool LineDelete(BaseTableStruct tableStruct, TableValuesLine line);                                   //удаляет текущую строку из базы
    }
}
