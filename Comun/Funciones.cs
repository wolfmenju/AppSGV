using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun
{
    public static class Funciones
    {
        private static string User = "";

        public static void UsuarioActualSet(string user)
        {
            User = user;
        }

        public static string UsuarioActual()
        {
            return User;
        }
        
        public static bool DatosVacios( string valorDato)
        {
            if (valorDato == "" || valorDato == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool DatosDuplicados(string valorDato)
        {
            return true;
        }
    }
}
