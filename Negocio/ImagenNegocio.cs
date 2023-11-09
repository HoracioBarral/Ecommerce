using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ImagenNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        public List <Imagen> Listar(int id)
        {
            List<Imagen> lista = new List<Imagen>();
            datos.setConexion("SELECT * FROM IMAGENES WHERE ID_Articulo = @idArticulo");
            datos.setearParametro("@idArticulo", id);
            datos.abrirConexion();
            try
            {

            while (datos.Lector.Read())
            {
                Imagen imagen = new Imagen();
                imagen.idImagen = datos.Lector.GetInt32(0);
                imagen.idArticulo = datos.Lector.GetInt32(datos.Lector.GetOrdinal("ID_Articulo"));
                    imagen.UrlImagen= (string)datos.Lector["Url_Imagen"];

                    lista.Add(imagen);
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
