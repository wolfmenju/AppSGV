using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Operador
    {
        public int nidoperador { get; set; }
        public bool bactivo { get; set; }
        public DateTime dfechanac { get; set; }
        public DateTime dfechareg { get; set; }
        public int nidsesion { get; set; }
        public string sapematerno { get; set; }
        public string sapepaterno { get; set; }
        public string sgenero { get; set; }
        public string snombre { get; set; }
        public string snumdocu { get; set; }
        public string sobservacion { get; set; }
        public int nidpadre { get; set; }
    }
}
