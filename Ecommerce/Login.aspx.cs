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
                if(usuarioNegocio.Logearse(usuario)==2)
                {
                    
                    lblMensaje.CssClass = "logueo exitoso";
                    Response.Redirect("Default.aspx");
                }
                if(usuarioNegocio.Logearse(usuario) == 1)
                {
                    Session.Add("usuario", usuario);
                    lblMensaje.CssClass = "logueo exitoso";
                    Response.Redirect("Administrador.aspx");
                }
                else
                {
                    lblMensaje.CssClass = "Usuario no existe";
                    Response.Redirect("Error.aspx");
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            
            }
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx", false);
        }
    }
}