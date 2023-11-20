using dominio;
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
    public partial class ModificarArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            if(Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx", false);
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["nuevo"] == "true")
                {
                    CategoriaNegocio cat = new CategoriaNegocio();
                    List<Categoria> listaC = cat.listarCategorias();
                    MarcaNegocio mar = new MarcaNegocio();
                    List<Marca> listaM = mar.listarMarcas();
                    ddlCategoria.DataSource = listaC;
                    ddlCategoria.DataValueField = "idCategoria";
                    ddlCategoria.DataTextField = "nombreCategoria";
                    ddlCategoria.DataBind();
                    ddlMarca.DataSource =listaM;
                    ddlMarca.DataValueField = "idMarca";
                    ddlMarca.DataTextField = "nombreMArca";
                    ddlMarca.DataBind();
                    // Lógica para cargar un nuevo artículo (puede ser limpiar los controles, por ejemplo)
                    LimpiarControles();
                }
                else if (Request.QueryString["id"] != null )
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    List<Articulo> lista = (List<Articulo>)(Session["listaArticulos"]);
                    Articulo articulo = lista.Find(a => a.idArticulo == id);
                    txtNombreArticulo.Text = articulo.nombreArticulo;
                    txtDescripcion.Text = articulo.descripcion;
                    ddlCategoria.Text = articulo.categoria.nombreCategoria;
                    ddlMarca.Text = articulo.marca.nombreMarca;
                    txtPrecio.Text = articulo.precio.ToString();
                    txtStock.Text = articulo.stock.ToString();
                    ImagenNegocio imagenNegocio = new ImagenNegocio();
                    List<Imagen> imagenes = imagenNegocio.Listar(id);
                    RepeaterImagenes.DataSource = imagenes;
                    RepeaterImagenes.DataBind();
                }
            }
        }
        private void LimpiarControles()
        {
            txtNombreArticulo.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtStock.Text = string.Empty;
        }

        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("Administrador2.aspx");
        }

        protected void btnEliminarImagen_Click(object sender, EventArgs e)
        {
            Button btnStringUrl = (Button)sender;
            string url=btnStringUrl.CommandArgument;
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            Image1.ImageUrl = txtUrlImagen.Text;
        }
    }
}