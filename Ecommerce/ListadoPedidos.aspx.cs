using dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class ListadoPedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PedidoNegocio pedidoNegocio = new PedidoNegocio();
                List<Pedido> pedidos = new List<Pedido>();
                pedidos = pedidoNegocio.listar();
                dgvPedidos.DataSource = pedidos;
                dgvPedidos.DataBind();
            }
        }

        protected void dgvPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {

            Response.Redirect("DetallePedidos.aspx?id=" + dgvPedidos.SelectedValue, false);
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Administrador2.aspx", false);
        }
    }
}