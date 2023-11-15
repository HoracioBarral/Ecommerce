using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using dominio;

namespace Ecommerce
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
           Usuario usuario = new Usuario();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            try
            {
                usuario.nombreUsuario = Txtusuario.Text;
                usuario.Pass = Txtpass.Text;
                if(usuarioNegocio.Logearse(usuario))
                {
                    Session.Add("usuario", usuario);
                    lblMensaje.CssClass = "logueo exitoso";
                    Response.Redirect("Administrador.aspx");
                    
                }
                else
                {
                    lblMensaje.CssClass = "Datos incorrectos";
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}