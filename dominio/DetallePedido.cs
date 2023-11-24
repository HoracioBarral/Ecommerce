using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class DetallePedido
    {
        public int idPedido { get; set; }

        public List<Articulo> listaArticulos { get; set; }

        public int cantidad { get; set; }

        public decimal importe { get; set; }
    }
}
