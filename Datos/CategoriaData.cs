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
    public class CategoriaData
    {
        //Listar Varios
        public static List<Categoria> ListarCategoria(bool estado)
        {
            int tipo = 1;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<Categoria> listCategoria = new List<Categoria>();
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Categoria", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdLaboratorio", "");
                cmd.Parameters.AddWithValue("@Descripcion", "");
                cmd.Parameters.AddWithValue("@Usuario", "");
                cmd.Parameters.AddWithValue("@Estado", estado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Categoria objCateg = new Categoria();
                    objCateg.nIdCategoria = int.Parse(dr[0].ToString());
                    objCateg.sDescripcion = dr[1].ToString();

                    listCategoria.Add(objCateg);

                }
                return listCategoria;
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
        public static List<Categoria> ListarBuscarCategoria(bool estado, string descripcion)
        {
            int tipo=5;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<Categoria> listCategoria = new List<Categoria>();
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Categoria", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdLaboratorio", "");
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                cmd.Parameters.AddWithValue("@Usuario", "");
                cmd.Parameters.AddWithValue("@Estado", estado);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Categoria objCateg = new Categoria();
                    objCateg.nIdCategoria = int.Parse(dr[0].ToString());
                    objCateg.sDescripcion = dr[1].ToString();

                    listCategoria.Add(objCateg);

                }
                return listCategoria;
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
        public static int ActualizarCategoria(Categoria objCat)
        {
            int respuesta = 0, tipo = 3 ;

            SqlCommand cmd = null;
            Conexion cn = new Conexion();

            try
            {
                SqlConnection cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Categoria", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdLaboratorio", objCat.nIdCategoria);
                cmd.Parameters.AddWithValue("@Descripcion", objCat.sDescripcion);
                cmd.Parameters.AddWithValue("@Usuario", objCat.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objCat.bEstado);
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
        public static int RegistrarCategoria(Categoria objCat)
        {
            int respuesta = 0, tipo = 2;

            SqlCommand cmd = null;
            Conexion cn = new Conexion();

            try
            {
                SqlConnection cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Categoria", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdLaboratorio", objCat.nIdCategoria);
                cmd.Parameters.AddWithValue("@Descripcion", objCat.sDescripcion);
                cmd.Parameters.AddWithValue("@Usuario", objCat.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objCat.bEstado);
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
        public static int EliminarActivarCategoria(Categoria objCat)
        {
            int respuesta = 0, tipo=4;
            SqlCommand cmd = null;
            Conexion cn = new Conexion();

            try
            {
                SqlConnection cnx = cn.getConecta();
                cmd = new SqlCommand("IAE_Categoria", cnx);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@IdLaboratorio", objCat.nIdCategoria);
                cmd.Parameters.AddWithValue("@Descripcion", objCat.sDescripcion);
                cmd.Parameters.AddWithValue("@Usuario", objCat.sUsuario);
                cmd.Parameters.AddWithValue("@Estado", objCat.bEstado);
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
