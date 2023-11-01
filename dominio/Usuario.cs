using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Usuario
    {
        public int idUsuario { get; set; }

        public RolUsuario rolUsuario { get; set; }

        public string nombreUsuario { set; get; }

        public string clave { get; set; }
    }
}
