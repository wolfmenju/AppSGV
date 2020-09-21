using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Usuario
    {
        public int nidusuario { get; set; }
        public bool bactivo { get; set; }
        public DateTime dfechareg { get; set; }
        public int nidsesion { get; set; }
        public string slogin { get; set; }
        public string spassword { get; set; }
    }
}
