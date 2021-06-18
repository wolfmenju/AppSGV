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
        private UsuarioNegocio objUserNeg =new UsuarioNegocio();
        private List<Usuario> listUsuario = new List<Usuario>();
        private bool estado = true;
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
            FrmUsuarioActualiza frmPresent = new FrmUsuarioActualiza();
            //frmPresent.MdiParent = this.MdiParent;
            frmPresent.tipo = 2;
            frmPresent.Text = "Registar Usuario";
            frmPresent.listarUsuario = listUsuario;
            bool bandera =true;
            frmPresent.ShowDialog();

            //while (bandera)
            //{
            //    if (frmPresent.ShowDialog() == DialogResult.OK)
            //    {
            //        if (frmPresent.TxtDescripcion.Text == "")
            //        {
            //            bandera = true;
            //        }
            //        else
            //        {
            //            CargarUsuario();
            //            bandera = false;
            //        }
            //    }
            //    else
            //    {
            //        bandera = false;
            //    }
            //}
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
        //    if (DgvUsuario.Rows.Count==0) return;

        //    int idPresSele = Convert.ToInt32(DgvUsuario.CurrentRow.Cells[0].Value);
        //    string descSele = Convert.ToString(DgvUsuario.CurrentRow.Cells[1].Value);

        //    FrmPresentacionActualiza frmPresent = new FrmPresentacionActualiza();
        //    //frmPresent.MdiParent = this.MdiParent;
        //    frmPresent.tipo = 3;
        //    frmPresent.idPresentacion = idPresSele;
        //    frmPresent.descripcion = descSele;
        //    frmPresent.listarPresentacion = listPresenta;
        //    frmPresent.Text = "Actualizar Presentación De Productos";

        //    bool bandera = true;

        //    while (bandera)
        //    {
        //        if (frmPresent.ShowDialog() == DialogResult.OK)
        //        {
        //            if (frmPresent.TxtDescripcion.Text == "")
        //            {
        //                bandera = true;
        //            }
        //            else
        //            {
        //                CargarUsuario();
        //                bandera = false;
        //            }
        //        }
        //        else
        //        {
        //            bandera = false;
        //        }
        //    }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            //if (DgvUsuario.Rows.Count == 0) return;
            
            //List<Presentacion> listPresenta = new List<Presentacion>();
            //string ProductoBuscar = Interaction.InputBox("","Buscar Producto...");
            //listPresenta = objPresenNeg.ListarBuscarPresentacion(estado, ProductoBuscar);
            //DgvUsuario.DataSource = listPresenta;
            //LblTotal.Text = "Se Encontraron " + DgvUsuario.Rows.Count + " Registros";

        }

        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            CargarUsuario();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
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

        #endregion
        
    }
}
