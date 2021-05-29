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
        public int ActualizarPresentacion(int idPresentacion, string descripcion)
        {
            return PresentacionData.ActualizarPresentacion(idPresentacion, descripcion);
        }

        //Registrar
        public int RegistrarPresentacion(string descripcion)
        {
            return PresentacionData.RegistrarPresentacion(descripcion);
        }

        //Eliminar
        public int EliminarPresentacion(int idPresentacion)
        {
            return PresentacionData.EliminarPresentacion(idPresentacion);
        }

    }
}