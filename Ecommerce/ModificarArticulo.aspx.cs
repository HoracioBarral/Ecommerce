using dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
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
            if (Request.QueryString["id"] == null && Request.QueryString["nuevo"]==null)
            {
                Response.Redirect("Administrador2.aspx");
            }
            ConfirmaEliminacion = false;
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
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
        }

        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (txtNombreArticulo.Text.Trim() == "" || txtDescripcion.Text.Trim() == "" || !validarPrecio(txtPrecio.Text))
            {
                txtAdvertencia.Text = string.Empty;
                txtAdvertencia.Text = "Verifique que los campos no esten vacios o sean datos validos";
                txtAdvertencia.Visible = true;
                return;
            }

            List<Imagen> imagenes = (List<Imagen>)(Session["imagenesNuevas"]);
            if (imagenes.Count == 0 && Request.QueryString["nuevo"] == "true")
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
                nuevo.Estado = ddlEstado.SelectedValue == "1";
                nuevo.precio = decimal.Parse(txtPrecio.Text);
                nuevo.listaImagenes = imagenes;
                ImagenNegocio inegocio = new ImagenNegocio();
                if (Request.QueryString["id"] != null)
                {
                    nuevo.idArticulo = int.Parse(Request.QueryString["id"].ToString());
                    if (imagenes.Count > 0)
                    {
                        foreach (Imagen imagen in imagenes)
                        {
                            inegocio.GuardarImagen(imagen.UrlImagen, nuevo.idArticulo);
                        }
                    }
                    else
                    {
                        if (Session["imagenesEliminadas"]!=null)
                        {
                            List<Imagen> imagenesEliminadas = (List<Imagen>)Session["imagenesEliminadas"];
                            foreach (Imagen imagen in imagenesEliminadas)
                            {
                                inegocio.EliminarImagen(imagen.idArticulo, imagen.UrlImagen);
                            }
                        }
                    }
                    negocio.modificarConSP(nuevo);
                }
                else
                {
                    int idArticuloGenerado = negocio.agregar(nuevo);

                    foreach (Imagen imagen in imagenes)
                    {
                        imagen.idImagen=idArticuloGenerado;
                        inegocio.GuardarImagen(imagen.UrlImagen, idArticuloGenerado);
                    }
                }
                Session.Remove("imagenesNuevas");
                Session.Remove("imagenesEliminadas");
                Session.Remove("imagenesSinEliminar");
                ScriptManager.RegisterStartupScript(this, GetType(), "showMessage", "showMessage();", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool validarPrecio(string precio)
        {
            if (!string.IsNullOrWhiteSpace(precio) && decimal.TryParse(precio, out decimal numero))
            {
                if(numero > 0)
                {
                    return true;
                }
            }
            return false; 
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
            Session.Remove("imagenesNuevas");
            Session.Remove("imagenesEliminadas");
            Session.Remove("imagenesSinEliminar");
            Response.Redirect("Administrador2.aspx");
        }

        protected void btnEliminarImagen_Click(object sender, EventArgs e)
        {
            Button btnStringUrl = (Button)sender;
            string url=btnStringUrl.CommandArgument;
            int id = int.Parse(Request.QueryString["id"].ToString());
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            List<Imagen> cantidadImagenesenDB = imagenNegocio.Listar(id);
            List<Imagen> imagenesSinEliminar;
            if (cantidadImagenesenDB.Count == 1)
            {
                txtAdvertencia.Text = string.Empty;
                txtAdvertencia.Text = "El articulo tiene que tener al menos una imagen";
                txtAdvertencia.Visible = true;
                Session.Remove("imagenesEliminadas");
                return;
            }
            List<Imagen> imagenesEliminadas = new List<Imagen>();
            if (Session["imagenesEliminadas"] == null)
            {
                Session.Add("imagenesEliminadas", imagenesEliminadas);
                imagenesSinEliminar = imagenNegocio.Listar(id);
                Session.Add("imagenesSinEliminar", imagenesSinEliminar);
            }
            else
            {
                imagenesEliminadas = (List<Imagen>)Session["imagenesEliminadas"];
                imagenesSinEliminar = (List<Imagen>)Session["imagenesSinEliminar"];
            }
            Imagen imagen = new Imagen();
            imagen.idArticulo= id;
            imagen.UrlImagen = url;
            imagenesEliminadas.Add(imagen);
            if (imagenesEliminadas.Count == cantidadImagenesenDB.Count)
            {
                txtAdvertencia.Text = string.Empty;
                txtAdvertencia.Text = "El articulo tiene que tener al menos una imagen";
                txtAdvertencia.Visible = true;
                int indice = imagenesEliminadas.Count;
                imagenesEliminadas.RemoveAt(indice-1);
                Session["imagenesEliminadas"] = imagenesEliminadas;
                return;
            }
            imagenesSinEliminar.RemoveAll(x => x.idArticulo == id && x.UrlImagen == url);
            Session["imagenesEliminadas"] = imagenesEliminadas;
            RepeaterImagenes.DataSource = imagenesSinEliminar;
            RepeaterImagenes.DataBind();
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            Image1.ImageUrl = txtUrlImagen.Text;
        }

        protected void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            if (txtUrlImagen.Text.Trim() == "")
            {
                txtAdvertencia.Text = string.Empty;
                txtAdvertencia.Text = "El campo URL no puede estar vacio";
                txtAdvertencia.Visible = true;
                return;
            }
            List<Imagen> imagenes = (List<Imagen>)(Session["imagenesNuevas"]);
            Imagen img = new Imagen();
            img.UrlImagen = txtUrlImagen.Text;
            imagenes.Add(img);
            Session["imagenesNuevas"]=imagenes;
            txtAdvertencia.Text = string.Empty;
            txtAdvertencia.Text = "Imagen Agregada con exito";
            txtAdvertencia.Visible = true;
            txtUrlImagen.Text = string.Empty;
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showMessage", "showMessage();", true);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }
    }
}