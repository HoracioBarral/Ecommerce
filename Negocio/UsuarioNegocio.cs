﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public Usuario usuario1 { get; set; }
        public UsuarioNegocio(Usuario usuario){
            usuario1 = usuario;
        }

        public int Logearse(Usuario usuario)
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
                    if (usuario.rolUsuario.idRol > 0)
                    {
                        if (usuario.rolUsuario.idRol == 1)
                        { return 1; }
                        else { return 2; }
                    }
                }
                return -1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }

        }


        public bool Registrarse(int idRol=2)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (!existeUsuario())
                {
                    datos.setConexion("insert into Usuarios(NombreUsuario,Pass,ID_Rol) output inserted.ID_Usuario values(@usuarionuevo,@pass,@idRol)");
                    datos.setearParametro("@usuarionuevo", usuario1.nombreUsuario);
                    datos.setearParametro("@pass", usuario1.Pass);
                    datos.setearParametro("@idRol", idRol);
                    datos.abrirConexion();
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

        public bool existeUsuario()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConexion("select COUNT(NombreUsuario) as 'Cantidad' from usuarios where NombreUsuario like @nombreUsuario");
                datos.setearParametro("@nombreUsuario", usuario1.nombreUsuario);
                datos.abrirConexion();
                while (datos.Lector.Read())
                {
                    if ((int)datos.Lector["Cantidad"] == 1)
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
            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}