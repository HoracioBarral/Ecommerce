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
            if (Request.QueryString["id"] != null && !IsPostBack)
            {
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                Categoria categoria=categoriaNegocio.listarCaterogiaPorId(int.Parse(Request.QueryString["id"]));
                txtCategoria.Text = categoria.nombreCategoria;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCategoria.Text.Trim() == "")
                {
                    Label1.Visible = true;
                    Label1.Text = "No puede Ingresar la Categoria en Blanco";
                    return;
                }
                string categoria = txtCategoria.Text;
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                if (Request.QueryString["id"] != null)
                {
                    categoriaNegocio.modificarCategoria(int.Parse(Request.QueryString["id"]), txtCategoria.Text);
                }
                else
                    categoriaNegocio.agregarCategoria(txtCategoria.Text);
                Response.Redirect("CategoriasMarcas.aspx", false);
            }
            catch (Exception)
            {

                Label1.Text="La categoria que ingreso ya existe";
                Label1.Visible = true;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoriasMarcas.aspx", false);
        }
    }
}