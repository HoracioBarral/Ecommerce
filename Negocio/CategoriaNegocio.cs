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
            datos.setConexion("select * from vw_listarCategorias");
            try
            {
                datos.abrirConexion();
                while(datos.Lector.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.idCategoria = (int)datos.Lector["ID_Categoria"];
                    categoria.nombreCategoria = (string)datos.Lector["NombreCategoria"];
                    listaCategorias.Add(categoria);
                }
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
