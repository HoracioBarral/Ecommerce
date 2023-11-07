using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace Negocio
{
    public class MarcaNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        public List<Marca> listarMarcas()
        {
            List<Marca> listaMarcas = new List<Marca>();
            datos.setConexion("SELECT * FROM Marcas");
            try
            {
                datos.abrirConexion();
                while (datos.Lector.Read())
                {
                   Marca marca = new Marca();
                    marca.idMarca = (int)datos.Lector["ID_Marca"];
                    marca.nombreMarca = (string)datos.Lector["NombreMarca"];
                    listaMarcas.Add(marca);
                }
                return listaMarcas;
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
