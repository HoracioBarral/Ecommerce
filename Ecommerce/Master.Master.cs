﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btncarrito_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Carrito.aspx", false);
        }
    }
}