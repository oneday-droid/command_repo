using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;
using System.Xml;
using System.IO;

namespace FunP.Savers
{
    class PrintToPdfSaverImpl : ISaveToPdf
    {
        public bool SaveAs(List<ITableLine> table, string filename)
        {
            System.IO.Directory.CreateDirectory((new System.IO.FileInfo(filename)).DirectoryName);

            string stringXml = CreateXML(table);
            //System.IO.File.WriteAllText(fileName + ".xml", stringXml);

            XslCompiledTransform xslt = new XslCompiledTransform();
            using (XmlReader xslReader = XmlReader.Create(new StringReader(new StreamReader("report.xsl").ReadToEnd())))
            {
                xslt.Load(xslReader);
            }

            using (TextReader tr = new StringReader(stringXml))
            {
                using (StreamWriter results = new StreamWriter(filename))
                {
                    using (XmlReader reader = XmlReader.Create(tr))
                    { 
                        xslt.Transform(reader, null, results);
                    }
                }
            }//*/

            return false;
        }

        string CreateXML(List<ITableLine> table)
        {
            string outputText = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n<main>\r\n";

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
                    foreach(string name in labels)
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

            outputText += "</table>\r\n</main>";

            return outputText;
        }
    }
}
