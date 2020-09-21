using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegPresentacion
    {
        //Listar
        public List<Presentacion> ListarPresentacion(bool activo)
        {
            return DatPresentacion.ListarPresentacion(activo);
        }

        //Buscar
        public List<Presentacion> ListarBuscarPresentacion(bool activo, string descripcion)
        {
            return DatPresentacion.ListarBuscarPresentacion(activo, descripcion);
        }

        //Actualizar
        public int ActualizarPresentacion(int idPresentacion, string descripcion)
        {
            return DatPresentacion.ActualizarPresentacion(idPresentacion, descripcion);
        }

        //Registrar
        public int RegistrarPresentacion(string descripcion)
        {
            return DatPresentacion.RegistrarPresentacion(descripcion);
        }

        //Eliminar
        public int EliminarPresentacion(int idPresentacion)
        {
            return DatPresentacion.EliminarPresentacion(idPresentacion);
        }

    }
}