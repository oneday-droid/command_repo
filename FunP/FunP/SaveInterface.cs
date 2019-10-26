using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public interface ISaveToPdf
    {
        bool SaveToPdf(StringDataTable data);
    }

    public interface ISaveToXls
    {
        bool SaveToXls(StringDataTable data);
    }
}
