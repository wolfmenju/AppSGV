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
        NegPresentacion objPresenNeg =new NegPresentacion();
        List<Presentacion> listPresenta = new List<Presentacion>();

        public FrmPresentacion()
        {
            InitializeComponent();
        }

        private void FrmPresentacion_Load(object sender, EventArgs e)
        {
            CargarPresentacion();
        }

        private void CargarPresentacion()
        {
            bool activo =true;
            listPresenta = objPresenNeg.ListarPresentacion(activo);

            if (listPresenta.Count() > 0)
            {
                DgPresentacion.DataSource = listPresenta;
            }
            else
            {
                BtnModificar.Enabled = false;
                BtnEliminar.Enabled = false;
                BtnRefrescar.Enabled = false;
                BtnBuscar.Enabled = false;
                DgPresentacion.DataSource = listPresenta;
            }
        }

        private void FrmPresentacion_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                     BtnAgregar_Click(sender,e);
                    break;
                case Keys.F2:
                    BtnModificar_Click(sender,e);
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
            List<Presentacion> listPresenta = new List<Presentacion>();
            string ProductoBuscar = Interaction.InputBox("","Buscar Producto...");
            listPresenta = objPresenNeg.ListarBuscarPresentacion(true, ProductoBuscar);
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
                int idPresSele = Convert.ToInt32(DgPresentacion.CurrentRow.Cells[0].Value);
                respuesta = objPresenNeg.EliminarPresentacion(idPresSele);

                if (respuesta == 1)
                {
                    MessageBox.Show("Se Eliminó Correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarPresentacion();
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
    }
}
