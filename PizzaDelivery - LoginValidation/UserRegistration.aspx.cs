using PizzaBal.Actions;
using PizzaDal.Models;
using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;

namespace PizzaDelivery
{
    public partial class UserRegistration : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
           var user = new User();
            user.Name = txtName.Text;
            user.Email = txtEmail.Text;
            user.ContactNo = txtContactNo.Text;
            user.Address = txtAddress.Text;
            user.Password = txtPassword.Text;
            user.ConfirmPassword = txtCofirmPasssword.Text;

              
            var register = new RegisterBal(user);
            var dfd = register.Validate();
            if (dfd.IsValid)
            {
                register.SignUp();
            }
            else
            {
                lblError.Text = dfd.Message;
                lblError.Visible = true;
            }
            

          string constr = ConfigurationManager.ConnectionStrings["Pizzaconnection"].ToString(); // connection string
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string message = string.Empty;
            SqlCommand cmd = new SqlCommand("insert into Registration (name,Email,Contact,Address,Password,ConfirmPassword) values(@name,@Email,@ContactNo,@Address,@Password,@ConfirmPassword)", con);

            cmd.Parameters.AddWithValue("Name", txtName.Text);
            cmd.Parameters.AddWithValue("Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("ContactNo", txtContactNo.Text);
            cmd.Parameters.AddWithValue("Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("Password", txtPassword.Text);
            cmd.Parameters.AddWithValue("ConfirmPassword", txtCofirmPasssword.Text);
           
            cmd.ExecuteNonQuery();

            txtName.Text=" ";
            txtEmail.Text=" ";
            txtContactNo.Text=" ";
            txtAddress.Text=" ";
            txtPassword.Text=" ";
            txtCofirmPasssword.Text=" ";

            

            con.Close();
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Registered sucessfully .')</script>");

        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {

        } 

    }
}
