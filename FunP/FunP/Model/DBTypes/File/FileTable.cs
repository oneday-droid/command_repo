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
    class FileTable : IDBTable
    {
        //стандартная длина байтового массива, хранящая представление числа - количества байт в сериализованной строке TableValuesLine
        //в данном случае, число байт в сериализованной строке хранится в int, а int представляется sizeof(int) байтами в памяти
        private const int SerializedBytesCountInByteFormat = sizeof(int);

        IDBTableInfo tableInfo;

        public FileTable(IDBTableInfo tableInfo)
        {
            this.tableInfo = tableInfo;
        }

        private byte[] SerializeLine(TableValuesLine line)
        {
            byte[] result;
            var formatter = new BinaryFormatter();

            using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, line);
                result = ms.GetBuffer();
            }

            return result;
        }

        private TableValuesLine DeserializeLine(byte[] data)
        {
            TableValuesLine result;
            var formatter = new BinaryFormatter();

            using (MemoryStream ms = new MemoryStream(data))
            {
                result = (TableValuesLine)formatter.Deserialize(ms);
            }

            return result;
        }

        private long WriteSerializedLineToPos(string fileName, long filePos, byte[] bytesToWrite)
        {
            long resultPos = filePos;

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                resultPos = fs.Seek(filePos, SeekOrigin.Begin);

                var lineLen = (int)bytesToWrite.Length;                //возвращает int SerializedBytesCountInByteFormat
                var lineLenInByteFormat = BitConverter.GetBytes(lineLen);
                fs.Write(lineLenInByteFormat, 0, SerializedBytesCountInByteFormat);       //записывает сериализованную 
                fs.Write(bytesToWrite, 0, lineLen);

                resultPos += SerializedBytesCountInByteFormat;      //смещение позиции на длину массива байт, хранящего представление числа - количества записываемых bytesToWrite байт
                resultPos += lineLen;                               //смещение позиции на количество записанных байт 
                resultPos = fs.Seek(0, SeekOrigin.Current); //сравнение
            }

            return resultPos;
        }

        private byte[] ReadSerializedLineFromPos(string fileName, long filePos, out long filePosAfterRead)
        {
            byte[] result = null;

            var dataLenInByteFormat = new byte[SerializedBytesCountInByteFormat];

            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                fs.Seek(filePos, SeekOrigin.Begin);

                if(fs.Read(dataLenInByteFormat, 0, SerializedBytesCountInByteFormat) != 0)      //читает длину записанной в файл сериализованной строки
                {
                    var dataLen = BitConverter.ToInt32(dataLenInByteFormat, 0);     //преобразует длину в int
                    result = new byte[dataLen];                                   //буфер чтения сериазилованной строки

                    if (dataLen != fs.Read(result, 0, dataLen))
                    {
                        result = null;              //если число прочитанных не равно, то возврат null
                    }
                }

                filePosAfterRead = fs.Seek(0, SeekOrigin.Current);
            }

            return result;
        }

        private List<byte[]> GetDataLinesBeforePos(long filePos)
        {
            var result = new List<byte[]>();

            return result;
        }

        public bool LineAdd(TableValuesLine lineToAdd)
        {
            var tableIndex = tableInfo.CheckLine(lineToAdd);

            if (tableIndex == -1)         //если строка не соответствует по структуре ни одному описанию таблицы, то безусловный выход из метода
                return false;

            var tableName = tableInfo[tableIndex].GetTableName();
            var filename = ".\\{tableName}.fdb";

            byte[] serializedLine = SerializeLine(lineToAdd);
            WriteSerializedLineToPos(filename, 0, serializedLine);

            return true;
        }
        public bool LineEdit(TableValuesLine lineToEdit, TableValuesLine newState)
        {
            var tableEdit = tableInfo.CheckLine(lineToEdit);
            var tableState = tableInfo.CheckLine(newState);

            if (tableEdit != tableState || tableEdit == -1 || tableState == -1)      //если структура строк не совпадает, не редактировать (некорректный параметр)
            {
                return false;
            }
       
            var tableName = tableInfo[tableEdit].GetTableName();
            var filename = ".\\{tableName}.fdb";

            //byte[]          serializedLine = SerializeLine(newState);       //сериализует строку, которую необходимо добавить

            long readFromPos = 0, posAfterRead = 0, filePosToEdit;
            bool editLineFinded = false;
            byte[] data = null;

            //var dataBefore = new List<byte[]>();
            //var dataAfter = new List<byte[]>();


            //надо либо вместо string использовать ограниченный char, чтобы длина сериализованных данных не изменялась (зря БД в string сделано)
            //либо читать весь файл и писать в новый.

            while ( (data = ReadSerializedLineFromPos(filename, readFromPos, out posAfterRead)) != null )
            {
                var deserializedLine = DeserializeLine(data);

                if(deserializedLine[0] == lineToEdit[0])        //0 объект (индекс) совпадает
                {
                    filePosToEdit = readFromPos;                //позиция перезаписи
                    editLineFinded = true;
                }
                else
                {
                    //if(!editLineFinded)
                    //{
                    //    dataBefore.Add(data);
                    //}
                    //else
                    //{
                    //    dataAfter.Add(data);
                    //}
                }

                readFromPos = posAfterRead;             //установка позиции для следующего чтения 
            }


            return true;
        }
        public bool LineDelete(TableValuesLine lineToDelete)
        {
            var tableDelete = tableInfo.CheckLine(lineToDelete);

            if (tableDelete == -1)      //если структура неизввестна, не удалять (некорректный параметр)
            {
                return false;
            }

            bool result = false;

            return result;
        }
    }
}
