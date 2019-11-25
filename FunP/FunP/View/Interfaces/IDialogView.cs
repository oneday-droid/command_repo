using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    interface IDialogView
    {
        void SetDataLabels(TableValuesLine tableLine, BaseTableStruct tableStruct);           //установка значений элементов формы

        TableValuesLine GetDataLabels();                         //получение результата с формы
    }
}
