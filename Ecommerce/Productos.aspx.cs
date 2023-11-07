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
    public partial class Productos : System.Web.UI.Page
    {
        public List<Articulo> listaarticulos = new List<Articulo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Articulo articulo = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaarticulos = negocio.listar();
            Repeater1.DataSource = listaarticulos;
            Repeater1.DataBind();
        }

        protected string RenderImages(object dataItem)
        {
            if (dataItem is Articulo articulo)
            {
                string carouselItems = string.Empty;

                for (int i = 0; i < articulo.listaImagenes.Count; i++)
                {
                    string activeClass = (i == 0) ? "active" : string.Empty;
                    string imageSource = articulo.listaImagenes[i].UrlImagen;

                    carouselItems += $@"
             <div class='carousel-item {activeClass}'>
             <img src='{imageSource}' class='d-block w-100' alt='Image {i + 1}'>
              </div>";
                }

                return carouselItems;
            }

            return string.Empty;
        }

    }
}