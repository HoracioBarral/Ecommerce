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
        public bool Logearse(Usuario usuario)
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


        public bool Registrarse(string nombreUsuario, string pass, int idRol)
        {
            Usuario usuarioNuevo = new Usuario();
            usuarioNuevo.nombreUsuario = nombreUsuario;
            usuarioNuevo.Pass = pass;
            usuarioNuevo.rolUsuario=new RolUsuario();
            usuarioNuevo.rolUsuario.idRol = idRol;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConexion("insert into Usuarios(NombreUsuario,Pass,ID_Rol) output inserted.ID_Usuario values(@usuarionuevo,@pass,2)");
                datos.setearParametro("@usuarionuevo", usuarioNuevo.nombreUsuario);
                datos.setearParametro("@pass", usuarioNuevo.Pass);
                datos.abrirConexion();
                while (datos.Lector.Read())
                {
                    usuarioNuevo.idUsuario = (int)datos.Lector["ID_Usuario"];
                }
                if (usuarioNuevo.idUsuario >0)
                {
                    return true;
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
