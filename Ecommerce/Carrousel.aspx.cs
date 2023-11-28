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

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {

        }
    }
}