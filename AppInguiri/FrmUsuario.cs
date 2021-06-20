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
    public partial class FrmUsuario : Form
    {
        #region Variables Privadas
        UsuarioNegocio objUserNeg =new UsuarioNegocio();
        List<Usuario> listUsuario = new List<Usuario>();
        bool estado = true;
        #endregion
        
        #region Principal Load

        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            CargarUsuario();
        }

        #endregion

        #region Eventos

        private void FrmUsuario_KeyDown(object sender, KeyEventArgs e)
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
            Resetear();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            CargarUsuario();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
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

            CargarUsuario();
        }
        #endregion

        #region Metodo Privados
        private void CargarUsuario()
        {
            listUsuario.Clear();
            listUsuario = objUserNeg.ListarUsuario(estado);

            if (listUsuario.Count() > 0)
            {
                DgvUsuario.AutoGenerateColumns = false;
                DgvUsuario.DataSource = listUsuario;
                LblTotal.Text = "Se Encontraron " + DgvUsuario.Rows.Count + " Registros";
            }
            else
            {
                DgvUsuario.DataSource = listUsuario;
            }
        }
        private void Buscar()
        {
            if (DgvUsuario.Rows.Count == 0) return;

            List<Usuario> listUsuario = new List<Usuario>();
            string UsuarioBuscar = Interaction.InputBox("", "Buscar Usuario...");
            listUsuario = objUserNeg.ListarBuscarUsuario(estado, UsuarioBuscar);
            DgvUsuario.DataSource = listUsuario;
            LblTotal.Text = "Se Encontraron " + DgvUsuario.Rows.Count + " Registros";
        }
        private void Eliminar()
        {
            int respuesta = 0;

            if (DgvUsuario.RowCount > 0)
            {
                string msg = "";
                if (estado) { estado = false; msg = "Eliminar"; }
                else { estado = true; msg = "Activar"; }

                DialogResult res;
                res = MessageBox.Show("¿Desea " + msg + " el registro?", "InguiriSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    int idPresSele = Convert.ToInt32(DgvUsuario.CurrentRow.Cells[0].Value);
                    respuesta = objUserNeg.EliminarActivarUsuario(idPresSele, estado);

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

                        CargarUsuario();
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
                    MessageBox.Show("No se registran Usuario para eliminar", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    MessageBox.Show("No se registran Usuario para Activar", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void Agregar()
        {
            FrmUsuarioActualiza frmUsuario = new FrmUsuarioActualiza();
            frmUsuario.tipo = 2;
            frmUsuario.Text = "Registar Usuario";
            frmUsuario.listarUsuario = listUsuario;

            if (frmUsuario.ShowDialog() == DialogResult.OK)
            {
                CargarUsuario();
            }
        }
        private void Resetear()
        {
            int respuesta = 0;

            if (DgvUsuario.RowCount > 0)
            {
                DialogResult res;
                res = MessageBox.Show("¿Desea resetear la clave del usuario?", "InguiriSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    string slogin = Convert.ToString(DgvUsuario.CurrentRow.Cells[2].Value);
                    Usuario objuser = new Usuario()
                    {
                        sClave = "inguiri",
                        sLogin = slogin
                    };

                    respuesta = objUserNeg.ResearUsuario(objuser);

                    if (respuesta == 1)
                    {
                        MessageBox.Show("Se reseteo la contraseña correctamente", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se reseteo correctamente", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("No se registran Usuarios", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

    }
}
