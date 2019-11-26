using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    interface IDialogView
    {
        void SetData(TableValuesLine tableLine, BaseTableStruct tableStruct);           //установка значений элементов формы

        TableValuesLine GetData();                         //получение результата с формы
    }
}
