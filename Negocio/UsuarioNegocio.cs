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
     public class UsuarioNegocio
    {
        //Listar
        public List<Usuario> ListarUsuario(bool bActivo)
        {
            return UsuarioData.ListarUsuario(bActivo);
        }

        //Buscar
        //public List<Usuario> ListarBuscarPresentacion(bool activo, string descripcion)
        //{
        //    return PresentacionData.ListarBuscarPresentacion(activo, descripcion);
        //}

        //Actualizar
        public int ActualizarUsuario(Usuario objUser)
        {
            return UsuarioData.ActualizarUsuario(objUser);
        }

        //Registrar
        public int RegistrarUsuario(Usuario objUser)
        {
            return UsuarioData.RegistrarUsuario(objUser);
        }

        ////Eliminar
        //public int EliminarActivarPresentacion(int idPresentacion, bool estado)
        //{
        //    return PresentacionData.EliminarActivarPresentacion(idPresentacion,estado);
        //}

    }
}