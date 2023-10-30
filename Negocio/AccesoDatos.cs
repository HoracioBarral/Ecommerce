using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace Negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=Ecommerce; integrated security=true");
            comando = new SqlCommand("");
        }
        public void setConexion(String consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void abrirConexion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }
    }
}
