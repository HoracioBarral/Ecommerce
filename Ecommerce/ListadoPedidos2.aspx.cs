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
            List<Pedido> pedido = lista.FindAll(x => x.idPedido == idPedido);
            if (!validarEstadoPedido(pedido[0], nuevoEstado))
            {
                return;
            }
            pedidoNegocio.actualizarEstado(nuevoEstado, idPedido);
            recargarPedidos();
            Label1.Text = "Cambio de estado Realizado";
            Label1.Visible = true;
            if (nuevoEstado == 4)
            {
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
            string envio = numeroEnvio.Value;
            string proveedor = nombreProveedor.Value;
            if (nuevoEstado == 3 && (!string.IsNullOrEmpty(envio)))
            {
                pedidoNegocio.actualizarEnvio(envio, proveedor, idPedido);
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                List<Usuario> usuarios = usuarioNegocio.Listar();
                List<Usuario> usuarioFiltrado = usuarios.FindAll(x => x.idUsuario == pedido[0].idUsuario);
                ServicioEmail mail = new ServicioEmail();
                mail.armarCorreo(usuarioFiltrado[0].nombreUsuario, "Envio exitoso","Su compra "+ idPedido.ToString()+ " fue despachada con el numero "+envio+" de "+proveedor);
                mail.enviarMail();
            }
        }

        private bool validarEstadoPedido(Pedido pedido, int nuevoEstado)
        {
            if (pedido.estado == 4 || pedido.estado == 5)
            {
                Label1.Text = "No se puede modificar un pedido cancelado o entregado";
                Label1.Visible = true;
                return false;
            }
            if (pedido.estado == 2 && nuevoEstado == 1)
            {
                Label1.Text = "No se puede enviar al carrito un pedido confirmado";
                Label1.Visible = true;
                return false;
            }
            if(pedido.estado == 1 && nuevoEstado != 4)
            {
                Label1.Text = "Un pedido que esta en carrito solo se puede cancelar";
                Label1.Visible = true;
                return false;
            }
            if(pedido.estado==3 && (nuevoEstado<4))
            {
                Label1.Text = "Una compra abonada solo puede cancelarse o dada por entregada";
                Label1.Visible = true;
                return false;
            }
            if (nuevoEstado == 3)
            {
                string envio = numeroEnvio.Value;
                string proveedor = nombreProveedor.Value;
                if (!string.IsNullOrEmpty(envio) && string.IsNullOrEmpty(proveedor) || (string.IsNullOrEmpty(envio) && !string.IsNullOrEmpty(proveedor)))
                {
                    Label1.Text = "Debe completar ambos campos en caso que tenga un numero de envio. Si la opcion es retiro en tienda debe dejar los datos en blanco";
                    Label1.Visible = true;
                    return false;
                }
            }
            return true;
        }
    }
}