using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using PizzaDal.Models;
//using RegisterBal;



namespace PizzaDal.DAL
{
    public class RegisterDal : IDAL
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public string message = string.Empty;
        string _RegString;

        public RegisterDal(string RegString)
        {
            _RegString = RegString;
        }

        public RegisterDal()
        {
            // TODO: Complete member initialization

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

        public DataTable LoadRegister()
        {

            DataTable dt = null;
            var RegisterDataSet = SetDataSet("insert into Registration (name,Email,Contact,Address,Password,ConfirmPassword) values(@name,@Email,@ContactNo,@Address,@Password,@ConfirmPassword)");
            if (RegisterDataSet != null && RegisterDataSet.Tables.Count > 0)
            {
                dt = RegisterDataSet.Tables[0];
            }
            return dt;
        }

        public DataSet SetDataSet(string sqlCommand)
        {
            DataSet ds = null;
            SqlConnection con = new SqlConnection(_RegString);
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

        //public bool userDal(User user)
        //{
        //    SqlParameter[] parameters = new SqlParameter[]
        //{                
        //    new SqlParameter("@name", user.Name),
        //    new SqlParameter("@Email", user.Email),
        //    new SqlParameter("@ContactNo", user.ContactNo),
        //    new SqlParameter("@Address", user.Address),
        //    new SqlParameter("@Password", user.Password),
        //    new SqlParameter("@ConfirmPassword", user.ConfirmPassword),
			
        //};

        //    return SqlDBHelper.ExecuteNonQuery("Adduser", CommandType.StoredProcedure, parameters);
        //}


        public bool CheckEmail(string Email)
        {

            Boolean emailavailable = false;



            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@Email", Email) };


            //using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("CheckEmail", CommandType.StoredProcedure, parameters))
            //{
            //    //con.Open();
            //    //SqlDataReader idr = cmd.ExecuteReader();
            //    int res = cmd.ExecuteNonQuery();
            //    if (res==1)
            //    {
            //        emailavailable = true;

            //    }
            //    else
            //    {
            //        emailavailable = false;
            //    }
            //    //con.Close();



            //    return emailavailable;
            //}

            if (SqlDBHelper.ExecuteParamerizedSelectCommand("CheckEmail", CommandType.StoredProcedure, parameters) == 0)
            {
                emailavailable = false;
            }
            else 
            {
                emailavailable = true;
            }

            return emailavailable;




        }
    }







    //public string txtEmail { get; set; }




}





//public List<Email> CheckEmailId()
//{
//    List<EmailId> listRegistration = null;

//    using (DataTable table = SqlDBHelper.ExecuteSelectCommand("CheckEmail", CommandType.StoredProcedure))
//    {
//        //check if any record exist or not
//        if (table.Rows.Count > 0)
//        {
//            listRegistration = new List<EmailId>();
//            message = "Email allready exit";
//        }



//        return listRegistration;
//    }

//}

//public static string CheckEmail(string Email)
//        {
//            string conString = Registration.ConnectionStrings["sqlCon"].ConnectionString;
//            using (SqlConnection conn = new SqlConnection(conString))
//            {
//                using (SqlCommand cmd = new SqlCommand("CheckEmail", conn))
//                {
//                    cmd.CommandType = CommandType.StoredProcedure;
//                    cmd.Parameters.AddWithValue("@Email", Email);
//                    conn.Open();
//                    return (string)cmd.ExecuteScalar();
//                }
//            }
//        }



//SqlDataReader dr = SqlDBHelper.ExecuteReader();
//// check if any record exist or not
//if (table.Rows.Count == 1)
//{
//    DataRow row = table.Rows[0];



//    emailavailable = true;

//    //Email = new Registration();
//    // message = "Email allready exit";
//}

//        using (SqlConnection con = new SqlConnection(dc.Con)) {
//    using (SqlCommand cmd = new SqlCommand("sp_Add_contact", con)) {
//      cmd.CommandType = CommandType.StoredProcedure;

//      cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = txtFirstName.Text;
//      cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = txtLastName.Text;

//      con.Open();
//      cmd.ExecuteNonQuery();
//    }
//  }
//} 


//string constr = ConfigurationManager.ConnectionStrings["Pizzaconnection"].ToString(); // connection string
//SqlConnection con = new SqlConnection(constr);
//con.Open();
//{
//    cmd.CommandType = CommandType.StoredProcedure;
