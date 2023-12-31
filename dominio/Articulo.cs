﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {
        public int idArticulo { get; set; }

        public string nombreArticulo { set; get; }

        public string descripcion { get; set; }

        public Categoria categoria { get; set; }

        public Marca marca { get; set; }

        public decimal precio { get; set; }

        public int stock { get; set; }

        public bool Estado { get; set; }

        public int cantidad { get; set; }

        public string talle { get; set; }

        public int numeroPedido { get; set; }

        public List<Imagen> listaImagenes { get; set; }
 
    }
}
