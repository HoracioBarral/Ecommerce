using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class Stock : System.Web.UI.Page
    {
        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                id= int.Parse(Request.QueryString["id"]);
            }
            if (!IsPostBack)
            {
                StockNegocio stockNegocio = new StockNegocio();
                dgvStock.DataSource = stockNegocio.listarPorID(id);
                dgvStock.DataBind();
            }
        }

        protected void btnAltaStock_Click(object sender, EventArgs e)
        {
            //int id = int.Parse(Request.QueryString["id"]);
            Response.Redirect("AdmStock.aspx?id="+id,false);
        }
    }
}