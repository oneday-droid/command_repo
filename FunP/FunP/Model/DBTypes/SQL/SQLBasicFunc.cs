using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace FunP
{
    class SQLBasicFunc : IDBBasicFunc
    {
        public bool LineAdd(BaseTableStruct tableStruct, TableValuesLine line)
        {
            // если строка не соответствует по структуре, то безусловный выход из метода
            if (false == tableStruct.CheckLineIsCorrectTableStruct(line))
                return false;

            bool result = false;
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            IFormatProvider format = System.Globalization.CultureInfo.GetCultureInfo("en-US");

            var tableName = tableStruct.GetTableName();
            var colCount = tableStruct.GetColCount();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = string.Format("INSERT INTO {0} VALUES (", tableName);

                bool firstParam = true;
                int tableIDIndex = -1;

                for (var i = 0; i < colCount; i++)     
                {
                    if ("ID" == tableStruct.GetColName(i))  //ID - автоинкрементное поле, заполняется автоматически базой
                    {
                        tableIDIndex = i;
                        continue;
                    }

                    if (firstParam)
                        firstParam = false;
                    else
                        cmd.CommandText += ", ";

                    object colValue = line[i];
                    var colType = tableStruct.GetColType(i);
                    string stringValue;

                    if (colType == typeof(double))
                    {
                        stringValue = ((double)colValue).ToString(format);
                        cmd.CommandText += string.Format("{0}", stringValue);
                    }
                    else if (colType == typeof(string))
                    {
                        stringValue = colValue.ToString();
                        cmd.CommandText += string.Format("'{0}'", stringValue);
                    }
                    else
                    {
                        stringValue = colValue.ToString();
                        cmd.CommandText += string.Format("{0}", stringValue);
                    }
                }

                cmd.CommandText += ")";

                if (cmd.ExecuteNonQuery() > 0)
                    result = true;
            }

            return result;
        }
        public bool LineEdit(BaseTableStruct tableStruct, TableValuesLine lineToEdit, TableValuesLine newState)
        {
            var isEditCorrect = tableStruct.CheckLineIsCorrectTableStruct(lineToEdit);
            var isNewStateCorrect = tableStruct.CheckLineIsCorrectTableStruct(newState);

            if (!isEditCorrect || !isNewStateCorrect)      //если структура строк не совпадает, не редактировать (некорректный параметр)
                return false;

            bool result = false;
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            IFormatProvider format = System.Globalization.CultureInfo.GetCultureInfo("en-US");

            var tableName = tableStruct.GetTableName();
            var colCount = tableStruct.GetColCount();

            //реализация запроса в базу данных
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = string.Format("UPDATE {0} SET ", tableName);

                bool firstParam = true;
                int tableIDIndex = -1;

                for (var i = 1; i < colCount; i++)     
                {
                    var colName = tableStruct.GetColName(i);

                    if ("ID" == colName)        //ID - автоинкрементное поле, заполняется автоматически базой
                    {
                        tableIDIndex = i;
                        continue;
                    }

                    if (firstParam)
                        firstParam = false;
                    else
                        cmd.CommandText += ", ";

                    object colValue = newState[i];
                    var colType = tableStruct.GetColType(i);
                    string stringValue;

                    if (colType == typeof(double))
                    {
                        stringValue = ((double)colValue).ToString(format);
                        cmd.CommandText += string.Format("{0}={1}", colName, stringValue);
                    }
                    else if (colType == typeof(string))
                    {
                        stringValue = colValue.ToString();
                        cmd.CommandText += string.Format("{0}='{1}'", colName, stringValue);
                    }
                    else
                    {
                        stringValue = colValue.ToString();
                        cmd.CommandText += string.Format("{0}={1}", colName, stringValue);
                    }
                }

                //TODO делать ли проверку на индекс, если в базовом baseTableStruct по-умолчанию колонка ID добавляется? если в BaseTableStruct не будет "ID", то этот код упадет
                cmd.CommandText += string.Format(" WHERE ID={0}", lineToEdit[tableIDIndex]);

                if (cmd.ExecuteNonQuery() > 0)
                    result = true;
            }

            return result;
        }
        public bool LineDelete(BaseTableStruct tableStruct, TableValuesLine line)
        {
            // если строка не соответствует по структуре, то безусловный выход из метода
            if (false == tableStruct.CheckLineIsCorrectTableStruct(line))
                return false;

            bool result = false;
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            var tableName = tableStruct.GetTableName();

            //реализация запроса в базу данных
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var cmd = new SqlCommand();
                cmd.Connection = connection;

                //TODO id по-умолчанию находится в 0 колонке, а если изменится структура BaseTableStruct, то код отработает неправильно
                cmd.CommandText = string.Format("DELETE FROM {0} WHERE ID={1}", tableName, line[0]);

                if (cmd.ExecuteNonQuery() > 0)
                    result = true;
            }

            return result;
        }
    }
}
