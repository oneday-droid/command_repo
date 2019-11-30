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
                cmd.CommandText = $"INSERT INTO {tableName} VALUES ";
                cmd.CommandText += "(";

                string paramsToAdd = "";
                bool firstParam = true;

                for (int i=0; i< colCount; i++)
                {
                    var colName = tableStruct.GetColName(i);

                    if (colName == "ID")
                        continue;

                    var sqlParameterName = $"@Value{i}";        //var sqlParameterValue = $"[{colName}]";
                    var sqlParameter = new SqlParameter(sqlParameterName, line[i]);
                    cmd.Parameters.Add(sqlParameter);

                    if (firstParam)
                        firstParam = false;
                    else
                        paramsToAdd += ", ";

                    paramsToAdd += sqlParameterName;
                }

                cmd.CommandText += paramsToAdd;
                cmd.CommandText += ")";

                if (cmd.ExecuteNonQuery() > 0)
                    result = true;
            }

            return result;
        }
        public bool LineEdit(BaseTableStruct tableStruct, TableValuesLine lineToEdit, TableValuesLine newState)
        {
            bool result = false;
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            var tableName = tableStruct.GetTableName();
            var colCount = tableStruct.GetColCount();

            //реализация запроса в базу данных
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = $"UPDATE {tableName} SET ";

                bool firstParam = true;
                string idParam = "";
                string paramsToEdit = "";

                for (var i = 0; i < colCount; i++)     
                {
                    var colName = tableStruct.GetColName(i);

                    var sqlParameterName = $"@Value{i}";
                    var sqlParameter = new SqlParameter(sqlParameterName, newState[i]);
                    cmd.Parameters.Add(sqlParameter);
                    var pair = $"[{colName}]={sqlParameterName}";

                    if("ID" == colName)
                    {
                        idParam = pair;
                        continue;
                    }

                    if (firstParam)
                        firstParam = false;
                    else
                        paramsToEdit += ", ";

                    paramsToEdit += pair;
                }

                cmd.CommandText += paramsToEdit;
                //TODO делать ли проверку на индекс, если в базовом baseTableStruct по-умолчанию колонка ID добавляется? если в BaseTableStruct не будет "ID", то этот код упадет
                cmd.CommandText += $" WHERE {idParam}";

                if (cmd.ExecuteNonQuery() > 0)
                    result = true;
            }

            return result;
        }
        public bool LineDelete(BaseTableStruct tableStruct, TableValuesLine line)
        {
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
                cmd.CommandText = $"DELETE FROM {tableName} WHERE ID={line[0]}";

                if (cmd.ExecuteNonQuery() > 0)
                    result = true;
            }

            return result;
        }
    }
}
