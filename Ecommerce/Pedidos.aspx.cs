using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Negocio;

namespace Ecommerce
{
    public partial class Pedidos : System.Web.UI.Page
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

        }
    }
}