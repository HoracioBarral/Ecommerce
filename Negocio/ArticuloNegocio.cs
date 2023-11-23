﻿using dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConexion("SELECT A.ID_Articulo,A.NombreArticulo,A.Descripcion,A.Estado, C.NombreCategoria AS Categoria,M.NombreMarca AS Marca,A.Precio,A.Stock,STRING_AGG(I.Url_Imagen, ';') AS Imagenes\r\nFROM Articulos A INNER JOIN Categorias C ON C.ID_Categoria = A.ID_Categoria INNER JOIN Marcas M ON M.ID_Marca = A.ID_Marca LEFT JOIN Imagenes I ON I.ID_Articulo = A.ID_Articulo WHERE A.Estado= 1\r\nGROUP BY A.ID_Articulo, A.NombreArticulo, A.Descripcion,A.Estado, C.NombreCategoria, M.NombreMarca, A.Precio, A.Stock");
                datos.abrirConexion();
                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.idArticulo = (int)datos.Lector["ID_Articulo"];
                    articulo.nombreArticulo = (string)datos.Lector["NombreArticulo"];
                    articulo.descripcion = (string)datos.Lector["Descripcion"];
                    articulo.categoria = new Categoria();
                    articulo.categoria.nombreCategoria = (string)datos.Lector["Categoria"];
                    articulo.marca = new Marca();
                    articulo.marca.nombreMarca = (string)datos.Lector["Marca"];
                    articulo.precio = (decimal)datos.Lector["Precio"];
                    articulo.stock = (int)datos.Lector["stock"];
                    articulo.listaImagenes = new List<Imagen>();
                    if (!datos.Lector.IsDBNull(datos.Lector.GetOrdinal("Imagenes")))
                    {
                        Imagen imagen = new Imagen();
                        imagen.UrlImagen = (string)datos.Lector["Imagenes"];
                        articulo.listaImagenes.Add(imagen);
                    }
                    lista.Add(articulo);
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
        public List<Articulo> ListarconSP()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("sp_ListarArticulos");
                datos.abrirConexion();
                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.idArticulo = (int)datos.Lector["ID_Articulo"];
                    articulo.nombreArticulo = (string)datos.Lector["NombreArticulo"];
                    articulo.descripcion = (string)datos.Lector["Descripcion"];
                    articulo.categoria = new Categoria();
                    articulo.categoria.nombreCategoria = (string)datos.Lector["Categoria"];
                    articulo.marca = new Marca();
                    articulo.marca.nombreMarca = (string)datos.Lector["Marca"];
                    articulo.precio = (decimal)datos.Lector["Precio"];
                    articulo.stock = (int)datos.Lector["stock"];
                    articulo.Estado = bool.Parse(datos.Lector["Estado"].ToString());
                    articulo.listaImagenes = new List<Imagen>();
                    if (!datos.Lector.IsDBNull(datos.Lector.GetOrdinal("Imagenes")))
                    {
                        Imagen imagen = new Imagen();
                        imagen.UrlImagen = (string)datos.Lector["Imagenes"];
                        articulo.listaImagenes.Add(imagen);
                    }
                    lista.Add(articulo);
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
        public Articulo buscarPorID(int Id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConexion("SELECT A.ID_Articulo, A.NombreArticulo, A.Descripcion, C.ID_Categoria ,C.NombreCategoria AS Categoria, M.ID_Marca ,M.NombreMarca AS Marca, A.Precio, A.Stock, A.Estado FROM Articulos A INNER JOIN Categorias C ON C.ID_Categoria = A.ID_Categoria INNER JOIN Marcas M ON M.ID_Marca = A.ID_Marca WHERE A.ID_Articulo = @ID");
                datos.setearParametro("@ID", Id);
                datos.abrirConexion();

                if (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.idArticulo = (int)datos.Lector["ID_Articulo"];
                    articulo.nombreArticulo = (string)datos.Lector["NombreArticulo"];
                    articulo.descripcion = (string)datos.Lector["Descripcion"];
                    articulo.categoria = new Categoria();
                    articulo.categoria.idCategoria = (int)datos.Lector["ID_Categoria"];
                    articulo.categoria.nombreCategoria = (string)datos.Lector["Categoria"];
                    articulo.marca = new Marca();
                    articulo.marca.idMarca = (int)datos.Lector["ID_Marca"];
                    articulo.marca.nombreMarca = (string)datos.Lector["Marca"];
                    articulo.precio = (decimal)datos.Lector["Precio"];
                    articulo.stock = (int)datos.Lector["Stock"];
                    articulo.Estado = (bool)datos.Lector["Estado"];
                    articulo.listaImagenes = new List<Imagen>(); ;

                    return articulo;
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
        public void agregar(Articulo nuevo)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConexion("INSERT INTO Articulos (NombreArticulo, Descripcion, Precio, Stock, ID_Categoria, ID_Marca) " + "VALUES (@NombreArticulo, @Descripcion, @Precio, @Stock, @ID_Categoria, @ID_Marca);");
                datos.setearParametro("@NombreArticulo",nuevo.nombreArticulo);
                datos.setearParametro("@Descripcion", nuevo.descripcion);
                datos.setearParametro("@Precio", nuevo.precio);
                datos.setearParametro("@Stock", nuevo.stock);
                datos.setearParametro("@ID_Categoria", nuevo.categoria.idCategoria);
                datos.setearParametro("@ID_Marca", nuevo.marca.idMarca);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion();}
        }
        public void modificarConSP(Articulo arti)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("sp_ModificarArticulo");
                datos.setearParametro("@ID_Articulo",arti.idArticulo);
                datos.setearParametro("@NombreArticulo", arti.nombreArticulo);
                datos.setearParametro("@Descripcion", arti.descripcion);
                datos.setearParametro("@Precio", arti.precio);
                datos.setearParametro("@Stock", arti.stock);
                datos.setearParametro("@ID_Categoria", arti.categoria.idCategoria);
                datos.setearParametro("@ID_Marca", arti.marca.idMarca);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion();}
        }
        public void EliminarArticulo(int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("sp_EliminarArticulo"); 
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

        public int insertarCompra(Articulo compra,int idUsuario)
        {
            AccesoDatos datos2 = new AccesoDatos();
            try
            {
                datos2.setConexion("insert into Pedidos(Cantidad,Talle,ID_Articulo,ID_Usuario,Importe) output inserted.ID_Pedido values(@cantidad,@talle,@idArticulo,@idUsuario,@importe)");
                datos2.setearParametro("@cantidad",compra.cantidad);
                datos2.setearParametro("@talle",compra.talle);
                datos2.setearParametro("@idArticulo",compra.idArticulo);
                datos2.setearParametro("@idUsuario",idUsuario);
                datos2.setearParametro("@importe",compra.precio);
                int idPedido=datos2.ejecutarAccionConOutput();
                return idPedido;
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

        public void modificarEstadoCompra(int idPedido,int estado)
        {
            AccesoDatos datos2 = new AccesoDatos();
            try
            {
                datos2.setConexion("update Pedidos set Estado=@estado where ID_Pedido=@idPedido");
                datos2.setearParametro("@idPedido",idPedido);
                datos2.setearParametro("@estado", estado);
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
    }
}

