using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendence.dal
{
    public class DBcontext
    {
        private string? _connectionString;

        public DBcontext()
        {
            _connectionString = GetConnString();
        }

        public string GetConnString()
        {
            if (string.IsNullOrEmpty(_connectionString) == false)
            {
                return _connectionString;
            }
            IConfigurationBuilder builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsetting.json", optional: false, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();

            _connectionString = configuration["ConnectionString"];
            if (_connectionString == null) throw new Exception("Cannot read conn string from secrets");
            return _connectionString;
        }

        public DataTable MakeQuery(string sqlQuery)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataAdapter reader = new SqlDataAdapter(cmd))
                        {
                            reader.Fill(dt);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);  
                    }
                }
            }
            return dt;
        }

        public DataTable MakeQueryWithParameters(string queryStr, SqlParameter[] parameters)
        {
            DataTable output = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    try
                    {
                        conn.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(output);
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("An error occurred: " + ex.Message);
                        // Further error handling
                    }
                }
            }
            return output;
        }


        public int ExecuteNonQuery(string queryStr, SqlParameter[] parameters)
        {
            int affectedRows = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    try
                    {
                        conn.Open();
                        affectedRows = cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("An error occurred: " + ex.Message);
                        // Consider more detailed exception handling or logging
                    }
                }
            }
            return affectedRows;
        }

        public object ExecuteScalar(string query, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    connection.Open();
                    return command.ExecuteScalar();
                }
            }
        }

    }
}
