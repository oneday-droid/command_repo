﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;

namespace FunP.Savers
{
    class PdfSaverImpl : ISaveToPdf
    {
        public bool SaveAs(ITable table, string filename)
        {
            
            return false;
        }

        string CreateText(ITable table)
        {
            string outputText = "";


            return outputText;
        }
    }
}
