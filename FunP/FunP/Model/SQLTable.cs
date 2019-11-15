using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace FunP
{
    class SQLTable : ISQLTable
    {
        public bool SQLLineAdd(ITableLine lineToAdd)
        //добавить в таблицу lineToAdd.tableName текущую структуру dataPairs (через поля)
        {
            bool result = false;
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            IFormatProvider format = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            
            var tableName = lineToAdd.GetTableName();
            var colNames = lineToAdd.GetColumnNames();
            var count = colNames.Count;

            //реализация запроса в базу данных
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO ";

                if (tableName == "Students" || tableName == "Faculties" || tableName == "Universities")
                {
                    cmd.CommandText += tableName;
                    cmd.CommandText += string.Format(" VALUES (");

                    for (var i=1; i< count;i++)
                    {
                        if (i > 1 )
                            cmd.CommandText += ", ";

                        object value;
                        var type = lineToAdd.GetValueType(i);
                        if (type == typeof(double))
                        {
                            value = ((double)lineToAdd.GetValue(i)).ToString(format);
                            cmd.CommandText += string.Format("{0}", value);
                        }
                        else if (type == typeof(string))
                        {
                            value = lineToAdd.GetValue(i).ToString();
                            cmd.CommandText += string.Format("'{0}'", value);
                        }
                        else 
                        {
                            value = lineToAdd.GetValue(i).ToString();
                            cmd.CommandText += string.Format("{0}", value);
                        }
                    }

                    cmd.CommandText += ")";

                    if (cmd.ExecuteNonQuery() > 0)
                        result = true;
                }
                else
                {
                    //do nothing
                }
            }

            return result;
        }
        public bool SQLLineEdit(ITableLine lineToEdit, ITableLine newState)
        {
            if (lineToEdit.GetSize() != newState.GetSize() || lineToEdit.GetTableName() != newState.GetTableName())      //если размер строк или имена таблицы не совпадают, не редактировать (некорректный параметр)
            {
                throw new ArgumentException("Входные параметры должны быть одного табличного типа");
                //return false;
            }

            bool result = false;
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            IFormatProvider format = System.Globalization.CultureInfo.GetCultureInfo("en-US");

            var tableName = newState.GetTableName();
            var colNames = newState.GetColumnNames();
            var count = colNames.Count;

            //реализация запроса в базу данных
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE ";

                if (tableName == "Students" || tableName == "Faculties" || tableName == "Universities")
                {
                    cmd.CommandText += tableName;
                    cmd.CommandText += string.Format(" SET ");

                    for (var i = 1; i < count; i++)
                    {
                        if (i > 1)
                            cmd.CommandText += ", ";

                        object value;
                        var type = newState.GetValueType(i);

                        if (type == typeof(double))
                        {
                            value = ((double)newState.GetValue(i)).ToString(format);
                            cmd.CommandText += string.Format("{0}={1}", colNames[i], value);
                        }
                        else if (type == typeof(string))
                        {
                            value = newState.GetValue(i).ToString();
                            cmd.CommandText += string.Format("{0}='{1}'", colNames[i], value);
                        }
                        else
                        {
                            value = newState.GetValue(i).ToString();
                            cmd.CommandText += string.Format("{0}={1}", colNames[i], value);
                        }
                    }

                    cmd.CommandText += string.Format(" WHERE {0}={1}", colNames[0], lineToEdit.GetValue(0));

                    if (cmd.ExecuteNonQuery() > 0)
                        result = true;
                }
                else
                {
                    //do nothing
                }

            }

            return result;
        }
        public bool SQLLineDelete(ITableLine lineToDelete)
        {
            bool result = false;
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            var tableName = lineToDelete.GetTableName();
            var colNames = lineToDelete.GetColumnNames();

            //реализация запроса в базу данных
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "DELETE FROM ";

                if (tableName == "Students" || tableName == "Faculties" || tableName == "Universities")
                {
                    cmd.CommandText += tableName;
                    cmd.CommandText += string.Format(" WHERE {0}={1}", colNames[0], lineToDelete.GetValue(0));

                    if (cmd.ExecuteNonQuery() > 0)
                        result = true;
                }
                else
                {
                    //do nothing
                }
            }

            return result;
        }
    }
}
