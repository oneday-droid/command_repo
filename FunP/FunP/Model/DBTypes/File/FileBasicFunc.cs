using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FunP
{
    

    class FileBasicFunc : IDBBasicFunc
    {
        public bool LineAdd(BaseTableStruct tableStruct, TableValuesLine line)
        {
            var tableName = tableStruct.GetTableName();
            var filename = $".\\{tableName}.fdb";
            var fileData = DBFileReaderWriter.DeserializeFileToArray(filename);
            int newLineID;

            if (fileData == null)
            {
                newLineID = 0;
                fileData = new TableValuesLine[0];
            }
            else
            {
                //TODO если ID будет не в 0 колонке, то этот код рухнет
                newLineID = (int)fileData[fileData.Length - 1][0] + 1;
            }

            //TODO если ID будет не в 0 колонке, то этот код перепишет не то значение
            line[0] = newLineID;

            Array.Resize(ref fileData, fileData.Length+1);
            fileData[fileData.Length - 1] = line;

            DBFileReaderWriter.SerializeArrayToFile(filename, fileData);

            return true;
        }

        public bool LineEdit(BaseTableStruct tableStruct, TableValuesLine lineToEdit, TableValuesLine newState)
        {
            var tableName = tableStruct.GetTableName();
            var filename = $".\\{tableName}.fdb";
            var fileData = DBFileReaderWriter.DeserializeFileToArray(filename);
            var lineCount = fileData.Length;

            if (fileData == null || lineCount <= 0)
                return false;

            //TODO если ID будет не в 0 колонке, то этот код перепишет не то значение
            var lineToEditID = lineToEdit[0];
            var result = false;
            for (int i=0; i< lineCount; i++)
            {
                var fileDataID = fileData[i][0];
                
                if (lineToEditID == fileDataID)
                {
                    //переписывает строку
                    fileData[i] = newState;
                    result = true;
                    break;
                }
            }
            //создание нового файла
            DBFileReaderWriter.SerializeArrayToFile(filename, fileData);

            return result;
        }

        public bool LineDelete(BaseTableStruct tableStruct, TableValuesLine line)
        {
            var tableName = tableStruct.GetTableName();
            var filename = $".\\{tableName}.fdb";
            var fileData = DBFileReaderWriter.DeserializeFileToArray(filename);
            var lineCount = fileData.Length;

            if (fileData == null || lineCount <= 0)
                return false;

            var lineToDeleteID = line[0];
            var result = false;
            for (int i = 0; i < lineCount; i++)
            {
                var fileDataID = fileData[i][0];

                if(lineToDeleteID == fileDataID)
                {
                    //сдвиг значений
                    for (int j = i; j < lineCount - 1; j++)
                        fileData[j] = fileData[j + 1];

                    Array.Resize(ref fileData, fileData.Length - 1);
                    result = true;
                    break;
                }
            }

            DBFileReaderWriter.SerializeArrayToFile(filename, fileData);

            return result;
        }
    }
}
