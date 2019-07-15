using PizzaDal.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Configuration;

namespace PizzaDal.DAL
{
    public class UserDal : IDAL
    {
        User _user;
        public UserDal(User user)
        {
            _user = user;
        }

        public void Create()
        {            
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Pizzaconnection"].ToString());
            try
            {
                /* Because We will put all out values from our (UserRegistration.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
                SqlCommand cmd = new SqlCommand("SpAddUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", _user.Name);
                cmd.Parameters.AddWithValue("@Email", _user.Email);
                cmd.Parameters.AddWithValue("@Contact", _user.ContactNo);
                cmd.Parameters.AddWithValue("@Address", _user.Address);
                cmd.Parameters.AddWithValue("@Password", _user.Password);
                cmd.Parameters.AddWithValue("@ConfirmPassword", _user.ConfirmPassword);
                cmd.Parameters.AddWithValue("@UserLogin", _user.Email);
                //cmd.Parameters.AddWithValue("@UserLogin", "Admin@gmail.com");
                cmd.Parameters.AddWithValue("@Type_Id", 2);
                cmd.Parameters.AddWithValue("@CurrentPassword", _user.Password);
              

                con.Open();
                //cmd.
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                //return Result;
            }

            catch
            {
                
               // throw;
                con.Close();
            }
            
        }

        public void Delete()
        {
            throw new System.NotImplementedException();
        }

        public void Read()
        {
            throw new System.NotImplementedException();
        }

        public void Updae()
        {
            throw new System.NotImplementedException();
        }



    }
}
