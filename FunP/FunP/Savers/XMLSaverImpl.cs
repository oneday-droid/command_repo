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
        public bool SaveAs(ITable table, string filename)
        {
            System.IO.Directory.CreateDirectory((new System.IO.FileInfo(filename)).DirectoryName);

            string stringXml = CreateXML(table);
            if (stringXml.Length != 0)
                System.IO.File.WriteAllText(filename, stringXml);

            FileInfo fi = new FileInfo(filename);

            return fi.Exists;
        }

        string CreateXML(ITable table)
        {
            string outputText = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n";

            string tableName = table.TableStruct.GetTableName();
            outputText += String.Format("<table name=\"{0}\">", tableName);

            List<string> labels = table.TableStruct.GetColNamesList();

            outputText += "<structure>\r\n";                     
            foreach (string colName in labels)
                outputText += String.Format("<column>\"{0}\"</column>\r\n", colName);
            outputText += "</structure>\r\n";            

            var rowCount = table.GetRowCount();
            var colCount = table.TableStruct.GetColCount();
            for (int i = 0; i < rowCount; i++)
            {
                outputText += "<row>\r\n";
                for (int j = 0; j < colCount; j++)
                    outputText += String.Format("<column>\"{0}\"</column>\r\n", table[i][j].ToString());
                outputText += "</row>\r\n";
            }

            outputText += "</table>\r\n";

            return outputText;
        }
    }
}
