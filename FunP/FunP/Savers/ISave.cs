using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public interface ISave 
    {
        bool SaveAs(List<ITableLine> table, string filename);
    }

    public interface ISaveToPdf : ISave
    {
        bool SaveAs(List<ITableLine> table, string filename);
    }

    public interface ISaveToXls : ISave
    {
        bool SaveAs(List<ITableLine> table, string filename);
    }
}
