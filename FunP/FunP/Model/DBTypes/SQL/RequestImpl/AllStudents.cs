using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace FunP
{

    public class ReqStudents : IDBRequest                //имплементирует интерфейс запроса
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

}
