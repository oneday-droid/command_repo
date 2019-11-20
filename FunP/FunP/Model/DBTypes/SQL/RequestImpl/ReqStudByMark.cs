using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace FunP
{

    public class ReqStudByMark : IDBRequest
    {
        public ITable SendRequest(List<object> reqParams)
        {
            Table result = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //реализация запроса в базу данных
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var cmd = new SqlCommand();

                cmd.CommandText = "SELECT Students.Name, Faculties.Name FROM Students INNER JOIN Faculties ON Faculties.ID = Students.FacultyID AND Faculties.Name LIKE 'Aero'";
                cmd.Connection = connection;
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (result == null)
                        {
                            var tableDesc = new BaseTableDesc("Default");

                            for (int i = 0; i < reader.FieldCount; i++)
                            {

                                var name = reader.GetName(i);
                                var type = reader[i].GetType();

                                tableDesc.Add(name, type);
                            }

                            result = new Table(tableDesc);
                        }

                        var valuesLine = new TableValuesLine();

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            valuesLine.Add(reader[i]);
                        }

                        result.AddLine(valuesLine);
                    }
                }

            }

            return result;
        }
    }

}