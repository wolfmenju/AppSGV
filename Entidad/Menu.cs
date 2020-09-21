using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Menu
    {
        public int nidmenu { get; set; }
        public bool bactivo { get; set; }
        public DateTime dfechareg { get; set; }
        public int nidsesion { get; set; }
        public int norden { get; set; }
        public string siconomenu { get; set; }
        public string snombremenu { get; set; }
        public string surl { get; set; }
        public int nidmodulo { get; set; }
        public int nidpadre { get; set; }
    }
}
