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
                        lblPrecio.Text = articulo.precio.ToString("C"); // Formatear el precio como moneda
                        lblStock.Text = articulo.stock.ToString();
                        
                        ImagenNegocio imagenNegocio = new ImagenNegocio();
                        List<Imagen> imagenes = imagenNegocio.Listar(idArticulo);
                        articulo.listaImagenes.AddRange(imagenes);
                        MostrarImagenes(articulo.listaImagenes);

                    }
                }
                else
                {
                   
                    
                }
            }
        }




        private void MostrarImagenes(List<Imagen> imagenes)
        {
            foreach (Imagen imagen in imagenes)
            {
                string imageUrl = imagen.UrlImagen;

                
                Image img = new Image();
                img.ImageUrl = imageUrl;
                img.CssClass = "img-fluid"; 
                img.AlternateText = "Imagen del artículo";

                
                divImagenes.Controls.Add(img);
                
            }
        }

    }
}