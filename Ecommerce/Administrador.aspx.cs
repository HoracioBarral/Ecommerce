using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Negocio;

namespace Ecommerce
{
    public partial class Administrador : System.Web.UI.Page
    {
        List<Articulo> listadoArticulos;
        public List<Articulo> listaarticulos = new List<Articulo>();
        private ArticuloNegocio articulonegocio = new ArticuloNegocio();
        protected void Page_Load(object sender, EventArgs e)
            
        {
            Usuario usuario = new Usuario();
            if (Session ["usuario"] == null)
            {
                Session.Add("Error", "Debes ser administrador para ingresar");
                Response.Redirect("Login.aspx", false);
            }

            listaarticulos = articulonegocio.listar();
            if (!IsPostBack)
            {
                ArticuloNegocio articulonegocio = new ArticuloNegocio();
                Session.Add("listadoArticulos", articulonegocio.listar());
                Repeater1.DataSource = articulonegocio.listar();
                Repeater1.DataBind();
            }
        }
        protected string GetImageUrl(object dataItem)
        {
            if (dataItem is Articulo articulo && articulo.listaImagenes.Count > 0)
            {
                return articulo.listaImagenes[0].UrlImagen;
            }
            return string.Empty;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            int idArticulo = Convert.ToInt32(((Button)sender).CommandArgument);

            ArticuloNegocio articulonegocio = new ArticuloNegocio();
            Articulo articulo = articulonegocio.buscarPorID(idArticulo);
            if (articulo != null)
            {
                txtNNombreArticulo.Text = articulo.nombreArticulo;
                ViewState["IdArticulo"] = idArticulo;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "abrirModalEditar();", true);
            }
        }

        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            string nuevoNombre = txtNNombreArticulo.Text;

            // Obtén el ID del artículo desde el ViewState (puedes cambiar esto según tu lógica)
            int idArticulo = Convert.ToInt32(ViewState["IdArticulo"]);

            // Crea una instancia de AccesoDatos
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // Configura la consulta UPDATE
                datos.setConexion($"UPDATE Articulos SET NombreArticulo = '{nuevoNombre}' WHERE idArticulo = {idArticulo}");

                // Ejecuta la consulta
                datos.ejecutarAccion();

                // Actualiza la interfaz o realiza otras acciones si es necesario
                // ...

                // Cierra el modal después de guardar cambios
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "cerrarModalEditar();", true);
            }
            catch (Exception ex)
            {
                // Maneja la excepción
                // ...
            }
            finally
            {
                // Cierra la conexión
                datos.cerrarConexion();
            }
        }
    }
}