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
    public partial class FrmAlmacen : Form
    {
        #region Variables Privadas
        private AlmacenNegocio objAlmNeg = new AlmacenNegocio();
        private List<Almacen> listAlm = new List<Almacen>();
        private bool estado = true;
        #endregion

        #region Principal Load

        public FrmAlmacen()
        {
            InitializeComponent();
        }

        private void FrmAlmacen_Load(object sender, EventArgs e)
        {
            CargarAlmacen();
        }

        #endregion

        #region Eventos

        private void FrmAlmacen_KeyDown(object sender, KeyEventArgs e)
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
            CargarAlmacen();
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

            CargarAlmacen();

        }
    
        #endregion

        #region Metodo Privados
        private void CargarAlmacen()
        {
            listAlm.Clear();
            listAlm = objAlmNeg.ListarAlmacen(estado);

            if (listAlm.Count() > 0)
            {
                DgvAlmacen.AutoGenerateColumns = false;
                DgvAlmacen.DataSource = listAlm;
                LblTotal.Text = "Se Encontraron " + DgvAlmacen.Rows.Count + " Registros";
            }
            else
            {
                DgvAlmacen.DataSource = listAlm;
            }
        }
        private void Eliminar()
        {
            int respuesta = 0;

            if (DgvAlmacen.RowCount > 0)
            {
                string msg = "";
                if (estado) { estado = false; msg = "Eliminar"; }
                else { estado = true; msg = "Activar"; }

                DialogResult res;
                res = MessageBox.Show("¿Desea " + msg + " el registro?", "InguiriSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    int idAlmSele = Convert.ToInt32(DgvAlmacen.CurrentRow.Cells[0].Value);

                    Almacen objAlm = new Almacen()
                    {
                        nIdSede = idAlmSele,
                        sUsuario = Funciones.UsuarioActual(),
                        bEstado=estado
                    };

                    respuesta = objAlmNeg.EliminarActivarAlmacen(objAlm);

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

                        CargarAlmacen();
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
                    MessageBox.Show("No se registran Almacén para eliminar", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    MessageBox.Show("No se registran Almacén para Activar", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void Buscar()
        {
            if (DgvAlmacen.Rows.Count == 0) return;

            List<Almacen> listAlm = new List<Almacen>();
            string AlmacenBuscar = Interaction.InputBox("", "Buscar Almacen...");

            if (!AlmacenBuscar.Equals(""))
            {
                listAlm = objAlmNeg.ListarBuscarAlmacen(estado, AlmacenBuscar.Trim());
                DgvAlmacen.DataSource = listAlm;
                LblTotal.Text = "Se Encontraron " + DgvAlmacen.Rows.Count + " Registros";
            }
        }
        private void Modificar()
        {
            if (DgvAlmacen.Rows.Count == 0) return;

            int idAlmSele = Convert.ToInt32(DgvAlmacen.CurrentRow.Cells[0].Value);
            string descSele = Convert.ToString(DgvAlmacen.CurrentRow.Cells[1].Value);
            string direSele = Convert.ToString(DgvAlmacen.CurrentRow.Cells[2].Value);

            FrmAlmacenActualiza frmAlm = new FrmAlmacenActualiza();
            frmAlm.tipo = 3;
            frmAlm.idSede = idAlmSele;
            frmAlm.descripcion = descSele;
            frmAlm.direccion = direSele;
            frmAlm.Text = "Actualizar Almacén";
            
            if (frmAlm.ShowDialog() == DialogResult.OK)
            {
                CargarAlmacen();
            }
        }
        //validar que solo se acepten letras en la descripcion
        private void Agregar()
        {
            FrmAlmacenActualiza frmAlm = new FrmAlmacenActualiza();
            //frmPresent.MdiParent = this.MdiParent;
            frmAlm.tipo = 2;
            frmAlm.Text = "Registar Almacen";
       
            if (frmAlm.ShowDialog() == DialogResult.OK)
            {
                CargarAlmacen();
            }
        }
        #endregion
        
    }
}
