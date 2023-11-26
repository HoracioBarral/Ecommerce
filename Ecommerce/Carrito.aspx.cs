using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.Collections;
using System.Web.UI.WebControls.WebParts;

namespace Ecommerce
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                if (Session["Carrito"] == null)
                {
                    List<Articulo> newCarrito = new List<Articulo>();
                    Session.Add("Carrito", newCarrito);
                    verificarPedidos(newCarrito);
                }
                List<Articulo> carrito = (List<Articulo>)Session["Carrito"];
                cargarLista(carrito);
                updateContador();
            }
        }

        private void cargarLista(List<Articulo> carrito)
        {
            repeaterCarrito.DataSource = carrito;
            repeaterCarrito.DataBind();
            updatePrecio(carrito);
            updateContador();
        }

        private void updateContador()
        {
            Label tamCarrito = Master.FindControl("tamCarrito") as Label;
            if (tamCarrito != null)
            {
                List<Articulo> carrito = (List<Articulo>)Session["Carrito"];
                tamCarrito.Text = carrito.Count.ToString();
            }
        }
        private void updatePrecio(List<Articulo> carrito)
        {
            decimal total = 0;
            foreach (var articulo in carrito)
            {
                total += articulo.precio;
            }
            lblPrecioTotal.Text = total.ToString("C2");
        }

        private void RemoveCarrito(int idArticulo, string talle)
        {
            List<Articulo> carrito = (List<Articulo>)Session["Carrito"];
            Articulo articuloParaQuitar = carrito.Find(a => a.idArticulo == idArticulo && a.talle == talle);
            if (articuloParaQuitar != null)
            {
                StockNegocio stock = new StockNegocio();
                stock.modificarStock(articuloParaQuitar.idArticulo, articuloParaQuitar.talle, articuloParaQuitar.cantidad, true);
                //articulo.modificarEstadoCompra(articuloParaQuitar.numeroPedido,4);
                PedidoNegocio pedidoNegocio = new PedidoNegocio();
                pedidoNegocio.actualizarDetallePedido(articuloParaQuitar, 0);
                carrito.Remove(articuloParaQuitar);
            }
            if (carrito.Count == 0)
            {
                ArticuloNegocio articulo = new ArticuloNegocio();
                articulo.modificarEstadoCompra(articuloParaQuitar.numeroPedido, 4);
            }
            // Actualizar la sesión con el carrito modificado
            Session["Carrito"] = carrito;
        }

        protected void btnQuitar_Click1(object sender, EventArgs e)
        {
            string[] argumento = ((Button)sender).CommandArgument.Split('_');
            int idArticulo = int.Parse(argumento[0]);
            string talle = argumento[1];
            //int idArticulo = Convert.ToInt32(((Button)sender).CommandArgument);

            // Lógica para quitar el artículo del carrito
            RemoveCarrito(idArticulo, talle);

            // Actualizar la presentación y otros elementos según sea necesario
            cargarLista((List<Articulo>)Session["Carrito"]);
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            List<Articulo> carrito = new List<Articulo>();
            carrito = (List<Articulo>)Session["Carrito"];
            if (carrito.Count > 0)
            {
                int idPedido = (int)Session["idPedido"];
                PedidoNegocio pedidoNegocio = new PedidoNegocio();
                pedidoNegocio.actualizarEstado(2, idPedido);
                ServicioEmail mail = new ServicioEmail();
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["usuario"];
                mail.armarCorreo(usuario.nombreUsuario, "Compra confirmada", "Su compra con registro " + idPedido.ToString() + " por " + lblPrecioTotal.Text + " ha sido confirmada, nos contactaremos para realizar el pago");
                mail.enviarMail();
                mail.armarCorreo("pruebasUTN2023@gmail.com", "Nueva compra", "Se confirma la compra con ID " + idPedido + " del usuario " + usuario.nombreUsuario);
                mail.enviarMail();
                List<Articulo> carritoVacio = new List<Articulo>();
                Session.Add("Carrito", carritoVacio);
                Session.Remove("idPedido");
                lblPrecioTotal.Text = "0";
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx", false);
        }

        protected void btnRestar_Click(object sender, EventArgs e)
        {
            string[] argumento = ((Button)sender).CommandArgument.Split('_');
            int idArticulo = int.Parse(argumento[0]);
            string talle = argumento[1];
            List<Articulo> carrito = (List<Articulo>)Session["Carrito"];
            Articulo articuloMenos = carrito.Find(a => a.idArticulo == idArticulo && a.talle == talle);
            if (articuloMenos.cantidad == 1 || articuloMenos == null) return;
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            StockNegocio stock = new StockNegocio();
            foreach (Articulo articulo in carrito)
            {
                if (articulo.idArticulo == idArticulo && articulo.talle == articuloMenos.talle)
                {
                    articulo.cantidad--;
                    stock.modificarStock(idArticulo, articulo.talle, 1, true);
                    articulo.numeroPedido = (int)Session["idPedido"];
                    Articulo precioUnitario = articuloNegocio.buscarPorID(idArticulo);
                    articulo.precio -= precioUnitario.precio;
                    articuloNegocio.actualizarDetallePedido(articulo, articulo.numeroPedido);
                    Session["Carrito"] = carrito;
                    cargarLista(carrito);
                    return;
                }
            }
        }


        protected void btnSumar_Click(object sender, EventArgs e)
        {
            string[] argumento = ((Button)sender).CommandArgument.Split('_');
            int idArticulo = int.Parse(argumento[0]);
            string talle = argumento[1];
            List<Articulo> carrito = (List<Articulo>)Session["Carrito"];
            Articulo articuloMas = carrito.Find(a => a.idArticulo == idArticulo && a.talle == talle);
            if (articuloMas == null) return;
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            StockNegocio stockNegocio = new StockNegocio();
            List<StockTalles> stock = stockNegocio.listarPorID(idArticulo);
            List<StockTalles> stockFiltrado = stock.FindAll(x => x.talle == talle && x.stock >= 1);
            //int cantidadActual = stockFiltrado[0].stock;
            if (stockFiltrado.Count == 0 || stockFiltrado[0].stock >= (stockFiltrado[0].stock) + 1) return;

            foreach (Articulo articulo in carrito)
            {
                if (articulo.idArticulo == idArticulo && articulo.talle == articuloMas.talle)
                {
                    articulo.cantidad++;
                    stockNegocio.modificarStock(idArticulo, articulo.talle, 1, false);
                    articulo.numeroPedido = (int)Session["idPedido"];
                    Articulo precioUnitario = articuloNegocio.buscarPorID(idArticulo);
                    articulo.precio += precioUnitario.precio;
                    articuloNegocio.actualizarDetallePedido(articulo, articulo.numeroPedido);
                    Session["Carrito"] = carrito;
                    cargarLista(carrito);
                    return;
                }
            }
        }

        private void verificarPedidos(List<Articulo> carritoVerificable)
        {
            if (carritoVerificable.Count==0)
            {
                Usuario usuario = (Usuario)Session["usuario"];
                usuario = (Usuario)Session["usuario"];
                PedidoNegocio pedidoNegocio = new PedidoNegocio();
                List<Pedido> pedidos = pedidoNegocio.listar();
                List<Pedido> pedidoFiltrado = pedidos.FindAll(x => x.estado == 1 && x.idUsuario == usuario.idUsuario);
                if (pedidoFiltrado.Count() > 0)
                {
                    List<Articulo> carrito = pedidoNegocio.listarDetallePedido(pedidoFiltrado[0].idPedido);
                    carrito = carrito.FindAll(x => x.Estado == true);
                    ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                    foreach (Articulo articulo in carrito)
                    {
                        if (articulo.Estado == true)
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
                    }
                    Session["Carrito"] = carrito;
                    Session["idPedido"] = pedidoFiltrado[0].idPedido;
                }
            }
        }
    }
}