using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {
        int idArticulo { get; set; }

        string nombreArticulo { set; get; }

        Categoria categoria { get; set; }

        Marca marca { get; set; }

        decimal precio { get; set; }

        int stock { get; set; }

        bool Estado { get; set; }

        List<Imagen> listaImagenes { get; set; }
 
    }
}
