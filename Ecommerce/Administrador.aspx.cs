using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Negocio;

namespace Ecommerce
{
    public partial class Administrador : System.Web.UI.Page
    {
        List<Articulo> listadoArticulos;
        public List<Articulo> listaarticulos = new List<Articulo>();
        private ArticuloNegocio articulonegocio = new ArticuloNegocio();
        protected void Page_Load(object sender, EventArgs e)
            
        {
            Usuario usuario = new Usuario();
            if (Session ["usuario"] == null)
            {
                Session.Add("Error", "Debes ser administrador para ingresar");
                Response.Redirect("Login.aspx", false);
            }

            listaarticulos = articulonegocio.listar();
            if (!IsPostBack)
            {
                ArticuloNegocio articulonegocio = new ArticuloNegocio();
                Session.Add("listadoArticulos", articulonegocio.listar());
                Repeater1.DataSource = articulonegocio.listar();
                Repeater1.DataBind();
            }
        }
        protected string GetImageUrl(object dataItem)
        {
            if (dataItem is Articulo articulo && articulo.listaImagenes.Count > 0)
            {
                return articulo.listaImagenes[0].UrlImagen;
            }
            return string.Empty;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }


    }
}