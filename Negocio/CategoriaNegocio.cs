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
     public class CategoriaNegocio
    {
        //Listar
        public List<Categoria> ListarCategoria(bool estado)
        {
            return CategoriaData.ListarCategoria(estado);
        }

        //Buscar
        public List<Categoria> ListarBuscarCategoria(bool estado, string descripcion)
        {
            return CategoriaData.ListarBuscarCategoria(estado, descripcion);
        }

        //Actualizar
        public int ActualizarCategoria(int idCategoria, string descripcion)
        {
            return CategoriaData.ActualizarCategoria(idCategoria, descripcion);
        }

        //Registrar
        public int RegistrarCategoria(string descripcion)
        {
            return CategoriaData.RegistrarCategoria(descripcion);
        }

        //Eliminar
        public int EliminarActivarCategoria(int idCategoria, bool estado)
        {
            return CategoriaData.EliminarActivarPresentacion(idCategoria, estado);
        }
    }
}