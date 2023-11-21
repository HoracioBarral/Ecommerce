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
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                if (Session["usuario"] == null)
                {
                    Response.Redirect("Login.aspx", false);
                }
                if (!IsPostBack)
                {
                    CategoriaNegocio cat = new CategoriaNegocio();
                    List<Categoria> listaC = cat.listarCategorias();
                    MarcaNegocio mar = new MarcaNegocio();
                    List<Marca> listaM = mar.listarMarcas();
                    ddlCategoria.DataSource = listaC;
                    ddlCategoria.DataValueField = "idCategoria";
                    ddlCategoria.DataTextField = "nombreCategoria";
                    ddlCategoria.DataBind();
                    ddlMarca.DataSource = listaM;
                    ddlMarca.DataValueField = "idMarca";
                    ddlMarca.DataTextField = "nombreMArca";
                    ddlMarca.DataBind();
                    if (Request.QueryString["nuevo"] == "true")
                    {
                        
                        LimpiarControles();
                    }
                    if (Request.QueryString["id"] != null&& !IsPostBack)
                    {

                        int id = int.Parse(Request.QueryString["id"]);
                        ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                        Articulo articulo = new Articulo();
                        articulo = articuloNegocio.buscarPorID(id);
                        txtNombreArticulo.Text = articulo.nombreArticulo;
                        txtDescripcion.Text = articulo.descripcion;
                        ddlCategoria.SelectedValue = articulo.categoria.idCategoria.ToString();
                        ddlMarca.SelectedValue = articulo.marca.idMarca.ToString();
                        txtPrecio.Text = articulo.precio.ToString();
                        txtStock.Text = articulo.stock.ToString();
                        ImagenNegocio imagenNegocio = new ImagenNegocio();
                        List<Imagen> imagenes = imagenNegocio.Listar(id);
                        RepeaterImagenes.DataSource = imagenes;
                        RepeaterImagenes.DataBind();

                    }
                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
                Response.Redirect("Error.aspx");
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
            Articulo nuevo = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();
            nuevo.nombreArticulo = txtNombreArticulo.Text;
            nuevo.descripcion = txtDescripcion.Text;
            nuevo.categoria = new Categoria();
            nuevo.categoria.idCategoria = int.Parse(ddlCategoria.SelectedValue);
            nuevo.marca = new Marca();
            nuevo.marca.idMarca = int.Parse(ddlMarca.SelectedValue);
            nuevo.precio = decimal.Parse(txtPrecio.Text);
            nuevo.stock = int.Parse(txtStock.Text);
            nuevo.listaImagenes = new List<Imagen>();
            Imagen img = new Imagen();
            ImagenNegocio inegocio = new ImagenNegocio();
            img.UrlImagen = txtUrlImagen.Text;
            nuevo.listaImagenes.Add(img);
            negocio.agregar(nuevo);

            if (Request.QueryString["id"] != null)
            {
                nuevo.idArticulo = int.Parse(Request.QueryString["id"].ToString());
                negocio.modificarConSP(nuevo);

            }
            else
            {
            }
                int idArticuloGenerado = nuevo.idArticulo;

                inegocio.GuardarImagen(txtUrlImagen.Text, idArticuloGenerado);

                Response.Redirect("Administrador2.aspx");

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
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            int id = int.Parse(Request.QueryString["id"].ToString());
            imagenNegocio.EliminarImagen(id, url);
            RepeaterImagenes.DataSource = imagenNegocio.Listar(id);
            RepeaterImagenes.DataBind();
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            Image1.ImageUrl = txtUrlImagen.Text;
        }

        protected void btnAgregarImagen_Click(object sender, EventArgs e)
        {

        }
    }
}