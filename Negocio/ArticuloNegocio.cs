using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            // MarcaNegocio marcaNegocio = new MarcaNegocio();
            //CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            // ImagenNegocio imagenNegocio = new ImagenNegocio();

            try
            {
                datos.setConexion("SELECT A.ID_Articulo, A.NombreArticulo, A.Descripcion, C.NombreCategoria AS Categoria, A.Precio, A.stock \r\nFROM Articulos A, Categorias C\r\nWHERE C.ID_Categoria = A.ID_Categoria");
                datos.abrirConexion();

                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.idArticulo = (int)datos.Lector["ID_Articulo"];
                    articulo.nombreArticulo = (string)datos.Lector["NombreArticulo"];
                    articulo.descripcion = (string)datos.Lector["Descripcion"];
                    articulo.categoria = new Categoria();
                    articulo.categoria.nombreCategoria = (string)datos.Lector["Categoria"];
                    articulo.precio = (decimal)datos.Lector["Precio"];
                    articulo.stock = (int)datos.Lector["stock"];
                    lista.Add(articulo);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
