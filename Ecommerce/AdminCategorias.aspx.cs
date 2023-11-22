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
    public partial class AdminCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int idCategoria = int.Parse(Request.QueryString["id"]);
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                Categoria categoria=categoriaNegocio.listarCaterogiaPorId(idCategoria);
                txtCategoria.Text = categoria.nombreCategoria;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string nomCategoria = txtCategoria.Text.ToString();
            if (nomCategoria.Length==0)
            {
                Label1.Visible = true;
                Label1.Text = "No puede Ingresar la Categoria en Blanco";
                return;
            }
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            int idCategoria = int.Parse(Request.QueryString["id"]);
            categoriaNegocio.modificarCategoria(idCategoria, nomCategoria);
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoriasMarcas.aspx", false);
        }
    }
}