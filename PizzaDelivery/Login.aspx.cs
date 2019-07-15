using PizzaBal.Actions;
using PizzaDal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace PizzaDelivery
{
    public partial class Login : System.Web.UI.Page
    {
            
        protected void Page_Load(object sender, EventArgs e)
        {

            var loginStatus = this.Master.FindControl("LoginContent").FindControl("LoginStatus1");
            if (loginStatus != null)
            {
                loginStatus.Visible = false;
            }
        

        }

        protected void btnLoginIn_Click(object sender, EventArgs e)
        {

            string user = txtName.Text;
            string pass = txtPassword.Text;
            string constr = ConfigurationManager.ConnectionStrings["Pizzaconnection"].ToString(); // connection string
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand cmd = new SqlCommand("select Email,Password from Registration where Email=@user and Password=@Pass", con);
            cmd.Parameters.Add("user", @user);
            cmd.Parameters.Add("pass", @pass);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                con.Close();
                Response.Redirect("Order.aspx");
            }
            else
            {
                con.Close();
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username and Password')</script>");
            }
            

           /*string[] users = { "user", "admin" };
            string[] passwords = { "user", "admin" };

            for (int i = 0; i < users.Length; i++)
            {*/

                bool validUsername = (string.Compare(txtName.Text, user, true) == 0);

                bool validPassword = (string.Compare(txtPassword.Text, pass, false) == 0);

                if (validUsername && validPassword)
                {
                    Response.Redirect("Order.aspx");
                    // Query the user store to get this user's User Data
                    string userDataString = string.Concat(user, "|", pass);
                    
                    ///Create the cookie that contains the forms authentication ticket
                    HttpCookie authCookie = FormsAuthentication.GetAuthCookie(txtName.Text, RememberMe.Checked);
                    // Get the FormsAuthenticationTicket out of the encrypted cookie
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                    // Create a new FormsAuthenticationTicket that includes our custom User Data
                    FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, userDataString);
                    // Update the authCookie's Value to use the encrypted version of newTicket
                    authCookie.Value = FormsAuthentication.Encrypt(newTicket);
                    // Manually add the authCookie to the Cookies collection
                    Response.Cookies.Add(authCookie);
                    // Determine redirect URL and send user there
                    string redirUrl = FormsAuthentication.GetRedirectUrl(txtName.Text, RememberMe.Checked);
                    Response.Redirect(redirUrl);
                }
            }
                // If we reach here, the user's credentials were invalid

                //InvalidCredentialsMessage.Visible = true;
            
            
        }

       // public int intUserId { get; set; }

       // public string message { get; set; }
    }






/* string Name, password;
            Name = txtName.Text;
            password = txtPassword.Text;
            if (Name == "user" && password == "user")
            {

                Response.Redirect("Order.aspx");
            }
            if (Name == "admin" && password == "admin")
            {

                Response.Redirect("Admin.aspx");
            }
            else
            {
                Response.Write("user or password is incorrect");

            }*/