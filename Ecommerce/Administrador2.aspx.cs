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
            if (!IsPostBack)
            {
                List<Articulo> listaArticulos;
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                listaArticulos = articuloNegocio.listar();
                dgvArticulos.DataSource = listaArticulos;
                dgvArticulos.DataBind();
            }
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id=dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("DetalleArticulo.aspx?id="+ id, false);
        }
    }
}