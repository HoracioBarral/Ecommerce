using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            try
            {
                if(usuarioNegocio.Registrarse(TxtNombreUser.Text, Txtpass.Text, 2)){
                    Label1.Visible = true;
                    Label1.Text = "Registro Exitoso";
                }
                else
                {
                    Label1.Visible = true;
                    Label1.Text = "No se pudo registrar";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}