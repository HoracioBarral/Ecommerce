using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Usuario
    {
        int idUsuario { get; set; }

        RolUsuario rolUsuario { get; set; }

        string nombreUsuario { set; get; }

        string clave { get; set; }
    }
}
