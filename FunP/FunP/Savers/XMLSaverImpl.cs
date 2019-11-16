using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FunP.Savers
{
    class XMLSaverImpl : ISave
    {
        public bool SaveAs(List<ITableLine> table, string filename)
        {
            System.IO.Directory.CreateDirectory((new System.IO.FileInfo(filename)).DirectoryName);

            string stringXml = CreateXML(table);
            if (stringXml.Length != 0)
                System.IO.File.WriteAllText(filename, stringXml);

            FileInfo fi = new FileInfo(filename);

            return fi.Exists;
        }

        string CreateXML(List<ITableLine> table)
        {
            string outputText = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n";

            string tableName = "";
            List<string> labels = null;
            for (int k = 0; k < table.Count; k++)
            {
                ITableLine line = table[k];
                if (tableName != line.GetTableName())
                {
                    if (tableName != "")
                        outputText += "</table>\r\n";

                    tableName = line.GetTableName();
                    outputText += String.Format("<table name=\"{0}\">", tableName);
                    labels = line.GetColumnNames();
                    outputText += "<row>\r\n";
                    foreach (string name in labels)
                        outputText += String.Format("<column>\"{0}\"</column>\r\n", name);
                    outputText += "</row>\r\n";
                }

                if (labels != null)
                {
                    outputText += "<row>\r\n";
                    foreach (string name in labels)
                        outputText += String.Format("<column>\"{0}\"</column>\r\n", line.GetValue(name));
                    outputText += "</row>\r\n";
                }
            }

            outputText += "</table>\r\n";

            return outputText;
        }
    }
}
