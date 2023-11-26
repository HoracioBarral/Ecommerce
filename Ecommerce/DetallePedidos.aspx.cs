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
    public partial class DetallePedidos : System.Web.UI.Page
    {
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"]!=null)
            {
                id = int.Parse(Request.QueryString["id"]);
            }
            if (!IsPostBack)
            {
                List<DetallePedido> detallePedidos = new List<DetallePedido>();
                PedidoNegocio pedidoNegocio = new PedidoNegocio();
                detallePedidos = pedidoNegocio.listarConInnerJoin();
                List<DetallePedido> listaFiltrada;
                listaFiltrada = detallePedidos.FindAll(x => x.idPedido == id);
                dgvDetalles.DataSource=listaFiltrada;
                dgvDetalles.DataBind();
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoPedidos2.aspx", false);
        }
    }
}