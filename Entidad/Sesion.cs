using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Sesion
    {
        public int nidsesion { get; set; }
        public bool bactivo { get; set; }
        public DateTime dfechafin { get; set; }
        public DateTime dfechainicio { get; set; }
        public DateTime dfechareg { get; set; }
        public string ssistemaversion { get; set; }
        public int nidusuario { get; set; }
    }
}
