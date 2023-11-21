using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using System.Drawing;

namespace Ecommerce
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            if (TxtNombreUser.Text.Contains(" ") || TxtNombreUser.Text.Length<5)
            {
                Label1.Visible = true;
                Label1.Text = "El nombre de usuario debe tener al menos 4 caracteres y/o sin espaciones en blanco";
                return;
            }
            if (Txtpass.Text.Contains(" ") || Txtpass.Text.Length<5)
            {
                Label1.Visible = true;
                Label1.Text = "La contraseña debe tener al menos cuatro caracteres y/o sin espaciones en blanco";
                return;
            }
            try
            {
                Usuario nuevoUsuario = new Usuario();
                nuevoUsuario.nombreUsuario = TxtNombreUser.Text;
                nuevoUsuario.Pass = Txtpass.Text;
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                if (usuarioNegocio.Registrarse(nuevoUsuario)){
                    Label1.Visible = true;
                    Label1.Text = "Registro Exitoso";
                }
                else
                {
                    Label1.Visible = true;
                    Label1.Text = "El nombre de usuario ya existe";
                }
                TxtNombreUser.Text = string.Empty;
                Txtpass.Text = string.Empty;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}