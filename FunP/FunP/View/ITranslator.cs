using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP.View
{
    public enum LanguageType
    {
        English = 0,
        Russian
    }

    public interface ITranslator
    {
        string Translate(string text, LanguageType lang);
    }
}
