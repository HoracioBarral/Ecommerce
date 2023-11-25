using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using System.Collections;

namespace Ecommerce
{
    public partial class AdmStock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id;
            if (Request.QueryString["id"] != null)
            {
                id = int.Parse(Request.QueryString["id"]);
            }
            else Response.Redirect("Administrador2.aspx", false);
            if (!IsPostBack)
            {
                ddlTalle.Items.Add("XS");
                ddlTalle.Items.Add("S");
                ddlTalle.Items.Add("M");
                ddlTalle.Items.Add("L");
                ddlTalle.Items.Add("XL");
                if (Session["talle"] != null)
                {
                    id = int.Parse(Request.QueryString["id"]);
                    StockNegocio stockNegocio = new StockNegocio();
                    List<StockTalles> stockTalles = stockNegocio.listarPorID(id);
                    string talle = (string)(Session["talle"]);
                    List<StockTalles> stockFiltrado = stockTalles.FindAll(x => x.talle.Contains(talle));
                    txtCantidad.Text = stockFiltrado[0].stock.ToString();
                    ListItem seleccion= ddlTalle.Items.FindByText(talle);
                    seleccion.Selected = true;
                    ddlTalle.Enabled = false;
                }
            }
        }

        
        private bool ValidarNumero(string cant)
        {
            int resultado;
            return int.TryParse(cant, out resultado);
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            Response.Redirect("Stock.aspx?id="+id, false);
        }


        protected void btnAceptar_Click2(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            StockNegocio stockNegocio = new StockNegocio();
            int cantidad;
            if (txtCantidad.Text.Trim() == "")
            {
                txtAdvertencia.Text = string.Empty;
                txtAdvertencia.Text = "El campo no puede estar en blanco";
                txtAdvertencia.Visible = true;
                return;
            }
            if (ValidarNumero(txtCantidad.Text.ToString()))
            {
                cantidad = int.Parse(txtCantidad.Text.ToString());
            }
            else
            {
                return;
            }
            if (cantidad <= 0)
            {
                txtAdvertencia.Text = string.Empty;
                txtAdvertencia.Text = "El numero debe ser mayor a cero y entero";
                txtAdvertencia.Visible = true;
                return;
            }

            try
            {
                if (Session["talle"] == null)
                {
                    string talle = ddlTalle.SelectedValue.ToString();
                    stockNegocio.insertarStock(talle, cantidad, id);
                }
                else
                {
                    string talle = (Session["talle"]).ToString();
                    stockNegocio.actualizarStock(id, talle, cantidad);
                }
            }
            catch (Exception)
            {   
                txtAdvertencia.Text = string.Empty;
                txtAdvertencia.Text = "Ya hay una fila con el mismo talle";
                txtAdvertencia.Visible = true;
                return;
            }
            Response.Redirect("Stock.aspx?id=" + id, false);
        }
    }
}