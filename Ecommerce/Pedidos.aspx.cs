using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            if (estado == 4)
            {
                actualizarStock(idPedido);
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Administrador2.aspx", false);
        }

        private void actualizarStock(int idPedido)
        {
            List<Articulo> articulosEliminados = new List<Articulo>();
            PedidoNegocio pedidoNegocio = new PedidoNegocio();
            articulosEliminados = pedidoNegocio.listarDetallePedido(idPedido);

            foreach(Articulo articulo in articulosEliminados)
            {
                StockNegocio stockNegocio = new StockNegocio();
                stockNegocio.modificarStock(articulo.idArticulo, articulo.talle, articulo.cantidad,true);
            }
        }


    }
}