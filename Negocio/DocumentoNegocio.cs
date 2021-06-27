using Comun;
using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
     public class DocumentoNegocio
    {
        //Listar
        public List<Documento> ListarDocumento(bool activo)
        {
            return DocumentoData.ListarDocumento(activo);
        }

        //Buscar
        public List<Documento> ListarBuscarDocumento(bool activo, string descripcion)
        {
            return DocumentoData.ListarBuscarDocumento(activo, descripcion);
        }

        //Actualizar
        public int ActualizarDocumento(Documento objDocumt)
        {
            return DocumentoData.ActualizarDocumento(objDocumt);
        }

        //Registrar
        public int RegistrarDocumento(Documento objDocumt)
        {
            return DocumentoData.RegistrarDocumento(objDocumt);
        }

        //Eliminar
        public int EliminarActivarDocumento(Documento objDocumt)
        {
            return DocumentoData.EliminarActivarDocumento(objDocumt);
        }

    }
}