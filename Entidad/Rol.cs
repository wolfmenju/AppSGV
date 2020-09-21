using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Rol
    {
        public int nidrol { get; set; }
        public bool bactivo { get; set; }
        public DateTime dfechareg { get; set; }
        public Nullable<int> nidsesion { get; set; }
        public string siglas { get; set; }
        public string snombrerol { get; set; }
        public string sobservacion { get; set; }
    }
}
