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
    public class DocumentoData
    {
        //Listar Varios
        public static List<Documento> ListarDocumento(bool estado)
        {
            int tipo = 1;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<Documento> listDocumento = new List<Documento>();
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Documento", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdDocumento", "");
                cmd.Parameters.AddWithValue("@Descripcion", "");
                cmd.Parameters.AddWithValue("@Abreviatura", "");
                cmd.Parameters.AddWithValue("@Usuario", "");
                cmd.Parameters.AddWithValue("@Estado", estado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Documento objDocument = new Documento();
                    objDocument.sIdDocumento = dr[0].ToString();
                    objDocument.sDescripcion = dr[1].ToString();
                    objDocument.sAbreviatura = dr[2].ToString();

                    listDocumento.Add(objDocument);

                }
                return listDocumento;
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
        public static List<Documento> ListarBuscarDocumento(bool estado, string descripcion)
        {
            int tipo=7;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<Documento> listDocumento = new List<Documento>();
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Documento", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdDocumento", "");
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                cmd.Parameters.AddWithValue("@Abreviatura", "");
                cmd.Parameters.AddWithValue("@Usuario", "");
                cmd.Parameters.AddWithValue("@Estado", estado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Documento objDocument = new Documento();
                    objDocument.sIdDocumento =dr[0].ToString();
                    objDocument.sDescripcion = dr[1].ToString();
                    objDocument.sAbreviatura = dr[2].ToString();

                    listDocumento.Add(objDocument);

                }
                return listDocumento;
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
        public static int ActualizarDocumento(Documento objDocumt)
        {
            int respuesta = 0, tipo = 3 ;

            SqlCommand cmd = null;
            Conexion cn = new Conexion();

            try
            {
                SqlConnection cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Documento", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdDocumento",objDocumt.sIdDocumento);
                cmd.Parameters.AddWithValue("@Descripcion", objDocumt.sDescripcion);
                cmd.Parameters.AddWithValue("@Abreviatura", objDocumt.sAbreviatura);
                cmd.Parameters.AddWithValue("@Usuario", objDocumt.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objDocumt.bEstado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();

                respuesta= cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                respuesta = 2;
                MessageBox.Show(ex.Message,"InguiriSoft",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            finally
            {
                cmd = null;
                cn = null;
            }

            return respuesta;
        }

        //Registrar
        public static int RegistrarDocumento(Documento objDocumt)
        {
            int respuesta = 0, tipo = 2;

            SqlCommand cmd = null;
            Conexion cn = new Conexion();

            try
            {
                SqlConnection cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Documento", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdDocumento", objDocumt.sIdDocumento);
                cmd.Parameters.AddWithValue("@Descripcion", objDocumt.sDescripcion);
                cmd.Parameters.AddWithValue("@Abreviatura", objDocumt.sAbreviatura);
                cmd.Parameters.AddWithValue("@Usuario", objDocumt.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objDocumt.bEstado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();

                respuesta = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                respuesta = 2;
                MessageBox.Show(ex.Message, "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                cmd = null;
                cn = null;
            }

            return respuesta;
        }

        //Eliminar
        public static int EliminarActivarDocumento(Documento objDocumt)
        {
            int respuesta = 0, tipo=4;
            SqlCommand cmd = null;
            Conexion cn = new Conexion();

            try
            {
                SqlConnection cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Documento", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdDocumento", objDocumt.sIdDocumento);
                cmd.Parameters.AddWithValue("@Descripcion", objDocumt.sDescripcion);
                cmd.Parameters.AddWithValue("@Abreviatura", objDocumt.sAbreviatura);
                cmd.Parameters.AddWithValue("@Usuario", objDocumt.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objDocumt.bEstado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();

                respuesta = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                respuesta = 2;
                MessageBox.Show(ex.Message, "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
