using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FunP
{
    class DBFileReaderWriter
    {
        public static TableValuesLine[] DeserializeFileToArray(string fileName)
        {
            TableValuesLine[] serializedArray = null;

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read))
            {
                var formatter = new BinaryFormatter();

                try
                {
                    serializedArray = (TableValuesLine[])formatter.Deserialize(fs);
                }
                catch
                {
                    //TODO report some error
                }

            }

            return serializedArray;
        }

        public static void SerializeArrayToFile(string fileName, TableValuesLine[] array)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                var formatter = new BinaryFormatter();

                formatter.Serialize(fs, array);
            }
        }
    }
}
