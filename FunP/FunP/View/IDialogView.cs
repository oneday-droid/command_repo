using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    interface IDialogView
    {
        void SetDataLabels(TableValuesLine tableLine, ITableDesc tableDesc);           //установка значений элементов формы

        TableValuesLine GetDataLabels();                         //получение результата с формы
    }
}
