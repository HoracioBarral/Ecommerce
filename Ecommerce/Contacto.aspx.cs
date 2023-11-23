using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class Contacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviarMensaje_Click(object sender, EventArgs e)
        {
            if (txtMail.Text.Trim() == "" || txtAsunto.Text.Trim() == "" || txtMensaje.Text.Trim() == "")
            {
                //Label1.Visible = true;
                //Label1.Text = "Verifique que no haya casilleros en blanco";
                return;
            }
            else
            {
                ServicioEmail servicioEmail = new ServicioEmail();
                servicioEmail.armarCorreo(txtMail.Text, txtAsunto.Text, txtMensaje.Text);
                servicioEmail.enviarMail();
            }
        }
    }
}