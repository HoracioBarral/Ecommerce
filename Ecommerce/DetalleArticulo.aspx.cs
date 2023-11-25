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
                    if (Session["usuario"] == null)
                    {
                        btnCarrito.Visible = false;
                        lblAdvertencia.Visible = true;
                    }

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
                        List<StockTalles> stockFiltrado = stock.FindAll(x => x.stock > 0);
                        ddlTalles.SelectedIndex = 0;
                        llenarddlCantidad();
                        ddlTalles.DataSource = stockFiltrado;
                        ddlTalles.DataValueField = "talle";
                        ddlTalles.DataTextField = "talle";
                        ddlTalles.DataBind();
                    }
                }
                else
                {
                    Response.Redirect("Productos.aspx", false); 
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
            ddlCantidad.Items.Clear();
            llenarddlCantidad();
        }

        private void llenarddlCantidad()
        {
            StockNegocio stockNegocio = new StockNegocio();
            List<StockTalles> stock = stockNegocio.listarPorID(int.Parse(Request.QueryString["id"]));
            List<StockTalles> stockFiltrado = stock.FindAll(x => x.talle.Contains(ddlTalles.SelectedValue.ToString()) && x.stock>0);
            if (stockFiltrado.Count==0)
            {
                btnCarrito.Visible = false;
                lblAdvertencia.Text = "Sin stock";
                lblAdvertencia.Visible = true;
                return;
            }
            for (int i = 0; i < stockFiltrado[0].stock; i++)
            {
                ddlCantidad.Items.Add((i + 1).ToString());
            }
        }

        protected void btnCarrito_Click(object sender, EventArgs e)
        {
            int cantidad = int.Parse(ddlCantidad.SelectedValue);
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            int id = int.Parse(Request.QueryString["id"]);
            Articulo articulo = articuloNegocio.buscarPorID(id);
            articulo.cantidad = cantidad;
            articulo.precio = articulo.precio * cantidad;
            string talle = ddlTalles.SelectedValue.ToString();
            articulo.talle = talle;
            Usuario usuario = (Usuario)(Session["usuario"]);
            //genera un idPedido para insertar en la tabla DetallePedidos
            if (Session["idPedido"]==null)
            {
                int idPedido = articulNegocio.generarNumPedido(articulo, usuario.idUsuario);
                articulo.numeroPedido = idPedido;
                Session.Add("idPedido", idPedido);
            }
            List<Articulo> carrito = (List<Articulo>)Session["Carrito"];
            carrito.Add(articulo);
            //Actualiza el stock segun lo agregado al carrito
            StockNegocio stock = new StockNegocio();
            stock.modificarStock(id,talle,cantidad,false);
            articuloNegocio.insertarDetallePedido(articulo, (int)(Session["idPedido"]));
            Response.Redirect("Carrito.aspx", false);
        }
    }
}