﻿using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ImagenNegocio
    {
        
        public List <Imagen> Listar(int id)
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConexion("SELECT * FROM IMAGENES WHERE ID_Articulo = @idArticulo and Estado=1");
                datos.setearParametro("@idArticulo", id);
                datos.abrirConexion();
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
        public void GuardarImagen(string urlImagen, int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("sp_GuardarImagen");
                datos.setearParametro("@Url_Imagen", urlImagen);
                datos.setearParametro("@ID_Articulo", idArticulo);
                datos.ejecutarAccion();
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

        public void EliminarImagen(int id,string url)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConexion("delete Imagenes where ID_Articulo=@id and Url_Imagen like @url");
                datos.setearParametro("@id", id);
                datos.setearParametro("@url", url);
                datos.abrirConexion();
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
