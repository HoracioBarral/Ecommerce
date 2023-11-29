using dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Ecommerce
{
    public partial class Carrousel : System.Web.UI.Page
    {
      

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarrouselNegocio negocio = new CarrouselNegocio();
                List<dominio.Carrousel> listaCarr = negocio.listarCarrousel();
               
                ddlCarrousel1.DataSource = listaCarr;
                ddlCarrousel1.DataValueField = "idCarrousel";
                ddlCarrousel1.DataTextField = "Texto";
                ddlCarrousel1.DataBind();
                // Precargar datos en el DropDownList 2
                ddlCarrousel2.DataSource = listaCarr;
                ddlCarrousel2.DataValueField = "idCarrousel";
                ddlCarrousel2.DataTextField = "Texto";
                ddlCarrousel2.DataBind();
                // Precargar datos en el DropDownList 3
                ddlCarrousel3.DataSource = listaCarr;
                ddlCarrousel3.DataValueField = "idCarrousel";
                ddlCarrousel3.DataTextField = "Texto";
                ddlCarrousel3.DataBind();

            }
        }

        private void CrearCookie(string nombre, int valor)
        {
            HttpCookie cookie = new HttpCookie(nombre);
            cookie.Value = valor.ToString();
            cookie.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(cookie);
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {

        }

        protected void btnAgregar1_Click(object sender, EventArgs e)
        {
            int idSeleccionado1 = Convert.ToInt32(ddlCarrousel1.SelectedValue);
            HttpCookie cookie1 = new HttpCookie("IDCarrusel1");
            cookie1.Value = idSeleccionado1.ToString();
            cookie1.Expires = DateTime.Now.AddDays(30);

            Response.Cookies.Add(cookie1);

            CarrouselNegocio negocio = new CarrouselNegocio();

            string textoCarrusel1 = negocio.ObtenerTextoPorID(idSeleccionado1)?.Texto;

            ((Ecommerce.Master)Master).TextoCarrusel = textoCarrusel1;

        }

        protected void btnAgregar2_Click(object sender, EventArgs e)
        {
            int idSeleccionado2 = Convert.ToInt32(ddlCarrousel2.SelectedValue);
            HttpCookie cookie2 = new HttpCookie("IDCarrusel2");
            cookie2.Value = idSeleccionado2.ToString();
            cookie2.Expires = DateTime.Now.AddDays(30);

            Response.Cookies.Add(cookie2);

            CarrouselNegocio negocio = new CarrouselNegocio();

            string textoCarrusel2 = negocio.ObtenerTextoPorID(idSeleccionado2)?.Texto;

            ((Ecommerce.Master)Master).TextoCarrusel2 = textoCarrusel2;
        }

        protected void btnAgregar3_Click(object sender, EventArgs e)
        {
            int idSeleccionado3 = Convert.ToInt32(ddlCarrousel3.SelectedValue);
            HttpCookie cookie3 = new HttpCookie("IDCarrusel3");
            cookie3.Value = idSeleccionado3.ToString();
            cookie3.Expires = DateTime.Now.AddDays(30);

            Response.Cookies.Add(cookie3);

            CarrouselNegocio negocio = new CarrouselNegocio();

            string textoCarrusel3 = negocio.ObtenerTextoPorID(idSeleccionado3)?.Texto;

            ((Ecommerce.Master)Master).TextoCarrusel3 = textoCarrusel3;
        }
    }
}