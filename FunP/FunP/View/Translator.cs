using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP.View
{
    public class Translator
    {
        public static string GetLangName(LanguageType type)
        {
            string language = "unknown";

            switch (type)
            {
                case LanguageType.English: language = "en"; break;
                case LanguageType.Russian: language = "ru"; break;
            }

            return language;
        }
    }

    class ResponseString
    {
        public string code { get; set; }
        public string lang { get; set; }
        public string[] text { get; set; }
    }
}
