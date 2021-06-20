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
    public class AlmacenData
    {
        //Listar Varios
        public static List<Almacen> ListarAlmacen()
        {
            int tipo = 7;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<Almacen> listAlmacen = new List<Almacen>();
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Almacen", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdAlmacen", "");
                cmd.Parameters.AddWithValue("@Descripcion", "");
                cmd.Parameters.AddWithValue("@Direccion", "");
                cmd.Parameters.AddWithValue("@IdSede", "");
                cmd.Parameters.AddWithValue("@Usuario", "");
                cmd.Parameters.AddWithValue("@Estado", true);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Almacen objAlmacen = new Almacen();
                    objAlmacen.nIdAlmacen = int.Parse(dr[0].ToString());
                    objAlmacen.sDescripcion = dr[1].ToString();

                    listAlmacen.Add(objAlmacen);

                }
                return listAlmacen;
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
