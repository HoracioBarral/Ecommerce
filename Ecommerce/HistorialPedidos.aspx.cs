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
    public partial class HistorialPedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            Usuario usuario = (Usuario)(Session["usuario"]);
            if (!IsPostBack)
            {
                PedidoNegocio pedidoNegocio = new PedidoNegocio();
                List<Pedido> pedidos = new List<Pedido>();
                pedidos = pedidoNegocio.listar();
                pedidos = pedidos.FindAll(x => (x.estado == 2 || x.estado==3) && x.idUsuario==usuario.idUsuario);
                dgvPedidos.DataSource = pedidos;
                dgvPedidos.DataBind();
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx", false);
        }
    }
}