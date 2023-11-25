using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.Net;

namespace Ecommerce
{
    public partial class Productos : System.Web.UI.Page
    {
        //List<Articulo> listadoArticulos;
        //public List<Articulo> listaarticulos = new List<Articulo>();
        //private ArticuloNegocio articulonegocio = new ArticuloNegocio();
        public bool EvaluarEstadoDelEnlace(string url)
        {
            try
            {
                // Crea una instancia de HttpWebRequest para la URL proporcionada.
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                // Evitar la redirección automática.
                request.AllowAutoRedirect = false;

                // Realiza la solicitud GET.
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    // Verifica el estado de la respuesta.
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (WebException ex)
            {
                return false;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //listaarticulos = articulonegocio.listar();
            if (Session["Carrito"] == null)
            {
                List<Articulo> carrito = new List<Articulo>();
                Session.Add("Carrito", carrito);
            }
            if (!IsPostBack)
            {
                ArticuloNegocio articulonegocio = new ArticuloNegocio();
                Session.Add("listadoArticulos",articulonegocio.listar());
                Repeater1.DataSource = articulonegocio.listar();
                Repeater1.DataBind();
            }
            updateContador();
        }

        protected string GetImageUrl(object dataItem)
        {
            if (dataItem is Articulo articulo && articulo.listaImagenes.Count > 0)
            {
                return articulo.listaImagenes[0].UrlImagen;
            }
            return "Imagen/error.png";
            //return string.Empty;
        }


        protected void btnCarrito_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            int id = int.Parse(((Button)sender).CommandArgument);
            Articulo articulo = new Articulo();
            articulo = articuloNegocio.buscarPorID(id);
            Response.Redirect("DetalleArticulo.aspx?id=" + id, false);
            /*
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
                Response.Redirect("Carrito.aspx", false);
            }
            else
            {
                Label1.Text = articulo.nombreArticulo + " ya añadido en carrito";
                Label1.CssClass = "alert alert-danger";
            }*/


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

    }
}