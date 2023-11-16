using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class Administrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session ["usuario"] == null )
            {
                Session.Add("Error", "Debes ser administrador para ingresar");
                Response.Redirect("Login.aspx");
            }
        }
    }
}