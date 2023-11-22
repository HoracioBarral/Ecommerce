using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace Negocio
{
    public static class Seguridad
    {
        static public bool esAdmin(object usuarioLogueado)
        {
            Usuario usuario = usuarioLogueado != null ? (Usuario)usuarioLogueado : null;
            if(usuario!=null && usuario.rolUsuario.idRol == 1)
            {
                return true;
            }
            return false;
        }
    }
}
