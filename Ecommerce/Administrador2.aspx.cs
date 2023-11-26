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
            /*
            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx", false);
            }*/
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            Session.Add("listaArticulos", articuloNegocio.ListarconSP());
            if (!IsPostBack)
            {
                dgvArticulos.DataSource = Session["listaArticulos"];
                dgvArticulos.DataBind();
            }
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)(dgvArticulos.SelectedDataKey.Value);
            //Response.Redirect($"ModificarArticulo.aspx?id={id}", false);
            Response.Redirect("ModificarArticulo.aspx?id="+id, false);
        }

        protected void btnNuevoArticulo_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModificarArticulo.aspx?nuevo=true");
        }

        protected void btnMarcaCategoria_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoriasMarcas.aspx", false);
        }

        protected void BtnUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsuariosRegistrados.aspx",false);
        }

        protected void btnPedidos_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pedidos.aspx", false);
        }

        protected void btnDetallePedidos_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoPedidos2.aspx",false);
        }

        protected void btnCarrousel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Carrousel.aspx", false);
        }
    }
}