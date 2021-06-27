using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Presentacion
    {
        public Presentacion()
        {
            this.nIdPresentacion = 0;
            this.sDescripcion = "";
            this.sUsuario = "";
            this.bEstado = true;
        }
        
        public int nIdPresentacion { get; set; }
        public string sDescripcion { get; set; }
        public string sUsuario { get; set; }
        public bool bEstado { get; set; }
    }
}
