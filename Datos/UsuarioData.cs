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
    public class UsuarioData
    {
        //Listar Varios
        public static List<Usuario> ListarUsuario(bool bEstado)
        {
            int tipo = 1;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<Usuario> listUsuario = new List<Usuario>();
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Usuario", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdUsuario", "");
                cmd.Parameters.AddWithValue("@Nombres", "");
                cmd.Parameters.AddWithValue("@Dni", "");
                cmd.Parameters.AddWithValue("@Direccion", "");
                cmd.Parameters.AddWithValue("@Celular", "");
                cmd.Parameters.AddWithValue("@Login", "");
                cmd.Parameters.AddWithValue("@Clave", "");
                cmd.Parameters.AddWithValue("@Usuario", "");
                cmd.Parameters.AddWithValue("@Estado", bEstado);

                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Usuario objUser = new Usuario();
                    objUser.sIdUsuario = dr[0].ToString();
                    objUser.sNombres = dr[1].ToString();
                    objUser.sLogin = dr[2].ToString();
                    objUser.sDni = dr[3].ToString();
                    objUser.sDireccion = dr[4].ToString();
                    objUser.sCelular = dr[5].ToString();
                    
                    listUsuario.Add(objUser);

                }
                return listUsuario;
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
        public static List<Usuario> ListarBuscarPresentacion(bool bEstado, string sLogin)
        {
            int tipo=5;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<Usuario> listUsuario = new List<Usuario>();
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Usuario", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdUsuario", "");
                cmd.Parameters.AddWithValue("@Nombres", "");
                cmd.Parameters.AddWithValue("@Dni", "");
                cmd.Parameters.AddWithValue("@Direccion", "");
                cmd.Parameters.AddWithValue("@Celular", "");
                cmd.Parameters.AddWithValue("@Login", sLogin);
                cmd.Parameters.AddWithValue("@Clave", "");
                cmd.Parameters.AddWithValue("@Usuario", "");
                cmd.Parameters.AddWithValue("@Estado", bEstado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Usuario objUser = new Usuario();
                    objUser.sIdUsuario = dr[0].ToString();
                    objUser.sNombres = dr[1].ToString();
                    objUser.sLogin = dr[2].ToString();
                    objUser.sDni = dr[3].ToString();
                    objUser.sDireccion = dr[4].ToString();
                    objUser.sCelular = dr[5].ToString();

                    listUsuario.Add(objUser);

                }
                return listUsuario;
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

        //Registrar
        public static int RegistrarUsuario(Usuario objUser)
        {
            int respuesta = 0, tipo = 2;

            SqlCommand cmd = null;
            Conexion cn = new Conexion();

            try
            {
                SqlConnection cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Usuario", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdUsuario", objUser.sIdUsuario);
                cmd.Parameters.AddWithValue("@Nombres", objUser.sNombres);
                cmd.Parameters.AddWithValue("@Dni", objUser.sDni);
                cmd.Parameters.AddWithValue("@Direccion", objUser.sDireccion);
                cmd.Parameters.AddWithValue("@Celular", objUser.sCelular);
                cmd.Parameters.AddWithValue("@Login", objUser.sLogin);
                cmd.Parameters.AddWithValue("@Clave", objUser.sClave);
                cmd.Parameters.AddWithValue("@Usuario", objUser.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objUser.bEstado);
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

        //Actualizar
        public static int ActualizarUsuario(Usuario objUser)
        {
            int respuesta = 0, tipo = 3 ;

            SqlCommand cmd = null;
            Conexion cn = new Conexion();

            try
            {
                SqlConnection cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Usuario", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdUsuario", objUser.sIdUsuario);
                cmd.Parameters.AddWithValue("@Nombres", objUser.sNombres);
                cmd.Parameters.AddWithValue("@Dni", objUser.sDni);
                cmd.Parameters.AddWithValue("@Direccion", objUser.sDireccion);
                cmd.Parameters.AddWithValue("@Celular", "");
                cmd.Parameters.AddWithValue("@Login", objUser.sLogin);
                cmd.Parameters.AddWithValue("@Clave", objUser.sClave);
                cmd.Parameters.AddWithValue("@Usuario", objUser.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objUser.bEstado);
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
    }
}
