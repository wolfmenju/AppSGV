using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class DocumentoSerie
    {
        public DocumentoSerie()
        {
            this.nIdDocumentoSerie = 0;
            this.sIdDocumento = "";
            this.sDescripcion = "";
            this.sSerie = "";
            this.nUltimo = 0;
            this.sUsuario = "";
            this.bEstado = true;
        }
        
        public int nIdDocumentoSerie { get; set; }
        public string sIdDocumento { get; set; }
        public string sDescripcion { get; set; }
        public string sSerie { get; set; }
        public int nUltimo { get; set; }
        public string sUsuario { get; set; }
        public bool bEstado { get; set; }
    }
}
