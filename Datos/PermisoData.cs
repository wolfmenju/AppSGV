using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datos
{
    public class PermisoData
    {
        //Listar Varios
        public static List<Permiso> ListarPermiso(string sIdUsuario)
        {
            int tipo = 1;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<Permiso> listPermiso = new List<Permiso>();
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Permiso", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdPermiso", "");
                cmd.Parameters.AddWithValue("@IdMenu", "");
                cmd.Parameters.AddWithValue("@IdUsuario", sIdUsuario);
                cmd.Parameters.AddWithValue("@Estado",true);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Permiso objPermiso = new Permiso();
                    objPermiso.nIdPermiso = int.Parse(dr[0].ToString());
                    objPermiso.nIdMenu = int.Parse(dr[1].ToString());
                    objPermiso.nTag = int.Parse(dr[2].ToString());
                    objPermiso.sDescripcion = dr[3].ToString();

                    listPermiso.Add(objPermiso);

                }
                return listPermiso;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
    }
}
