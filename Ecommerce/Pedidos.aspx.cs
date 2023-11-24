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
                recargarPedidos();
            }
        }

        private void recargarPedidos()
        {
            PedidoNegocio pedidoNegocio = new PedidoNegocio();
            List<Pedido> pedidos = new List<Pedido>();
            pedidos = pedidoNegocio.listar();
            dgvPedidos.DataSource = pedidos;
            dgvPedidos.DataBind();
        }

        protected void dgvPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = dgvPedidos.SelectedRow; 
            DropDownList ddlEstado = (DropDownList)row.FindControl("ddlEstado");
            int estado =int.Parse(ddlEstado.SelectedValue);
            int idPedido = (int)(dgvPedidos.SelectedDataKey.Value);
            PedidoNegocio pedidoNegocio = new PedidoNegocio();
            pedidoNegocio.actualizarEstado(estado, idPedido);
            recargarPedidos();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Administrador2.aspx", false);
        }
    }
}