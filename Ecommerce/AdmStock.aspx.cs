using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class AdmStock : System.Web.UI.Page
    {
        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                id = int.Parse(Request.QueryString["id"]);
            }
              
            if (!IsPostBack)
            {
                ddlTalle.Items.Add("XS");
                ddlTalle.Items.Add("S");
                ddlTalle.Items.Add("M");
                ddlTalle.Items.Add("L");
                ddlTalle.Items.Add("XL");
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string talle = ddlTalle.SelectedValue.ToString();
            if (ValidarNumero(txtCantidad.Text.ToString()))
            {
                int cantidad = int.Parse(txtCantidad.Text.ToString());
                StockNegocio stockNegocio = new StockNegocio();
                stockNegocio.insertarStock(talle,cantidad,id);
            }
        }

        private bool ValidarNumero(string cant)
        {
            int resultado;
            return int.TryParse(cant, out resultado);
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Stock.aspx?id="+id, false);
        }

        protected void btnAceptar_Click1(object sender, EventArgs e)
        {
            string talle = ddlTalle.SelectedValue.ToString();
            if (ValidarNumero(txtCantidad.Text.ToString()))
            {
                int cantidad = int.Parse(txtCantidad.Text.ToString());
                StockNegocio stockNegocio = new StockNegocio();
                stockNegocio.insertarStock(talle, cantidad, id);
            }
        }
    }
}