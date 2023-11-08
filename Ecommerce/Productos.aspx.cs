using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.Reflection.Emit;

namespace Ecommerce
{
    public partial class Productos : System.Web.UI.Page
    {
        public List<Articulo> listaarticulos = new List<Articulo>();
        Articulo articulo = new Articulo();
        private ArticuloNegocio articulonegocio = new ArticuloNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaarticulos = negocio.listar();
            Repeater1.DataSource = listaarticulos;
            Repeater1.DataBind();
        }

        protected string GetImageUrl(object dataItem)
        {
            if (dataItem is Articulo articulo && articulo.listaImagenes.Count > 0)
            {
                return articulo.listaImagenes[0].UrlImagen;
            }
            return string.Empty;
        }

        protected void btnCarrito_Click(object sender, EventArgs e)
        {

            int id = int.Parse(((Button)sender).CommandArgument);
            Articulo articulo = new Articulo();
            articulo = articulonegocio.buscarPorID(id);
            if (!estaEnCarrito(articulo))
            {
                Label1.Text = articulo.nombreArticulo + " añadido al carrito";
                Label1.CssClass = "alert alert-success";
                List<Articulo> carrito = new List<Articulo>();
                carrito = (List<Articulo>)Session["Carrito"];
                carrito.Add(articulo);
            }
            else
            {
                Label1.Text = articulo.nombreArticulo + " ya añadido en carrito";
                Label1.CssClass = "alert alert-danger";
            }

        }
        private bool estaEnCarrito(Articulo articulo)
        {
            List<Articulo> carrito = new List<Articulo>();
            carrito = (List<Articulo>)Session["Carrito"];

            foreach (Articulo a in carrito)
            {
                if (a.idArticulo == articulo.idArticulo)
                {
                    return true;
                }
            }
            return false;
        }

    }
}