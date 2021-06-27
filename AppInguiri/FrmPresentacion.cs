using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Comun;

namespace AppInguiri
{
    public partial class FrmPresentacion : Form
    {
        #region Variables Privadas
        private PresentacionNegocio objPresenNeg = new PresentacionNegocio();
        private List<Presentacion> listPresenta = new List<Presentacion>();
        private bool estado = true;
        #endregion

        #region Principal Load

        public FrmPresentacion()
        {
            InitializeComponent();
        }

        private void FrmPresentacion_Load(object sender, EventArgs e)
        {
            CargarPresentacion();
        }
        #endregion

        #region Eventos
        private void FrmPresentacion_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    BtnAgregar_Click(sender, e);
                    break;
                case Keys.F2:
                    BtnModificar_Click(sender, e);
                    break;
                case Keys.F3:
                    BtnRefrescar_Click(sender, e);
                    break;
                case Keys.F4:
                    BtnBuscar_Click(sender, e);
                    break;
                case Keys.F5:
                    BtnEliminar_Click(sender, e);
                    break;
            }
        }
        
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Agregar();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            CargarPresentacion();
        }
        
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChkTodos_CheckedChanged(object sender, EventArgs e)
        {

            estado = ChkTodos.Checked;

            if (ChkTodos.Checked)
            {
                BtnEliminar.Image = Properties.Resources.X;
                BtnEliminar.Text = "&Eliminar  [F5]";
            }
            else
            {
                BtnEliminar.Image = Properties.Resources.xActivar;
                BtnEliminar.Text = "&Activar  [F5]";
            }

            CargarPresentacion();

        }
    
        #endregion

        #region Metodo Privados
        private void CargarPresentacion()
        {
            listPresenta.Clear();
            listPresenta = objPresenNeg.ListarPresentacion(estado);

            if (listPresenta.Count() > 0)
            {
                DgvPresentacion.AutoGenerateColumns = false;
                DgvPresentacion.DataSource = listPresenta;
                LblTotal.Text = "Se Encontraron " + DgvPresentacion.Rows.Count + " Registros";
            }
            else
            {
                DgvPresentacion.DataSource = listPresenta;
            }
        }
        private void Eliminar()
        {
            int respuesta = 0;

            if (DgvPresentacion.RowCount > 0)
            {
                string msg = "";
                if (estado) { estado = false; msg = "Eliminar"; }
                else { estado = true; msg = "Activar"; }

                DialogResult res;
                res = MessageBox.Show("¿Desea " + msg + " el registro?", "InguiriSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    int idPresSele = Convert.ToInt32(DgvPresentacion.CurrentRow.Cells[0].Value);

                    Presentacion objPre = new Presentacion()
                    {
                        nIdPresentacion = idPresSele,
                        bEstado = estado,
                        sUsuario = Funciones.UsuarioActual()
                    };
                    
                    respuesta = objPresenNeg.EliminarActivarPresentacion(objPre);

                    if (respuesta == 1)
                    {
                        if (estado)
                        {
                            estado = false;
                            MessageBox.Show("Se Activó Correctamente", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            estado = true;
                            MessageBox.Show("Se Eliminó Correctamente", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        CargarPresentacion();
                    }
                }
                else
                {
                    if (estado) { estado = false; }
                    else { estado = true; }
                }
            }
            else
            {
                if (estado)
                {
                    MessageBox.Show("No se registran Presentación para eliminar", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    MessageBox.Show("No se registran Presentación para Activar", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void Buscar()
        {
            if (DgvPresentacion.Rows.Count == 0) return;

            List<Presentacion> listPresenta = new List<Presentacion>();
            string PresenBuscar = Interaction.InputBox("", "Buscar Presentación...");

            if (!PresenBuscar.Equals(""))
            {
                listPresenta = objPresenNeg.ListarBuscarPresentacion(estado, PresenBuscar.Trim());
                DgvPresentacion.DataSource = listPresenta;
                LblTotal.Text = "Se Encontraron " + DgvPresentacion.Rows.Count + " Registros";
            }
        }
        private void Modificar()
        {
            if (DgvPresentacion.Rows.Count == 0) return;

            int idPresSele = Convert.ToInt32(DgvPresentacion.CurrentRow.Cells[0].Value);
            string descSele = Convert.ToString(DgvPresentacion.CurrentRow.Cells[1].Value);

            FrmPresentacionActualiza frmPresent = new FrmPresentacionActualiza();
            //frmPresent.MdiParent = this.MdiParent;
            frmPresent.tipo = 3;
            frmPresent.idPresentacion = idPresSele;
            frmPresent.descripcion = descSele;
            frmPresent.Text = "Actualizar Presentación De Productos";
            
            if (frmPresent.ShowDialog() == DialogResult.OK)
            {
                CargarPresentacion();
            }

        }
        //validar que solo se acepten letras en la descripcion
        private void Agregar()
        {
            FrmPresentacionActualiza frmPresent = new FrmPresentacionActualiza();
            //frmPresent.MdiParent = this.MdiParent;
            frmPresent.tipo = 2;
            frmPresent.Text = "Registar Presentación De Productos";

            if (frmPresent.ShowDialog() == DialogResult.OK)
            {
                CargarPresentacion();
            }
        }
        #endregion
    }
}
