using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Ecommerce
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                BtnAcesso.Visible = false;
                BtnSalir.Visible = true;
            }

            if(!(Page is Login || Page is Carrito || Page is Default || Page is DetalleArticulo || Page is Productos || Page is Contacto)){
                if (!Seguridad.esAdmin(Session["usuario"]))
                {
                    Response.Redirect("Login.aspx", false);
                }
            } 
        }

        protected void BtnCarrito_Click(object sender, EventArgs e)
        {
            Response.Redirect("Carrito.aspx", false);
        }

        protected void BtnAcesso_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }

        protected void BtnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            BtnSalir.Visible = false;
            BtnAcesso.Visible = true;
            Response.Redirect("Login.aspx", false);
        }
    }
}