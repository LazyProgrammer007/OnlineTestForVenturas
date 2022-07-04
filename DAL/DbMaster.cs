using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace DAL
{
    public class DbMaster
    {
        public SqlConnection GetConnection()
        {
            SqlConnection connection = null;
            try
            {
                string cs = WebConfigurationManager.ConnectionStrings["SqlServerDb"].ConnectionString;
                connection = new SqlConnection(cs);

                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                connection = null;
            }

            return connection;
        }

        public int ExecuteNonQuery(string spName, List<SqlParameter> param = null)
        {
            int rowAffected = 0;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    if (connection == null)
                        return 0;

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = spName;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();

                        if (param != null)
                            foreach (var item in param)
                            {
                                command.Parameters.Add(item);
                            }

                        rowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                return 0;
            }

            return rowAffected;
        }

        public DataTable GetDataTable(string spName, List<SqlParameter> param = null)
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    if (connection == null)
                        return null;

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = spName;
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Clear();

                        if (param != null)
                            foreach (var item in param)
                            {
                                command.Parameters.Add(item);
                            }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(table);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return table;
        }
    }
}
