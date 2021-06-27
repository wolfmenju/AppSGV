using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Usuario
    {
        public Usuario()
        {
            this.nIdUsuario =0;
            this.sNombres = "";
            this.sDni = "";
            this.sDireccion = "";
            this.sCelular = "";
            this.sLogin = "";
            this.sClave = "";
            this.sNuevaClave = "";
            this.sUsuario = "";
            this.bEstado = true;
        }


        public int nIdUsuario { get; set; }
        public string sNombres { get; set; }
        public string sDni { get; set; }
        public string sDireccion { get; set; }
        public string sCelular { get; set; }
        public string sLogin { get; set; }
        public string sClave { get; set; }
        public string sNuevaClave { get; set; }
        public string sUsuario { get; set; }
        public bool bEstado { get; set; }

    }
}
