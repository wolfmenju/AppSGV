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

namespace AppInguiri
{
    public partial class FrmPresentacion : Form
    {
        #region Variables Privadas
        private PresentacionNegocio objPresenNeg =new PresentacionNegocio();
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
            FrmPresentacionActualiza frmPresent = new FrmPresentacionActualiza();
            //frmPresent.MdiParent = this.MdiParent;
            frmPresent.tipo = 2;
            frmPresent.Text = "Registar Presentación De Productos";
            frmPresent.listarPresentacion = listPresenta;
            bool bandera =true;

            while (bandera)
            {
                if (frmPresent.ShowDialog() == DialogResult.OK)
                {
                    if (frmPresent.TxtDescripcion.Text == "")
                    {
                        bandera = true;
                    }
                    else
                    {
                        CargarPresentacion();
                        bandera = false;
                    }
                }
                else
                {
                    bandera = false;
                }
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (DgPresentacion.Rows.Count==0) return;

            int idPresSele = Convert.ToInt32(DgPresentacion.CurrentRow.Cells[0].Value);
            string descSele = Convert.ToString(DgPresentacion.CurrentRow.Cells[1].Value);

            FrmPresentacionActualiza frmPresent = new FrmPresentacionActualiza();
            //frmPresent.MdiParent = this.MdiParent;
            frmPresent.tipo = 3;
            frmPresent.idPresentacion = idPresSele;
            frmPresent.descripcion = descSele;
            frmPresent.listarPresentacion = listPresenta;
            frmPresent.Text = "Actualizar Presentación De Productos";

            bool bandera = true;

            while (bandera)
            {
                if (frmPresent.ShowDialog() == DialogResult.OK)
                {
                    if (frmPresent.TxtDescripcion.Text == "")
                    {
                        bandera = true;
                    }
                    else
                    {
                        CargarPresentacion();
                        bandera = false;
                    }
                }
                else
                {
                    bandera = false;
                }
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (DgPresentacion.Rows.Count == 0) return;

            List<Presentacion> listPresenta = new List<Presentacion>();
            string ProductoBuscar = Interaction.InputBox("","Buscar Producto...");
            listPresenta = objPresenNeg.ListarBuscarPresentacion(estado, ProductoBuscar);
            DgPresentacion.DataSource = listPresenta;
        }

        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            CargarPresentacion();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            int respuesta = 0;
            
            if (DgPresentacion.RowCount>0)
            {
                string msg = "";
                if (estado) { estado = false; msg = "Eliminar"; }
                else { estado = true; msg = "Activar"; }

                DialogResult res;
                res = MessageBox.Show("¿Desea "+ msg + " el registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    int idPresSele = Convert.ToInt32(DgPresentacion.CurrentRow.Cells[0].Value);
                    respuesta = objPresenNeg.EliminarActivarPresentacion(idPresSele, estado);

                    if (respuesta == 1)
                    {
                        if (estado)
                        {
                            estado = false;
                            MessageBox.Show("Se Activó Correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            estado = true;
                            MessageBox.Show("Se Eliminó Correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        CargarPresentacion();
                    }
                }
            }
            else
            {
                MessageBox.Show("No se registran Presentación para eliminar", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                DgPresentacion.DataSource = listPresenta;
                LblTotal.Text = "Se Encontraron " + DgPresentacion.Rows.Count + " Registros";
            }
            else
            {
                DgPresentacion.DataSource = listPresenta;
            }
        }

        #endregion
    }
}
