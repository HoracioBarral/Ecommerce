using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class CategoriasMarcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx", false);
            }
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            if (!IsPostBack)
            {
                dgvCategorias.DataSource= categoriaNegocio.listarCategorias();
                dgvCategorias.DataBind();
                dgvMarcas.DataSource = marcaNegocio.listarMarcas();
                dgvMarcas.DataBind();
            }
        }

        protected void dgvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgvMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}