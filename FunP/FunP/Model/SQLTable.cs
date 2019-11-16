using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace FunP
{
    //class SQLTableInfo : ISQLTableInfo
    //{
    //    private List<string>        namesOfSQLTables = new List<string>();

    //    private List<ITableDesc>    tableDescList = new List<ITableDesc>();            //список описаний таблиц базы

    //    //public SQLTableInfo()
    //    //{
    //    //    string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    //    //    using (var connection = new SqlConnection(connectionString))
    //    //    {
    //    //        connection.Open();

    //    //        var cmd = new SqlCommand();
    //    //        cmd.Connection = connection;
    //    //        cmd.CommandText = "SELECT * FROM sys.objects WHERE type in (N'U')";

    //    //        SqlDataReader reader = cmd.ExecuteReader();

    //    //        if (reader.HasRows)
    //    //        {
    //    //            while (reader.Read())
    //    //            {
    //    //                for (int i = 0; i < reader.FieldCount; i++)
    //    //                {
    //    //                    if (reader.GetName(i) == "Name")
    //    //                    {
    //    //                        namesOfSQLTables.Add(reader.GetString(i));
    //    //                    }
    //    //                }
    //    //            }
    //    //        }


    //    //    }
    //    //}

        

    //    //public List<ColDescPair> SQLColsGet(string tableName)
    //    //{
    //    //    var result = new List<ColDescPair>();

    //    //    string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

    //    //    using (var connection = new SqlConnection(connectionString))
    //    //    {
    //    //        connection.Open();

    //    //        var cmd = new SqlCommand();
    //    //        cmd.Connection = connection;
    //    //        cmd.CommandText = "SELECT TOP 1 FROM " + tableName;

    //    //        SqlDataReader reader = cmd.ExecuteReader();

    //    //        if (reader.HasRows)
    //    //        {
    //    //            if (reader.Read())
    //    //            {
    //    //                for (int i = 0; i < reader.FieldCount; i++)
    //    //                {
    //    //                    var name = reader.GetName(i);
    //    //                    var type = reader[i].GetType();

    //    //                    result.Add(new ColDescPair(name, type));
    //    //                }
    //    //            }
    //    //        }

    //    //        return result;
    //    //    }
    //    //}

    //}


    class SqlTableInfo : ISQLTableInfo
    {
        private List<ITableDesc> tableDescList = new List<ITableDesc>();            //список описаний таблиц базы

        public ITableDesc this[int index]
        {
            get { return tableDescList[index]; }
        }
        public void AddTableDesc(ITableDesc tableDesc)
        {
            tableDescList.Add(tableDesc);
        }
        public int GetTableDescCount()
        {
            return tableDescList.Count;
        }
        public int CheckLine(TableValuesLine line)
        {
            bool fEquals = false;
            int result = -1;
            int count = -1;

            foreach (var tableDesc in tableDescList)
            {
                count++;

                if (tableDesc.GetColsCount() == line.GetColCount())
                {
                    fEquals = true;

                    for (int i = 0; i < tableDesc.GetColsCount(); i++)
                    {
                        if (line[i].GetType() != tableDesc.GetColType(i))
                        {
                            fEquals = false;
                            break;
                        }
                    }
                }

                if (fEquals)        //прерывание обхода, если совпадение найдено
                {
                    result = count;
                    break;
                }
            }

            return result;
        }
    }

    class SQLTable : ISQLTable
    {
        ISQLTableInfo tableInfo;

        public SQLTable(ISQLTableInfo tableInfo)
        {
            this.tableInfo = tableInfo;
        }

        public bool SQLLineAdd(TableValuesLine lineToAdd)
        {
            var tableIndex = tableInfo.CheckLine(lineToAdd);

            if (tableIndex == -1)         //если строка не соответствует по структуре ни одному описанию таблицы, то безусловный выход из метода
                return false;

            bool result = false;
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            IFormatProvider format = System.Globalization.CultureInfo.GetCultureInfo("en-US");

            var tableName = tableInfo[tableIndex].GetTableName();
            var count = lineToAdd.GetColCount();

            //реализация запроса в базу данных
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = string.Format("INSERT INTO {0} VALUES (", tableName);

                for (var i = 1; i < count; i++)     //null col is ID
                {
                    if (i > 1)
                        cmd.CommandText += ", ";

                    object value = lineToAdd[i];
                    var type = value.GetType();

                    if (type == typeof(double))
                    {
                        value = ((double)value).ToString(format);
                        cmd.CommandText += string.Format("{0}", value);
                    }
                    else if (type == typeof(string))
                    {
                        value = value.ToString();
                        cmd.CommandText += string.Format("'{0}'", value);
                    }
                    else
                    {
                        value = value.ToString();
                        cmd.CommandText += string.Format("{0}", value);
                    }
                }

                cmd.CommandText += ")";

                if (cmd.ExecuteNonQuery() > 0)
                    result = true;
            }

            return result;
        }
        public bool SQLLineEdit(TableValuesLine lineToEdit, TableValuesLine newState)
        {
            var tableEdit = tableInfo.CheckLine(lineToEdit);
            var tableState = tableInfo.CheckLine(newState);

            if (tableEdit != tableState || tableEdit == -1 || tableState == -1)      //если структура строк не совпадает, не редактировать (некорректный параметр)
            {
                return false;
            }

            bool result = false;
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            IFormatProvider format = System.Globalization.CultureInfo.GetCultureInfo("en-US");

            var tableName = tableInfo[tableEdit].GetTableName();
            var colNames = tableInfo[tableEdit].GetColNames();
            var count = colNames.Count;

            //реализация запроса в базу данных
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = string.Format("UPDATE {0} SET ", tableName);

                for (var i = 1; i < count; i++)
                {
                    if (i > 1)
                        cmd.CommandText += ", ";

                    object value = newState[i];
                    var type = value.GetType();

                    if (type == typeof(double))
                    {
                        value = ((double)value).ToString(format);
                        cmd.CommandText += string.Format("{0}={1}", colNames[i], value);
                    }
                    else if (type == typeof(string))
                    {
                        value = value.ToString();
                        cmd.CommandText += string.Format("{0}='{1}'", colNames[i], value);
                    }
                    else
                    {
                        value = value.ToString();
                        cmd.CommandText += string.Format("{0}={1}", colNames[i], value);
                    }
                }

                cmd.CommandText += string.Format(" WHERE ID={1}", lineToEdit[0]);

                if (cmd.ExecuteNonQuery() > 0)
                    result = true;
            }

            return result;
        }
        public bool SQLLineDelete(TableValuesLine lineToDelete)
        {
            var tableDelete = tableInfo.CheckLine(lineToDelete);

            if (tableDelete == -1)      //если структура неизввестна, не удалять (некорректный параметр)
            {
                return false;
            }

            bool result = false;
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            var tableName = tableInfo[tableDelete].GetTableName();

            //реализация запроса в базу данных
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = string.Format("DELETE FROM {0} WHERE ID={1}", tableName, lineToDelete[0]);

                if (cmd.ExecuteNonQuery() > 0)
                    result = true;
            }

            return result;
        }
    }
}
