using dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class ListadoPedidos2 : System.Web.UI.Page
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
            pedidos = pedidos.FindAll(x => x.estado != 4);
            dgvPedidos.DataSource = pedidos;
            dgvPedidos.DataBind();
        }

        
        protected void dgvPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("DetallePedidos.aspx?id=" + dgvPedidos.SelectedValue, false);
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
            articulosEliminados = articulosEliminados.FindAll(x => x.Estado == true);
            foreach (Articulo articulo in articulosEliminados)
            {
                StockNegocio stockNegocio = new StockNegocio();
                stockNegocio.modificarStock(articulo.idArticulo, articulo.talle, articulo.cantidad, true);
            }
        }

        protected void dgvPedidos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //GridViewRow row = dgvPedidos.SelectedRow;
            //DropDownList ddlEstado = (DropDownList)row.FindControl("ddlEstado");
            //int estado = int.Parse(ddlEstado.SelectedValue);
            if (e.CommandName != "ModificarEstado")
            {
                return;
            }
            int indice = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = dgvPedidos.Rows[indice];
            DropDownList ddlEstado = (DropDownList)selectedRow.FindControl("ddlEstado");
            DataGrid dgvPedido = (DataGrid)selectedRow.FindControl("dgvPedido");
            int idPedido = (int)(dgvPedidos.DataKeys[selectedRow.RowIndex].Value);
            int nuevoEstado = int.Parse(ddlEstado.SelectedValue);
            PedidoNegocio pedidoNegocio = new PedidoNegocio();
            List<Pedido> lista = pedidoNegocio.listar();
            //Insertar aqui la logica para evitar los siguientes cambios de estado de Pedidos
            //Comparar el estado del pedido a modificar con el estado seleccionado por el admin
            //usar List<Pedido> lista y nuevoEstado para esta comparacion
            //Un Pedido con ID=4,5 no puede cambiarse el estado
            //Un Pedido con ID=2 solo puede modificarse a estado 3,4 o 5
            //Un Pedido con ID=1 solo puede modificarse a estado 4
            //Un Pedido con ID=3 solo puede modificarse a estado 4 o 5
            pedidoNegocio.actualizarEstado(nuevoEstado, idPedido);
            recargarPedidos();
            if (nuevoEstado == 4)
            {
                List<Pedido> pedido = lista.FindAll(x => x.idPedido == idPedido);
                actualizarStock(idPedido);
                if (pedido[0].estado != 1)
                {
                    UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                    List<Usuario> usuarios = usuarioNegocio.Listar();
                    List<Usuario> usuarioFiltrado = usuarios.FindAll(x => x.idUsuario == pedido[0].idUsuario);
                    ServicioEmail mail = new ServicioEmail();
                    mail.armarCorreo(usuarioFiltrado[0].nombreUsuario, "Compra Cancelada", "Su compra numero " + idPedido.ToString() + " fue cancelada");
                    mail.enviarMail();
                }
            }
        }
    }
}