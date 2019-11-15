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
        public List<ITableLine> SendRequest(List<Pair> paramPairs)
        {
            var result = new List<ITableLine>();

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
                        var tableLine = new TableLine();
                        if (reader.FieldCount != tableLine.GetSize())
                            continue;

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            var name = reader.GetName(i);
                            object value = reader.GetValue(i);
                            tableLine.SetValue(name, value);
                        }

                        result.Add(tableLine);
                    }
                }

            }

            return result;
        }
    }

    public class ReqStudents : ISQLRequest                //имплементирует интерфейс запроса
    {
        public List<ITableLine> SendRequest(List<Pair> paramPairs)
        {
            var result = new List<ITableLine>();

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
                        var studentLine = new StudentLine();
                        if (reader.FieldCount != studentLine.GetSize())
                            continue;

                        for(int i=0; i< reader.FieldCount; i++)
                        {
                            var name = reader.GetName(i);
                            object value = reader.GetValue(i);
                            studentLine.SetValue(name, value);
                        }

                        result.Add(studentLine);
                    }
                }
        
            }

            return result;
        }
    }

    public class ReqFaculties : ISQLRequest                //имплементирует интерфейс запроса
    {
        public List<ITableLine> SendRequest(List<Pair> paramPairs)
        {
            var result = new List<ITableLine>();

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
                        var facultyLine = new FacultyLine();
                        if (reader.FieldCount != facultyLine.GetSize())
                            continue;

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            var name = reader.GetName(i);
                            object value = reader.GetValue(i);
                            facultyLine.SetValue(name, value);
                        }

                        result.Add(facultyLine);
                    }
                }

            }

            return result;
        }
    }

    public class ReqUniversities : ISQLRequest                //имплементирует интерфейс запроса
    {
        public List<ITableLine> SendRequest(List<Pair> paramPairs)
        {
            var result = new List<ITableLine>();

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
                        var universityLine = new UniversityLine();
                        if (reader.FieldCount != universityLine.GetSize())
                            continue;

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            var name = reader.GetName(i);
                            object value = reader.GetValue(i);
                            universityLine.SetValue(name, value);
                        }

                        result.Add(universityLine);
                    }
                }

            }

            return result;
        }
    }
}
