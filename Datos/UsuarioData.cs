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
                cmd.Parameters.AddWithValue("@IdUsuario", 0);
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
                    objUser.nIdUsuario = Convert.ToInt32(dr[0]);
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
        public static List<Usuario> ListarBuscarUsuario(bool bEstado, string sLogin)
        {
            int tipo=8;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<Usuario> listUsuario = new List<Usuario>();
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Usuario", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdUsuario", 0);
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
                    objUser.nIdUsuario = Convert.ToInt32(dr[0]);
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

        //Iniciar Sesion
        public static Usuario IniciarSesionUsuario(string sLogin, string sPassword)
        {
            int tipo = 7;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            Usuario objUser = null;

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
                cmd.Parameters.AddWithValue("@Clave", sPassword);
                cmd.Parameters.AddWithValue("@Usuario", "");
                cmd.Parameters.AddWithValue("@Estado", true);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    objUser = new Usuario();
                    objUser.nIdUsuario =Convert.ToInt32(dr[0]);
                    objUser.sNombres = dr[1].ToString();
                    objUser.sLogin = dr[2].ToString();
                    objUser.sDni = dr[3].ToString();

                }
                return objUser;
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
                cmd.Parameters.AddWithValue("@IdUsuario", objUser.nIdUsuario);
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
        public static int ResearUsuario(Usuario objUser)
        {
            int respuesta = 0, tipo = 5 ;

            SqlCommand cmd = null;
            Conexion cn = new Conexion();

            try
            {
                SqlConnection cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Usuario", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdUsuario", objUser.nIdUsuario);
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

        //Eliminar
        public static int EliminarActivarUsuario(Usuario objUser)
        {
            int respuesta = 0, tipo = 3;
            SqlCommand cmd = null;
            Conexion cn = new Conexion();

            try
            {
                SqlConnection cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Usuario", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdUsuario", objUser.nIdUsuario);
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
    }
}
