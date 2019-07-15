using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PizzaDelivery
{
	public partial class About : Page
	{
        public string message = string.Empty;
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void btnLoginIn_Click(object sender, EventArgs e)
        {
            message= "Welcome";
        }
	}
}