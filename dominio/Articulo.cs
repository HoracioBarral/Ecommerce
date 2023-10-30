using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {
        public  long idArticulo { get; set; }

        public string nombreArticulo { set; get; }
        public string descripcion { get; set; }

        public Categoria categoria { get; set; }

        public Marca marca { get; set; }

        public decimal precio { get; set; }

        public short stock { get; set; }

        public bool Estado { get; set; }

        List<Imagen> listaImagenes { get; set; }
 
    }
}
