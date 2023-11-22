﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace Negocio
{
    public class StockNegocio
    {
        public void insertarStock(string talle,int cantidad,int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConexion("insert into StockPorTalles(Talle,Stock,ID_Articulo) values(@talle,@cantidad,@idArticulo)");
                datos.setearParametro("@talle", talle);
                datos.setearParametro("@cantidad", cantidad);
                datos.setearParametro("@idArticulo", idArticulo);
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

        public List<StockTalles> listarPorID(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            List<StockTalles> lista = new List<StockTalles>();
            try
            {
                datos.setConexion("select * from StockPorTalles where ID_Articulo=@idArticulo");
                datos.setearParametro("@idArticulo", id);
                datos.abrirConexion();
                while (datos.Lector.Read())
                {
                    StockTalles stockTalles = new StockTalles();
                    stockTalles.talle = (string)datos.Lector["Talle"];
                    stockTalles.stock = (int)datos.Lector["Stock"];
                    stockTalles.idArticulo = (int)datos.Lector["ID_Articulo"];
                    lista.Add(stockTalles);
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
    }
}