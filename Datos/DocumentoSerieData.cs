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
    public class DocumentoSerieData
    {
        //Listar Varios
        public static List<DocumentoSerie> ListarDocumentoSerie(bool estado)
        {
            int tipo = 1;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<DocumentoSerie> listDocumento = new List<DocumentoSerie>();
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_DocumentoSerie", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdDocumentoSerie", "");
                cmd.Parameters.AddWithValue("@IdDocumento", "");
                cmd.Parameters.AddWithValue("@sDescripcion", "");
                cmd.Parameters.AddWithValue("@Serie", "");
                cmd.Parameters.AddWithValue("@Ultimo", "");
                cmd.Parameters.AddWithValue("@Usuario", "");
                cmd.Parameters.AddWithValue("@Estado", estado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    DocumentoSerie objDocument = new DocumentoSerie();
                    objDocument.nIdDocumentoSerie =Convert.ToInt32(dr[0].ToString());
                    objDocument.sIdDocumento = dr[1].ToString();
                    objDocument.sDescripcion = dr[2].ToString();
                    objDocument.sSerie = dr[3].ToString();
                    objDocument.nUltimo = Convert.ToInt32(dr[4].ToString());

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
        public static List<DocumentoSerie> ListarBuscarDocumentoSerie(bool estado, string descripcion)
        {
            int tipo=7;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<DocumentoSerie> listDocumento = new List<DocumentoSerie>();
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_DocumentoSerie", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdDocumentoSerie", "");
                cmd.Parameters.AddWithValue("@IdDocumento", "");
                cmd.Parameters.AddWithValue("@sDescripcion", descripcion);
                cmd.Parameters.AddWithValue("@Serie", "");
                cmd.Parameters.AddWithValue("@Ultimo", "");
                cmd.Parameters.AddWithValue("@Usuario", "");
                cmd.Parameters.AddWithValue("@Estado", estado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    DocumentoSerie objDocument = new DocumentoSerie();
                    objDocument.nIdDocumentoSerie = Convert.ToInt32(dr[0].ToString());
                    objDocument.sIdDocumento = dr[1].ToString();
                    objDocument.sDescripcion = dr[2].ToString();
                    objDocument.sSerie = dr[3].ToString();
                    objDocument.nUltimo = Convert.ToInt32(dr[4].ToString());

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
        public static int ActualizarDocumentoSerie(DocumentoSerie objDocumt)
        {
            int respuesta = 0, tipo = 3 ;

            SqlCommand cmd = null;
            Conexion cn = new Conexion();

            try
            {
                SqlConnection cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_DocumentoSerie", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdDocumentoSerie", objDocumt.nIdDocumentoSerie);
                cmd.Parameters.AddWithValue("@IdDocumento", objDocumt.sIdDocumento);
                cmd.Parameters.AddWithValue("@sDescripcion", objDocumt.sDescripcion);
                cmd.Parameters.AddWithValue("@Serie", objDocumt.sSerie);
                cmd.Parameters.AddWithValue("@Ultimo", objDocumt.nUltimo);
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
        public static int RegistrarDocumentoSerie(DocumentoSerie objDocumt)
        {
            int respuesta = 0, tipo = 2;

            SqlCommand cmd = null;
            Conexion cn = new Conexion();

            try
            {
                SqlConnection cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_DocumentoSerie", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdDocumentoSerie", objDocumt.nIdDocumentoSerie);
                cmd.Parameters.AddWithValue("@IdDocumento", objDocumt.sIdDocumento);
                cmd.Parameters.AddWithValue("@sDescripcion", objDocumt.sDescripcion);
                cmd.Parameters.AddWithValue("@Serie", objDocumt.sSerie);
                cmd.Parameters.AddWithValue("@Ultimo", objDocumt.nUltimo);
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
        public static int EliminarActivarDocumentoSerie(DocumentoSerie objDocumt)
        {
            int respuesta = 0, tipo=4;
            SqlCommand cmd = null;
            Conexion cn = new Conexion();

            try
            {
                SqlConnection cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_DocumentoSerie", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdDocumentoSerie", objDocumt.nIdDocumentoSerie);
                cmd.Parameters.AddWithValue("@IdDocumento", objDocumt.sIdDocumento);
                cmd.Parameters.AddWithValue("@sDescripcion", objDocumt.sDescripcion);
                cmd.Parameters.AddWithValue("@Serie", objDocumt.sSerie);
                cmd.Parameters.AddWithValue("@Ultimo", objDocumt.nUltimo);
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
