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
     public class SedeNegocio
    {
        //Listar
        public List<Sede> ListarSede(bool estado)
        {
            return SedeData.ListarSede(estado);
        }

        //Buscar
        public List<Sede> ListarBuscarSede(bool estado, string descripcion)
        {
            return SedeData.ListarBuscarSede(estado, descripcion);
        }

        //Actualizar
        public int ActualizarSede(Sede objSede)
        {
            return SedeData.ActualizarSede(objSede);
        }

        //Registrar
        public int RegistrarSede(Sede objSede)
        {
            return SedeData.RegistrarSede(objSede);
        }

        //Eliminar
        public int EliminarActivarSede(Sede objSede)
        {
            return SedeData.EliminarActivarSede(objSede);
        }
    }
}