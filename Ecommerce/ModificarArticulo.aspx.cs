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
        public bool ConfirmaEliminacion { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ConfirmaEliminacion = false;
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                /*if (Session["usuario"] == null)
                {
                    Response.Redirect("Login.aspx", false);
                }*/
                if (!IsPostBack)
                {
                    List<Imagen> imagenesNuevas = new List<Imagen>();
                    Session.Add("imagenesNuevas", imagenesNuevas);
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
                    if (Request.QueryString["id"] != null && !IsPostBack)
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
                        //txtStock.Text = articulo.stock.ToString();
                        ddlEstado.SelectedValue = articulo.Estado ? "1" : "0";
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
            //txtStock.Text = string.Empty;
        }

        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (txtNombreArticulo.Text.Trim()=="" || txtDescripcion.Text.Trim() == "" || !validarPrecio(txtPrecio.Text))
            {
                txtAdvertencia.Text = string.Empty;
                txtAdvertencia.Text = "Verifique que los campos no esten vacios o sean datos validos";
                txtAdvertencia.Visible = true;
                return;
            }
            List<Imagen> imagenes = (List<Imagen>)(Session["imagenesNuevas"]);
            if (imagenes.Count == 0 && Request.QueryString["id"]==null)
            {
                txtAdvertencia.Text = string.Empty;
                txtAdvertencia.Text = "El articulo nuevo tiene que tener al menos una imagen";
                txtAdvertencia.Visible = true;
                return;
            }

            try
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
                //nuevo.stock = int.Parse(txtStock.Text);
                //nuevo.listaImagenes = new List<Imagen>();
                //Imagen img = new Imagen();
                //img.UrlImagen = txtUrlImagen.Text;
                //nuevo.listaImagenes.Add(img);
                nuevo.listaImagenes = imagenes;
                ImagenNegocio inegocio = new ImagenNegocio();
                if (Request.QueryString["id"] != null)
                {
                    nuevo.idArticulo = int.Parse(Request.QueryString["id"].ToString());
                    negocio.modificarConSP(nuevo);
                    if (imagenes.Count > 0)
                    {
                        foreach(Imagen imagen in imagenes)
                        {
                            inegocio.GuardarImagen(imagen.UrlImagen, nuevo.idArticulo);
                        }
                    }
                }
                else
                {
                    int idArticuloGenerado=negocio.agregar(nuevo);

                    foreach(Imagen imagen in imagenes)
                    {
                        inegocio.GuardarImagen(imagen.UrlImagen, idArticuloGenerado);
                    }

                    Response.Redirect("Administrador2.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
                /*
                txtAdvertencia.Text = string.Empty;
                txtAdvertencia.Text = "Verifique que los campos no esten vacios o sean datos validos";
                txtAdvertencia.Visible = true;*/
            }
        }

        private bool validarPrecio(string precio)
        {
            decimal resultado;
            return decimal.TryParse(precio, out resultado);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                txtAdvertencia.Text = string.Empty;
                return;
            }
            ConfirmaEliminacion = true;
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
            List<Imagen> imagenes = (List<Imagen>)(Session["imagenesNuevas"]);
            Imagen img = new Imagen();
            if (txtUrlImagen.Text.Trim() != "")
            {
                img.UrlImagen = txtUrlImagen.Text;
                imagenes.Add(img);
            }
            Session["imagenesNuevas"]=imagenes;
        }

        protected void btnStock_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                txtAdvertencia.Text = string.Empty;
                txtAdvertencia.Text = "Debe crear el articulo antes de administrar el stock";
                txtAdvertencia.Visible = true;
                return;
            }

            int id = int.Parse(Request.QueryString["id"]);
            Response.Redirect("Stock.aspx?id=" + id, false);
        }

        protected void btnEliminar2_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                return;
            }
            try
            {
                ArticuloNegocio negocio =  new ArticuloNegocio();
                negocio.EliminarArticulo(int.Parse(Request.QueryString["id"]));
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }
    }
}