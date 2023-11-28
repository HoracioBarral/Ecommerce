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
        public List<Carrousel> listarCarrousel()
        {
            List<Carrousel> listaCarrousel = new List<Carrousel>();
            datos.setConexion("SELECT * FROM Carrousel");
            try
            {
                datos.abrirConexion();
                while (datos.Lector.Read())
                {
                    Carrousel car = new Carrousel();
                    car.idCarrousel = (int)datos.Lector["idCarrousel"];
                    car.Texto = (string)datos.Lector["Texto"];
                    listaCarrousel.Add(car);
                }
                return listaCarrousel;
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
        public void agregarTexCarr(string nuevoText)
        {
            AccesoDatos datos2 = new AccesoDatos();
            try
            {
                datos2.setConexion("insert into Carrousel(Texto) values(@nuevoText)");
                datos2.setearParametro("@nuevoText", nuevoText);
                datos2.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos2.cerrarConexion();
            }
        }
        public void modificarCategoria(int idCarrousel, string Texto)
        {
            AccesoDatos datos2 = new AccesoDatos();
            try
            {
                datos2.setConexion("update Carrousel set Texto=@Texto where idCarrousel=@idCarrousel");
                datos2.setearParametro("@Texto", Texto);
                datos2.setearParametro("@idCarrousel", idCarrousel);
                datos2.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos2.cerrarConexion(); }
        }
        public Carrousel ObtenerTextoPorID(int id)
        {
            try
            {
                datos.setConexion("select * from Carrousel where idCarrousel=@id");
                datos.setearParametro("@id", id);
                datos.abrirConexion();
                while (datos.Lector.Read())
                {
                    Carrousel carrousel = new Carrousel();
                    carrousel.idCarrousel = (int)datos.Lector["idCarrousel"];
                    carrousel.Texto = (string)datos.Lector["Texto"];
                    return carrousel;
                }
                return null;
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
