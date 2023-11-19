using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace Ecommerce
{
    public partial class Administrador2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx", false);
            }
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            Session.Add("listaArticulos", articuloNegocio.listar());
            if (!IsPostBack)
            {
                dgvArticulos.DataSource = Session["listaArticulos"];
                dgvArticulos.DataBind();
            }
        }

        protected void dgvArticulos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            List<Articulo> lista = (List<Articulo>)(Session["listaArticulos"]);
            Articulo articulo = lista.Find(a => a.idArticulo == (id+1));
            if (articulo != null)
            {
                Response.Redirect("ModificarArticulo.aspx?id=" + id, false);
            }
        }
    }
}