using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Permiso
    {
        public Permiso()
        {
            this.nIdPermiso = 0;
            this.sDescripcion = "";
            this.nIdMenu = 0;
            this.nTag = 0;
            this.sUsuario = "";
            this.dFecha = DateTime.Now;
            this.bEstado = true;
        }

        public int nIdPermiso { get; set; }
        public string sDescripcion { get; set; }
        public int nIdMenu { get; set; }
        public int nTag { get; set; }
        public string sUsuario { get; set; }
        public DateTime dFecha { get; set; }
        public bool bEstado { get; set; }
    }
}
