using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Articulo> carrito;
            if (Session["artAgregados"] == null)
            {
                carrito = new List<Articulo>();
                Session.Add("carrito", carrito);
                return;
            }
            carrito = (List<Articulo>)Session["artAgregados"];
            Session.Add("carrito", carrito);
            if (!IsPostBack)
            {
                repeaterCarrito.DataSource = Session["artAgregados"];
                repeaterCarrito.DataBind();
            }
        }
    }
}