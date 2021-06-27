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
     public class PresentacionNegocio
     {
        //Listar
        public List<Presentacion> ListarPresentacion(bool activo)
        {
            return PresentacionData.ListarPresentacion(activo);
        }

        //Buscar
        public List<Presentacion> ListarBuscarPresentacion(bool activo, string descripcion)
        {
            return PresentacionData.ListarBuscarPresentacion(activo, descripcion);
        }

        //Actualizar
        public int ActualizarPresentacion(Presentacion objPre)
        {
            return PresentacionData.ActualizarPresentacion(objPre);
        }

        //Registrar
        public int RegistrarPresentacion(Presentacion objPre)
        {
            return PresentacionData.RegistrarPresentacion(objPre);
        }

        //Eliminar
        public int EliminarActivarPresentacion(Presentacion objPre)
        {
            return PresentacionData.EliminarActivarPresentacion(objPre);
        }

    }
}