using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PizzaDelivery
{
    public partial class Admin : System.Web.UI.Page
    {
        public string message = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

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
                Response.Redirect("DataView.aspx");
            }
            else
            {
                con.Close();
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username and Password')</script>");
            }

        }
    }
}