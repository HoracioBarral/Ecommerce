﻿using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Ecommerce
{
    public partial class Carrito : System.Web.UI.Page
    {
        private ArticuloNegocio articulonegocio = new ArticuloNegocio();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Carrito"] == null)
                {
                    List<Articulo> newCarrito = new List<Articulo>();
                    Session.Add("Carrito", newCarrito);
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

        private void RemoveCarrito(int idArticulo)
        {
            List<Articulo> carrito = (List<Articulo>)Session["Carrito"];
            Articulo articuloParaQuitar = carrito.Find(a => a.idArticulo == idArticulo);
            if (articuloParaQuitar != null)
            {
                StockNegocio stock = new StockNegocio();
                stock.modificarStock(articuloParaQuitar.idArticulo, articuloParaQuitar.talle, articuloParaQuitar.cantidad, true);
                ArticuloNegocio articulo = new ArticuloNegocio();
                articulonegocio.modificarEstadoCompra(articuloParaQuitar.numeroPedido,4);
                carrito.Remove(articuloParaQuitar);
            }

            // Actualizar la sesión con el carrito modificado
            Session["Carrito"] = carrito;
        }

        protected void btnQuitar_Click1(object sender, EventArgs e)
        {
            int idArticulo = Convert.ToInt32(((Button)sender).CommandArgument);

            // Lógica para quitar el artículo del carrito
            RemoveCarrito(idArticulo);

            // Actualizar la presentación y otros elementos según sea necesario
            cargarLista((List<Articulo>)Session["Carrito"]);
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            List<Articulo> carrito = new List<Articulo>();
            carrito = (List<Articulo>)Session["Carrito"];
            if (carrito.Count>0)
            {
                int idPedido = (int)Session["idPedido"];
                PedidoNegocio pedidoNegocio = new PedidoNegocio();
                pedidoNegocio.actualizarEstado(2, idPedido);
                ServicioEmail mail = new ServicioEmail();
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["usuario"];
                mail.armarCorreo(usuario.nombreUsuario, "Compra confirmada", "Su compra por "+lblPrecioTotal.Text+" ha sido confirmada, nos contactaremos para realizar el pago");
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
    }
}