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
            if (!IsPostBack)
            {
                ArticuloNegocio articulonegocio = new ArticuloNegocio();
                Session.Add("listadoArticulos",articulonegocio.listar());
                Repeater1.DataSource = Session["listadoArticulos"];
                Repeater1.DataBind();
            }
            updateContador();
        }
        public void ActualizarRepeater(List<Articulo> lista)
        {
            Repeater1.DataSource = lista;
            Repeater1.DataBind();
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