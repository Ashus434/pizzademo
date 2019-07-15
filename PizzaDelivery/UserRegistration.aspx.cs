using PizzaBal.Actions;
using PizzaDal.Models;
using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;


namespace PizzaDelivery
{
    public enum UserType
    {
        Admin = 1,
        User = 2,
        
    }
    public partial class UserRegistration : Page
    {
        public bool isvalidEmail;
        public string message = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {


        }

        
        //TODO: will look into this later
        //public bool Adduser(User user)
        //{
        //    return RegistrationDb.Adduser(user);
        //}


        protected void btnSignUp_Click(object sender, EventArgs e)
         {
            User user = new User();
            user.Name = txtName.Text;
            user.Email = txtEmail.Text;
            user.ContactNo = txtContactNo.Text;
            user.Address = txtAddress.Text;
            user.Password = txtPassword.Text;
            user.ConfirmPassword = txtCofirmPasssword.Text;

            // RegisterBal.Adduser(user);

            //UserHandler userHandler = new UserHandler();
            ////  RegisterBal userHandler = new RegisterBal();
            //if (UserHandler.Adduser(user) == true)
            //{
            //    //Successfully added a new employee in the database
            //    Response.Redirect("Default.aspx");
            //}

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


            //string constr = ConfigurationManager.ConnectionStrings["Pizzaconnection"].ToString(); // connection string
            //SqlConnection con = new SqlConnection(constr);
            //con.Open();
            //string message = string.Empty;
            //int User_Type = (int)UserType.User;
            //SqlCommand cmd = new SqlCommand("insert into Registration (name,Email,Contact,Address,Password,ConfirmPassword,User_Type) values(@name,@Email,@ContactNo,@Address,@Password,@ConfirmPassword,@User_Type)", con);

            //cmd.Parameters.AddWithValue("Name", txtName.Text);
            //cmd.Parameters.AddWithValue("Email", txtEmail.Text);
            //cmd.Parameters.AddWithValue("ContactNo", txtContactNo.Text);
            //cmd.Parameters.AddWithValue("Address", txtAddress.Text);
            //cmd.Parameters.AddWithValue("Password", txtPassword.Text);
            //cmd.Parameters.AddWithValue("ConfirmPassword", txtCofirmPasssword.Text);
            //cmd.Parameters.AddWithValue("User_Type", User_Type);



            //cmd.ExecuteNonQuery();

            txtName.Text = " ";
            txtEmail.Text = " ";
            txtContactNo.Text = " ";
            txtAddress.Text = " ";
            txtPassword.Text = " ";
            txtCofirmPasssword.Text = " ";





            //con.Close();
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Registered sucessfully .')</script>");

        }

        protected void onEmailCheck(object sender, EventArgs e)
        {
            var regBal = new RegisterBal();

            isvalidEmail = regBal.IsValidEmail(txtEmail.Text.Trim());

            if (!isvalidEmail)
            {
                message = "Email address already exists";
                txtEmail.Focus();
            }
            else
            {
                message = "";
            }
        }
        


        public string sqlCommand { get; set; }

        public string constring { get; set; }
    }
}















//protected void onEmailCheck1(object sender, EventArgs e)
//{
//    SqlConnection con = new SqlConnection(constring);
//    string EmaiId = txtEmail.Text.Trim();

//    SqlCommand cmd = new SqlCommand("SELECT Email FROM Registration WHERE Email ='" + EmaiId + "'", con);
//    con.Open();
//    SqlDataReader idr = cmd.ExecuteReader();
//    if (idr.HasRows)
//    {
//       message= "Email address already exists";
//        txtEmail.Focus();
//    }
//    else
//    {
//        message= "";
//    }
//    con.Close();
//}