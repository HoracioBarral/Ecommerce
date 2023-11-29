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
        public string TextoCarrusel
        {
            get { return lblCarrusel.Text; }
            set { lblCarrusel.Text = value; }
        }
        public string TextoCarrusel2
        {
            get { return lblCarrusel2.Text; }
            set { lblCarrusel2.Text = value; }
        }

        public string TextoCarrusel3
        {
            get { return lblCarrusel3.Text; }
            set { lblCarrusel3.Text = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                BtnAcesso.Visible = false;
                BtnSalir.Visible = true;
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
            if (Request.Cookies["IDCarrusel1"] != null)
            {
                int idCarrusel = Convert.ToInt32(Request.Cookies["IDCarrusel1"].Value);

                CarrouselNegocio negocio = new CarrouselNegocio();
                dominio.Carrousel carrouselSeleccionado = negocio.ObtenerTextoPorID(idCarrusel);

                TextoCarrusel = carrouselSeleccionado.Texto;
                
            }
            if (Request.Cookies["IDCarrusel2"] != null)
            {
                int idCarrusel = Convert.ToInt32(Request.Cookies["IDCarrusel2"].Value);

                CarrouselNegocio negocio = new CarrouselNegocio();
                dominio.Carrousel carrouselSeleccionado = negocio.ObtenerTextoPorID(idCarrusel);

                TextoCarrusel2 = carrouselSeleccionado.Texto; // Puedes cambiar esto según tus necesidades
                
            }
            if (Request.Cookies["IDCarrusel3"] != null)
            {
                int idCarrusel = Convert.ToInt32(Request.Cookies["IDCarrusel3"].Value);

                CarrouselNegocio negocio = new CarrouselNegocio();
                dominio.Carrousel carrouselSeleccionado = negocio.ObtenerTextoPorID(idCarrusel);
                TextoCarrusel3 = carrouselSeleccionado.Texto; // Puedes cambiar esto según tus necesidades
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
                    articuloNegocio.modificarDetalleCompra(art.numeroPedido, 0);
                }
                List<Articulo> carritoLimpio = new List<Articulo>();
                Session.Add("Carrito", carritoLimpio);
            }
        }
        
        public void ActualizarCarrusel(string nuevoTexto)
        {
            TextoCarrusel = nuevoTexto;
        }

    }
}