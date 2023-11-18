using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace Ecommerce
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Usuario nuevoUsuario = new Usuario();
            try
            {
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
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}