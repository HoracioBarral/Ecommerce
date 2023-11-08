using dominio;
using System;
using System.Collections;
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
                datos.setConexion("SELECT A.ID_Articulo,A.NombreArticulo,A.Descripcion,C.NombreCategoria AS Categoria,M.NombreMarca AS Marca,A.Precio,A.Stock,STRING_AGG(I.Url_Imagen, ';') AS Imagenes\r\nFROM Articulos A INNER JOIN Categorias C ON C.ID_Categoria = A.ID_Categoria INNER JOIN Marcas M ON M.ID_Marca = A.ID_Marca LEFT JOIN Imagenes I ON I.ID_Articulo = A.ID_Articulo\r\nGROUP BY A.ID_Articulo, A.NombreArticulo, A.Descripcion, C.NombreCategoria, M.NombreMarca, A.Precio, A.Stock");
                datos.abrirConexion();

                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.idArticulo = (int)datos.Lector["ID_Articulo"];
                    articulo.nombreArticulo = (string)datos.Lector["NombreArticulo"];
                    articulo.descripcion = (string)datos.Lector["Descripcion"];
                    articulo.categoria = new Categoria();
                    articulo.categoria.nombreCategoria = (string)datos.Lector["Categoria"];
                    articulo.marca = new Marca();
                    articulo.marca.nombreMarca = (string)datos.Lector["Marca"];
                    articulo.precio = (decimal)datos.Lector["Precio"];
                    articulo.stock = (int)datos.Lector["stock"];
                    articulo.listaImagenes = new List<Imagen>();
                    if (!datos.Lector.IsDBNull(datos.Lector.GetOrdinal("Imagenes")))
                    {
                        Imagen imagen = new Imagen();
                        imagen.UrlImagen = (string)datos.Lector["Imagenes"];
                        articulo.listaImagenes.Add(imagen);
                    }
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
        public Articulo buscarPorID(int Id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConexion("SELECT A.ID_Articulo, A.NombreArticulo, A.Descripcion, C.NombreCategoria AS Categoria, M.NombreMarca AS Marca, A.Precio, A.Stock FROM Articulos A INNER JOIN Categorias C ON C.ID_Categoria = A.ID_Categoria INNER JOIN Marcas M ON M.ID_Marca = A.ID_Marca WHERE A.ID_Articulo = @ID");
                datos.setearParametro("@ID", Id);
                datos.abrirConexion();

                if (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.idArticulo = (int)datos.Lector["ID_Articulo"];
                    articulo.nombreArticulo = (string)datos.Lector["NombreArticulo"];
                    articulo.descripcion = (string)datos.Lector["Descripcion"];
                    articulo.categoria = new Categoria();
                    articulo.categoria.nombreCategoria = (string)datos.Lector["Categoria"];
                    articulo.marca = new Marca();
                    articulo.marca.nombreMarca = (string)datos.Lector["Marca"];
                    articulo.precio = (decimal)datos.Lector["Precio"];
                    articulo.stock = (int)datos.Lector["Stock"];
                    articulo.listaImagenes = new List<Imagen>();

                    return articulo;
                }

                // Si no se encontró un artículo con el ID especificado, devolvemos null.
                return null;
            }
            catch (Exception ex)
            {
                // Manejar la excepción (registro, notificación, etc.) o lanzarla nuevamente si es necesario.
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}
