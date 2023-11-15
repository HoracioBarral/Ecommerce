using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public bool Logearse(Usuario usuario )
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConexion("SELECT ID_Usuario, Nombre, Apellido, Mail, Telefono, FechaNacimiento, ID_Rol,1 FROM Usuarios WHERE NombreUsuario=@nombreUsuario and Pass=@pass");
                datos.setearParametro("@nombreUsuario", usuario.nombreUsuario);
                datos.setearParametro("@pass", usuario.Pass);
                datos.abrirConexion();
                while (datos.Lector.Read())
                {
                    if (usuario.rolUsuario == null)
                    {
                        usuario.rolUsuario = new RolUsuario();
                    }

                    usuario.rolUsuario.idRol = (int)datos.Lector["ID_Rol"];

                    // Comprobar el rol aquí, ajusta según tus necesidades
                    if (usuario.rolUsuario.idRol == 2)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }

        }
    }
}
