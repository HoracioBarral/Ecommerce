using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class ModificarArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx", false);
            }
            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"]);
                List<Articulo> lista = (List<Articulo>)(Session["listaArticulos"]);
                Articulo articulo = lista.Find(a => a.idArticulo == id);
                txtNombreArticulo.Text = articulo.nombreArticulo;
                txtDescripcion.Text = articulo.descripcion;
                txtCategoria.Text = articulo.categoria.nombreCategoria;
            }
        }
    }
}