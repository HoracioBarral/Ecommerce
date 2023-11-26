using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using dominio;

namespace Ecommerce
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                BtnAcesso.Visible = false;
                BtnSalir.Visible = true;
                if (Session["Carrito"] == null)
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    usuario = (Usuario)Session["usuario"];
                    PedidoNegocio pedidoNegocio = new PedidoNegocio();
                    List<Pedido> pedidos = pedidoNegocio.listar();
                    List<Pedido> pedidoFiltrado = pedidos.FindAll(x => x.estado == 1 && x.idUsuario == usuario.idUsuario);
                    if (pedidoFiltrado.Count() > 0)
                    {
                        List<Articulo> carrito = pedidoNegocio.listarDetallePedido(pedidoFiltrado[0].idPedido);
                        ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                        foreach (Articulo articulo in carrito)
                        {
                            Articulo art = new Articulo();
                            int id = articulo.idArticulo;
                            art = articuloNegocio.buscarPorID(id);
                            articulo.descripcion = art.descripcion;
                            articulo.marca = art.marca;
                            articulo.descripcion = art.descripcion;
                            articulo.categoria = art.categoria;
                            articulo.nombreArticulo = art.nombreArticulo;
                        }

                        Session["Carrito"] = carrito;
                        Session["idPedido"] = pedidoFiltrado[0].idPedido;
                    }
                }
            }

            if(!(Page is Login || Page is Carrito || Page is Default || Page is DetalleArticulo || Page is Productos || Page is Contacto || Page is Registro)){
                if (!Seguridad.esAdmin(Session["usuario"]))
                {
                    Response.Redirect("Login.aspx", false);
                }
            }

            if (Session["usuario"]!=null && Page is Login)
            {
                Response.Redirect("Productos.aspx", false);
            }
        }

        protected void BtnCarrito_Click(object sender, EventArgs e)
        {
            Response.Redirect("Carrito.aspx", false);
        }

        protected void BtnAcesso_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }

        protected void BtnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
            Session.Remove("usuario");
            Session.Remove("idPedido");
            BtnSalir.Visible = false;
            BtnAcesso.Visible = true;
            //actualizar stock y pedidos si se cierra la sesion sin efectuar la compra del carrito
            if (Session["Carrito"] != null)
            {
                StockNegocio stockNegocio = new StockNegocio();
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                List<Articulo> articulos = (List<Articulo>)(Session["Carrito"]);
                foreach (Articulo art in articulos)
                {
                    stockNegocio.modificarStock(art.idArticulo,art.talle,art.cantidad,true);
                    articuloNegocio.modificarEstadoCompra(art.numeroPedido,4);
                }
                List<Articulo> carritoLimpio = new List<Articulo>();
                Session.Add("Carrito", carritoLimpio);
            }
        }

    }
}