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
        public List<Usuario> ListarBuscarUsuario(bool bActivo, string sLogin)
        {
            return UsuarioData.ListarBuscarUsuario(bActivo, sLogin);
        }

        //Actualizar
        public int ResearUsuario(Usuario objUser)
        {
            return UsuarioData.ResearUsuario(objUser);
        }

        //Registrar
        public int RegistrarUsuario(Usuario objUser)
        {
            return UsuarioData.RegistrarUsuario(objUser);
        }

        ////Eliminar
        public int EliminarActivarUsuario(int nIdPresentacion, bool bEstado)
        {
            return UsuarioData.EliminarActivarUsuario(nIdPresentacion, bEstado);
        }

        //Inicio de Sesion
        public Usuario IniciarSesionUsuario(string sLogin, string sPassword)
        {
            return UsuarioData.IniciarSesionUsuario(sLogin, sPassword);
        }
    }
}