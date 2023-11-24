using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace Negocio
{
    public class PedidoNegocio
    {
        public List<Pedido> listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Pedido> lista = new List<Pedido>();
            try
            {
                datos.setConexion("select p.ID_Pedido,p.ID_Usuario,p.Estado,SUM(dp.importe) as 'Importe',SUM(dp.cantidad) as 'Cantidad' from pedidos p left join detallePedidos dp on dp.ID_Pedido=p.ID_Pedido group by p.ID_Pedido,p.ID_Usuario,p.Estado");
                datos.abrirConexion();
                while (datos.Lector.Read())
                {
                    Pedido pedido = new Pedido();
                    pedido.idPedido = (int)datos.Lector["ID_Pedido"];
                    pedido.idUsuario = (int)datos.Lector["ID_Usuario"];
                    pedido.estado = (int)datos.Lector["Estado"];
                    pedido.importe = (decimal)datos.Lector["Importe"];
                    pedido.cantidad = (int)datos.Lector["Cantidad"];
                    lista.Add(pedido);
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
