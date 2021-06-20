using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Permiso
    {
        public int nTipo { get; set; }
        public int nIdPermiso { get; set; }
        public int nIdMenu { get; set; }
        public string sIdUsuario { get; set; }
        public DateTime dFecha { get; set; }
        public bool bEstado { get; set; }
    }
}
