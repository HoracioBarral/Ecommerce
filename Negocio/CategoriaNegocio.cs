using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace Negocio
{
    public class CategoriaNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        public List<Categoria> listarCategorias()
        {
            List<Categoria> listaCategorias=new List<Categoria>();
            datos.setConexion("");
            try
            {
                datos.abrirConexion();
                Categoria categoria=new Categoria();
                return listaCategorias;
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
