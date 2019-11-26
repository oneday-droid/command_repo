using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP.View
{
    public enum LanguageType
    {
        Russian = 0,
        English
    }

    public interface ITranslator
    {
        string Translate(string text, LanguageType lang);
    }
}
