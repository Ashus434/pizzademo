using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDal.DAL
{
    public class SqlDBHelper
    {
        const string CONNECTION_STRING = @"Data Source=VPCOG1040;Initial Catalog=Pizza;Integrated Security=True; uid=YourUserName; Password=yourpassword; ";

        // This function will be used to execute R(CRUD) operation of parameterless commands
        internal static DataTable ExecuteSelectCommand(string CommandName, CommandType cmdType)
        {
            DataTable table = null;
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            table = new DataTable();
                            da.Fill(table);
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
            }

            return table;
        }

        // This function will be used to execute R(CRUD) operation of parameterized commands
        /// <summary>
        /// Test Summary
        /// </summary>
        /// <param name="CommandName">a</param>
        /// <param name="cmdType">b</param>
        /// <param name="param">c</param>
        /// <returns>d</returns>
        public static int ExecuteParamerizedSelectCommand(string CommandName, CommandType cmdType, SqlParameter[] param)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand cmd = new SqlCommand(CommandName, con))
                {
                    cmd.CommandType = cmdType;
                    param[0].Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param[0].ParameterName, SqlDbType.NVarChar, 100).Value = param[0].SqlValue;
                    try
                    {
                        con.Open();
                        result = (int)cmd.ExecuteScalar();
                        con.Close();
                    }
                    catch (Exception ex)                        
                    {
                        throw ex;
                    }
                }
            }
            return result;
        }

        // This function will be used to execute CUD(CRUD) operation of parameterized commands
        internal static bool ExecuteNonQuery(string CommandName, CommandType cmdType, SqlParameter[] pars)
        {
            int result = 0;

            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;
                    cmd.Parameters.AddRange(pars);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        result = cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        throw;
                    }
                }
            }

            return (result > 0);
        }

        internal static SqlDataReader ExecuteReader()
        {
            throw new NotImplementedException();
        }
    }

}
