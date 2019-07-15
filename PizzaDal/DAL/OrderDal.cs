using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDal.DAL
{
    public class OrderDal : IDAL
    {
        string _connectionString;
        public OrderDal(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Updae()
        {
            throw new NotImplementedException();
        }

        public DataTable LoadPizzaType()
        {
            DataTable dt = null;
            var pizzaTypeDataSet = GetDataSet("select * from PizzaType");
            if (pizzaTypeDataSet != null && pizzaTypeDataSet.Tables.Count > 0)
            {
                dt = pizzaTypeDataSet.Tables[0];
            }
            return dt;
        }

        public DataTable LoadPizzaSize()
        {
            DataTable dt = null;
            var pizzaSizeDataSet = GetDataSet("select * from PizzaSize");
            if (pizzaSizeDataSet != null && pizzaSizeDataSet.Tables.Count > 0)
            {
                dt = pizzaSizeDataSet.Tables[0];
            }
            return dt;
        }

        private DataSet GetDataSet(string sqlCommand)
        {
            DataSet ds = null;
            SqlConnection con = new SqlConnection(_connectionString);
            try
            {
                SqlCommand comm = new SqlCommand(sqlCommand, con);
                SqlDataAdapter daa = new SqlDataAdapter(comm);
                ds = new DataSet();
                daa.Fill(ds);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return ds;
        }
    }
}
