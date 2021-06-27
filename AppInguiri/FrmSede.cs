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
    public partial class FrmSede : Form
    {
        #region Variables Privadas
        private SedeNegocio objSedeNeg = new SedeNegocio();
        private List<Sede> listSede = new List<Sede>();
        private bool estado = true;
        #endregion

        #region Principal Load

        public FrmSede()
        {
            InitializeComponent();
        }

        private void FrmPresentacion_Load(object sender, EventArgs e)
        {
            CargarSede();
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
            CargarSede();
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

            CargarSede();

        }
    
        #endregion

        #region Metodo Privados
        private void CargarSede()
        {
            listSede.Clear();
            listSede = objSedeNeg.ListarSede(estado);

            if (listSede.Count() > 0)
            {
                DgvSede.AutoGenerateColumns = false;
                DgvSede.DataSource = listSede;
                LblTotal.Text = "Se Encontraron " + DgvSede.Rows.Count + " Registros";
            }
            else
            {
                DgvSede.DataSource = listSede;
            }
        }
        private void Eliminar()
        {
            int respuesta = 0;

            if (DgvSede.RowCount > 0)
            {
                string msg = "";
                if (estado) { estado = false; msg = "Eliminar"; }
                else { estado = true; msg = "Activar"; }

                DialogResult res;
                res = MessageBox.Show("¿Desea " + msg + " el registro?", "InguiriSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    int idSedeSele = Convert.ToInt32(DgvSede.CurrentRow.Cells[0].Value);

                    Sede objSede = new Sede()
                    {
                        nIdSede = idSedeSele,
                        sUsuario = Funciones.UsuarioActual(),
                        bEstado=estado
                    };

                    respuesta = objSedeNeg.EliminarActivarSede(objSede);

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
                        CargarSede();
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
                    MessageBox.Show("No se registran Presentación para eliminar", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    MessageBox.Show("No se registran Presentación para Activar", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void Buscar()
        {
            if (DgvSede.Rows.Count == 0) return;

            List<Sede> listSede = new List<Sede>();
            string ProductoBuscar = Interaction.InputBox("", "Buscar Sede...");
            listSede = objSedeNeg.ListarBuscarSede(estado, ProductoBuscar);
            DgvSede.DataSource = listSede;
            LblTotal.Text = "Se Encontraron " + DgvSede.Rows.Count + " Registros";
        }
        private void Modificar()
        {
            if (DgvSede.Rows.Count == 0) return;

            int idSedeSele = Convert.ToInt32(DgvSede.CurrentRow.Cells[0].Value);
            string descSele = Convert.ToString(DgvSede.CurrentRow.Cells[1].Value);
            string direSele = Convert.ToString(DgvSede.CurrentRow.Cells[2].Value);

            FrmSedeActualiza frmSede = new FrmSedeActualiza();
            frmSede.tipo = 3;
            frmSede.idSede = idSedeSele;
            frmSede.descripcion = descSele;
            frmSede.direccion = direSele;
            frmSede.Text = "Actualizar Sede";
            
            if (frmSede.ShowDialog() == DialogResult.OK)
            {
                CargarSede();
            }
        }
        //validar que solo se acepten letras en la descripcion
        private void Agregar()
        {
            FrmSedeActualiza frmSede = new FrmSedeActualiza();
            //frmPresent.MdiParent = this.MdiParent;
            frmSede.tipo = 2;
            frmSede.Text = "Registar Sede";
       
            if (frmSede.ShowDialog() == DialogResult.OK)
            {
                CargarSede();
            }
        }
        #endregion
    }
}
