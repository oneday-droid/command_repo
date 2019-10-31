using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    interface IDialogView
    {
        void SetDataLabels(ITableLine tableLine);           //установка значений элементов формы

        ITableLine GetDataLabels();                         //получение результата с формы
    }
}
