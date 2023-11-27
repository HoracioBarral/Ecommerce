using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class UsuariosRegistrados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            if (!IsPostBack)
            {
                dgvUsuarios.DataSource = usuarioNegocio.Listar();
                dgvUsuarios.DataBind();
            }
        }

        protected void dgvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)(dgvUsuarios.SelectedDataKey.Value);
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            usuarioNegocio.resetContraseña(id);
            Label1.Text = "Contraseña restablecida, la nueva pass es 'nuevaClave'";
            Label1.Visible = true;
        }
    }
}