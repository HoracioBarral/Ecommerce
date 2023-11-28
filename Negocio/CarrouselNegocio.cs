using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CarrouselNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        public List<Carrousel> listarOfertas()
        {
            List<Carrousel> listarCarrousel = new List<Carrousel>();
            datos.setConexion("SELECT * FROM Carrousel");
            try
            {
                datos.abrirConexion();
                while (datos.Lector.Read())
                {
                    Carrousel car = new Carrousel();
                    car.idCarrousel = (int)datos.Lector["ID_Registro"];
                    car.textoCarrousel = (string)datos.Lector["Texto"];
                    listarCarrousel.Add(car);
                }
                return listarCarrousel;
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
