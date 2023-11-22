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
            int idCategoria = (int)(dgvCategorias.SelectedDataKey.Value);
            Response.Redirect("AdminCategorias.aspx?id=" + idCategoria, false);
        }

        protected void dgvMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idMarca = (int)(dgvMarcas.SelectedDataKey.Value);
            Response.Redirect("AdminMarcas.aspx?id=" + idMarca, false);
        }

        protected void btnNuevaCategoria_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminCategorias.aspx", false);
        }

        protected void btnNuevaMarca_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminMarcas.aspx", false);
        }
    }
}