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
            if (Txtusuario.Text.Trim()=="")
            {
                Label1.Visible = true;
                Label1.Text = "Debe ingresar nombre de usuario";
                return;
            }
            if (Txtpass.Text.Trim() == "")
            {
                Label1.Visible = true;
                Label1.Text = "Debe ingresar contraseña";
                return;
            }
            Usuario usuario = new Usuario();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            try
            {
                usuario.nombreUsuario = Txtusuario.Text.ToLower();
                usuario.Pass = Txtpass.Text;
                if(usuarioNegocio.Logearse(usuario)==2)
                {
                    Session.Add("usuario", usuario);
                    lblMensaje.CssClass = "logueo exitoso";
                    Response.Redirect("Default.aspx");
                }
                if(usuarioNegocio.Logearse(usuario) == 1)
                {
                    Session.Add("usuario", usuario);
                    lblMensaje.CssClass = "logueo exitoso";
                    Response.Redirect("Administrador2.aspx");
                }
                else
                {
                    Label1.Visible = true;
                    Label1.Text = "Estos datos no son correctos. ¿Chequeaste que estén bien escritos?";
                    Txtpass.Text = string.Empty;
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

        protected void lnkNuevaClave_Click(object sender, EventArgs e)
        {
            if (Txtusuario.Text.Trim() == "")
            {
                Label1.Visible = true;
                Label1.Text = "Debe ingresar nombre de usuario";
                return;
            }
            Usuario usuario = new Usuario();
            usuario.nombreUsuario = Txtusuario.Text.ToLower();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            if (!usuarioNegocio.existeUsuario(usuario.nombreUsuario))
            {
                Label1.Text = string.Empty;
                Label1.Visible = true;
                Label1.Text = "El nombre de usuario no existe";
                return;
            }
            usuarioNegocio.resetContraseña2(usuario.nombreUsuario);
            ServicioEmail mail = new ServicioEmail();
            mail.armarCorreo(usuario.nombreUsuario, "Clave Reseteada", "El nombre de su nueva clave es nuevaClave");
            mail.enviarMail();
            Label1.Text = string.Empty;
            Label1.Visible = true;
            Label1.Text = "Se le envio la clave nueva a su direccion de correo";
        }
    }
}