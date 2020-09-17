using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun
{
    public static class Funciones 
    {
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
