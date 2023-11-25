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
    public partial class AdminMarcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null && !IsPostBack)
            {
                MarcaNegocio marcanegocio = new MarcaNegocio();
                Marca marca = marcanegocio.listarMarcaPorId(int.Parse(Request.QueryString["id"]));
                txtMarca.Text = marca.nombreMarca;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMarca.Text.Trim() == "")
                {
                    Label1.Visible = true;
                    Label1.Text = "No puede Ingresar la Marca en Blanco";
                    return;
                }
                string marca = txtMarca.Text;
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                if (Request.QueryString["id"] != null)
                {
                    marcaNegocio.modificarMarca(int.Parse(Request.QueryString["id"]), txtMarca.Text);
                }
                else
                    marcaNegocio.agregarMarca(txtMarca.Text);
                Response.Redirect("CategoriasMarcas.aspx", false);
            }
            catch (Exception)
            {

                Label1.Text="La marca que ingreso ya existe";
                Label1.Visible = true;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoriasMarcas.aspx", false);
        }
    }
}