using dominio;
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
            if (Session["Carrito"] == null)
            {
                List<Articulo> newCarrito = new List<Articulo>();
                Session.Add("Carrito", newCarrito);

            }


            List<Articulo> carrito = new List<Articulo>();
            carrito = (List<Articulo>)Session["Carrito"];

            cargarLista(carrito);

            updateContador();

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
                List<Articulo> carrito = new List<Articulo>();
                carrito = (List<Articulo>)Session["Carrito"];
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
            lblPrecioTotal.Text = total.ToString();
        }

        protected void btnQuitar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandArgument);
            Articulo articulo = new Articulo();
            articulo = articulonegocio.buscarPorID(id);
            List<Articulo> carrito = new List<Articulo>();
            carrito = (List<Articulo>)Session["Carrito"];
            RemoveCarrito(articulo);

            cargarLista(carrito);
            Label1.Text = articulo.nombreArticulo + " eliminado del carrito";
            Label1.CssClass = "alert alert-danger";
            updateContador();
            updatePrecio(carrito);
        }

        private void RemoveCarrito(Articulo articulo)
        {
            List<Articulo> carrito = new List<Articulo>();
            carrito = (List<Articulo>)Session["Carrito"];

            for (int i = 0; i < carrito.Count; i++)
            {
                if (carrito[i].idArticulo == articulo.idArticulo)
                {
                    carrito.RemoveAt(i);
                    return;
                }
            }
        }
    }
}