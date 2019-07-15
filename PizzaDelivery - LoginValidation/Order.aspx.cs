using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Configuration;
using PizzaBal.Actions;



namespace PizzaDelivery
{
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!Page.IsPostBack)
            {
                var orderBal = new OrderBal(ConfigurationManager.ConnectionStrings["Pizzaconnection"].ToString());
                ddlPizzaSize.DataTextField = "Size";
                ddlPizzaSize.DataValueField = "Id";
                ddlPizzaSize.DataSource = orderBal.LoadPizzaSize();
                ddlPizzaSize.DataBind();

                ddlPizzaType.DataTextField = "Type";
                ddlPizzaType.DataValueField = "Id";
                ddlPizzaType.DataSource = orderBal.LoadPizzaType();
                ddlPizzaType.DataBind();
            }
            
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            string name = txtName.Text; // Scrub user data

            string address = txtAddress.Text;
            string Contact = txtContactNo.Text;
            string pizzatype = ddlPizzaType.Text;
            string Quantity = ListBox2.Text;
            string PizzaSize = ddlPizzaSize.Text;

            // SqlConnection cnn = new SqlConnection(@"Data Source=VPCOG1040;Initial Catalog=Pizza;Integrated Security=True; uid=YourUserName");
            string constr = ConfigurationManager.ConnectionStrings["Pizzaconnection"].ToString(); // connection string
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand cmd = new SqlCommand("insert into Delivery (name,address,Contact,PizzaType,Quantity,PizzaSize) values(@name,@Address,@contact,@pizzatype,@Quantity,@PizzaSize)", con);
            cmd.Parameters.AddWithValue("name", txtName.Text);
            cmd.Parameters.AddWithValue("Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("Contact", txtContactNo.Text);
            cmd.Parameters.AddWithValue("PizzaType", ddlPizzaType.Text);
            cmd.Parameters.AddWithValue("Quantity", ListBox2.Text);
            cmd.Parameters.AddWithValue("PizzaSize", ddlPizzaSize.Text);
            cmd.ExecuteNonQuery();



        }

    }
}

