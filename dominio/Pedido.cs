using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Pedido
    {
        public int idPedido { get; set; }

        public decimal importe { get; set; }

        public int idUsuario { get; set; }

        public bool Estado { get; set; }

        public int numeroPedido { get; set; }

    }
}
