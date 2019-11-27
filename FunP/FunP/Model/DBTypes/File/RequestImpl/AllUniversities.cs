using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace FunP
{

    public class FileReqUniversities : IDBRequest                //имплементирует интерфейс запроса
    {
        public ITable SendRequest(List<object> reqParams)
        {
            ITable result = null;

            var tableStruct = new UniversityTableStruct();
            var tableName = tableStruct.GetTableName();
            var filename = String.Format(".\\{0}.fdb", tableName);
            var fileData = DBFileReaderWriter.DeserializeFileToArray(filename);

            if (fileData == null)
                return result;

            result = new Table(tableStruct);

            var lineCount = fileData.Length;
            for (int i = 0; i < lineCount; i++)
            {
                result.AddLine(fileData[i]);
            }

            return result;
        }
    }
}
