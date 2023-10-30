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
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaarticulos = negocio.listar();
            Repeater1.DataSource = listaarticulos;
            Repeater1.DataBind();
        }
    }
}