using dominio;
using Negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        ArticuloNegocio articulNegocio = new ArticuloNegocio();
        private int ObtenerElIdDelArticuloDesdeLaURL()
        {
            int idArticulo = -1;
            if (Request.QueryString["id"] != null)
            {
                if (int.TryParse(Request.QueryString["id"], out idArticulo))
                {
                    // ID válido en la URL.
                }

            }
            return idArticulo;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtenemos el ID del artículo desde la URL
                int idArticulo = ObtenerElIdDelArticuloDesdeLaURL();

                if (idArticulo > 0)
                {
                    ArticuloNegocio articulonegocio = new ArticuloNegocio();
                    Articulo articulo = articulonegocio.buscarPorID(idArticulo);
                    if (articulo != null)
                    {
                       
                        lblNombreArticulo.Text = articulo.nombreArticulo;
                        lblDescripcion.Text = articulo.descripcion;
                        lblCategoria.Text = articulo.categoria.nombreCategoria;
                        lblMarca.Text = articulo.marca.nombreMarca;
                        lblPrecio.Text = articulo.precio.ToString("C2"); // Formatear el precio como moneda
                        
                        ImagenNegocio imagenNegocio = new ImagenNegocio();
                        List<Imagen> imagenes = imagenNegocio.Listar(idArticulo);
                        articulo.listaImagenes.AddRange(imagenes);
                        MostrarImagenes(articulo.listaImagenes);
                        Repeater1.DataSource= imagenes;
                        Repeater1.DataBind();
                        StockNegocio stockNegocio = new StockNegocio();
                        List<StockTalles> stock = stockNegocio.listarPorID(idArticulo);
                        ddlTalles.DataSource= stock;
                        ddlTalles.DataValueField = "talle";
                        ddlTalles.DataTextField = "talle";
                        ddlTalles.DataBind();
                    }
                }
                else
                {
                   
                    
                }
            }
        }




        private void MostrarImagenes(List<Imagen> imagenes)
        {
            Repeater1.DataSource = imagenes;
            Repeater1.DataBind();

        }
        

        protected void ddlTalles_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idArticulo = int.Parse(Request.QueryString["id"]);
            StockNegocio stockNegocio = new StockNegocio();
            List<StockTalles> stock = stockNegocio.listarPorID(idArticulo);
            string talle = ddlTalles.SelectedValue.ToString();
            //Falta el metodo de Stock Negocio que filtre por id y talle
            List<StockTalles> stockFiltrado = stock.FindAll(x => x.talle.Contains(ddlTalles.SelectedValue.ToString()));
            ddlCantidad.DataSource = stockFiltrado;
            ddlCantidad.DataValueField = "idArticulo";
            ddlCantidad.DataTextField = "stock";
            ddlCantidad.DataBind();
        }
    }
}