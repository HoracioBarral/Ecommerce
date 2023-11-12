using dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

namespace Ecommerce
{
    public partial class Default : System.Web.UI.Page
    {
        List<Articulo> listadoArticulos;
        public List<Articulo> listaarticulos = new List<Articulo>();
        private ArticuloNegocio articulonegocio = new ArticuloNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            listaarticulos = articulonegocio.listar();
            if (Session["Carrito"] == null)
            {
                List<Articulo> carrito = new List<Articulo>();
                Session.Add("Carrito", carrito);
            }
            if (!IsPostBack)
            {
               
            }
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


    }
}