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
    public class SedeData
    {
        //Listar Varios
        public static List<Sede> ListarSede(bool estado)
        {
            int tipo = 1;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<Sede> listSede = new List<Sede>();
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Sede", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdSede", "");
                cmd.Parameters.AddWithValue("@Descripcion", "");
                cmd.Parameters.AddWithValue("@Direccion", "");
                cmd.Parameters.AddWithValue("@Usuario", "");
                cmd.Parameters.AddWithValue("@Estado", estado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Sede objSed = new Sede();
                    objSed.nIdSede = int.Parse(dr[0].ToString());
                    objSed.sDescripcion = dr[1].ToString();
                    objSed.sDireccion = dr[2].ToString();

                    listSede.Add(objSed);

                }
                return listSede;
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

        //Listar Buscar
        public static List<Sede> ListarBuscarSede(bool estado, string descripcion)
        {
            int tipo=5;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<Sede> listSede = new List<Sede>();
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Sede", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdSede", "");
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                cmd.Parameters.AddWithValue("@Direccion", "");
                cmd.Parameters.AddWithValue("@Usuario", "");
                cmd.Parameters.AddWithValue("@Estado", estado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Sede objSed = new Sede();
                    objSed.nIdSede = int.Parse(dr[0].ToString());
                    objSed.sDescripcion = dr[1].ToString();
                    objSed.sDireccion = dr[2].ToString();

                    listSede.Add(objSed);

                }
                return listSede;
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

        //Actualizar
        public static int ActualizarSede(Sede objSed)
        {
            int respuesta = 0, tipo = 3 ;

            SqlCommand cmd = null;
            Conexion cn = new Conexion();

            try
            {
                SqlConnection cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Sede", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdSede", objSed.nIdSede);
                cmd.Parameters.AddWithValue("@Descripcion", objSed.sDescripcion);
                cmd.Parameters.AddWithValue("@Direccion", objSed.sDireccion);
                cmd.Parameters.AddWithValue("@Usuario", objSed.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objSed.bEstado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();

                respuesta= cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                respuesta = 2;
                MessageBox.Show(ex.Message,"Alerta",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            finally
            {
                cmd = null;
                cn = null;
            }

            return respuesta;
        }

        //Registrar
        public static int RegistrarSede(Sede objSed)
        {
            int respuesta = 0, tipo = 2;

            SqlCommand cmd = null;
            Conexion cn = new Conexion();

            try
            {
                SqlConnection cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Sede", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdSede", objSed.nIdSede);
                cmd.Parameters.AddWithValue("@Descripcion", objSed.sDescripcion);
                cmd.Parameters.AddWithValue("@Direccion",objSed.sDireccion);
                cmd.Parameters.AddWithValue("@Usuario",objSed.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objSed.bEstado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();

                respuesta = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                respuesta = 2;
                MessageBox.Show(ex.Message, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                cmd = null;
                cn = null;
            }

            return respuesta;
        }

        //Eliminar
        public static int EliminarActivarSede(Sede objSed)
        {
            int respuesta = 0, tipo=4;
            SqlCommand cmd = null;
            Conexion cn = new Conexion();

            try
            {
                SqlConnection cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Sede", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdSede", objSed.nIdSede);
                cmd.Parameters.AddWithValue("@Descripcion", objSed.sDescripcion);
                cmd.Parameters.AddWithValue("@Direccion", objSed.sDireccion);
                cmd.Parameters.AddWithValue("@Usuario", objSed.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objSed.bEstado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();

                respuesta = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                respuesta = 2;
                MessageBox.Show(ex.Message, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                cmd = null;
                cn = null;
            }

            return respuesta;
        }

    }
}
