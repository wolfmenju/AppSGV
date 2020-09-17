using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Presentacion
    {
        private int _IdPresentacion;
        private string _Descripcion;

        public Presentacion()
        {

        }

        public int IdPresentacion
        {
            get { return _IdPresentacion; }
            set { _IdPresentacion = value; }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
    }
}
