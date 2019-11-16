using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace FunP
{

    public class ReqStudByMark : ISQLRequest
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
                            var tableDesc = new TableDesc("Default");

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

    public class ReqStudents : ISQLRequest                //имплементирует интерфейс запроса
    {
        public ITable SendRequest(List<object> reqParams)
        {
            ITable result = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //реализация запроса в базу данных
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Students";
                cmd.Connection = connection;
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        if(result == null)
                            result = new Table(new StudentTableDesc());

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

    public class ReqFaculties : ISQLRequest                //имплементирует интерфейс запроса
    {
        public ITable SendRequest(List<object> reqParams)
        {
            ITable result = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //реализация запроса в базу данных
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Faculties";
                cmd.Connection = connection;
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        if (result == null)
                            result = new Table(new FacultyTableDesc());

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

    public class ReqUniversities : ISQLRequest                //имплементирует интерфейс запроса
    {
        public ITable SendRequest(List<object> reqParams)
        {
            ITable result = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //реализация запроса в базу данных
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Universities";
                cmd.Connection = connection;
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (result == null)
                            result = new Table(new UniversityTableDesc());

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
