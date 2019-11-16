﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

using Newtonsoft.Json;

namespace FunP.View
{
    public class YandexTranslator : ITranslator
    {
        string Key = "trnsl.1.1.20191103T222643Z.0c6fd91e8e01b50f.6876629e7b9f9f6d19e27a232137641f5391a747";
        string Address = "https://translate.yandex.net/api/v1.5/tr.json/translate";

        public string Translate(string text, LanguageType lang)
        {
            if (text.Length != 0)
            {
                string language = Translator.GetLangName(lang);

                string stringRequest = String.Format("{0}?key={1}&text={2}&lang={3}&format=plain",
                                                     Address, Key, text, language);

                WebRequest request = WebRequest.Create(stringRequest);
                WebResponse response = request.GetResponse();

                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    string line;

                    if ((line = stream.ReadLine()) != null)
                    {
                        ResponseString responseString = JsonConvert.DeserializeObject<ResponseString>(line);
                        
                        text = "";

                        foreach (string str in responseString.text)
                        {
                            text += str;
                        }
                    }
                }

            }

            return text;
        }
    }
}