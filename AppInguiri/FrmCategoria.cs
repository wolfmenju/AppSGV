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
    public partial class FrmCategoria : Form
    {
        #region Variables Privadas
        private CategoriaNegocio objCategNeg = new CategoriaNegocio();
        private List<Categoria> listCategoria = new List<Categoria>();
        private bool estado = true;
        #endregion

        #region Principal Load

        public FrmCategoria()
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
            listCategoria.Clear();
            listCategoria = objCategNeg.ListarCategoria(estado);

            if (listCategoria.Count() > 0)
            {
                DgvCategoria.AutoGenerateColumns = false;
                DgvCategoria.DataSource = listCategoria;
                LblTotal.Text = "Se Encontraron " + DgvCategoria.Rows.Count + " Registros";
            }
            else
            {
                DgvCategoria.DataSource = listCategoria;
            }
        }
        private void Eliminar()
        {
            int respuesta = 0;

            if (DgvCategoria.RowCount > 0)
            {
                string msg = "";
                if (estado) { estado = false; msg = "Eliminar"; }
                else { estado = true; msg = "Activar"; }

                DialogResult res;
                res = MessageBox.Show("¿Desea " + msg + " el registro?", "InguiriSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    int idCateSele = Convert.ToInt32(DgvCategoria.CurrentRow.Cells[0].Value);

                    Categoria objCat = new Categoria()
                    {
                        nIdCategoria = idCateSele,
                        bEstado = estado,
                        sUsuario = Funciones.UsuarioActual()
                    };

                    respuesta = objCategNeg.EliminarActivarCategoria(objCat);

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
                    MessageBox.Show("No se registran Categoria para eliminar", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    MessageBox.Show("No se registran Categoria para Activar", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void Buscar()
        {
            if (DgvCategoria.Rows.Count == 0) return;

            List<Categoria> listCateg = new List<Categoria>();
            string CategporiaBuscar = Interaction.InputBox("", "Buscar Categoria...");

            if (!CategporiaBuscar.Equals(""))
            {
                listCateg = objCategNeg.ListarBuscarCategoria(estado, CategporiaBuscar);
                DgvCategoria.DataSource = listCateg;
                LblTotal.Text = "Se Encontraron " + DgvCategoria.Rows.Count + " Registros";
            }
        }
        private void Modificar()
        {
            if (DgvCategoria.Rows.Count == 0) return;

            int idCategSele = Convert.ToInt32(DgvCategoria.CurrentRow.Cells[0].Value);
            string descSele = Convert.ToString(DgvCategoria.CurrentRow.Cells[1].Value);

            FrmCategoriaActualiza frmCateg = new FrmCategoriaActualiza();
            //frmPresent.MdiParent = this.MdiParent;
            frmCateg.tipo = 3;
            frmCateg.idCategoria = idCategSele;
            frmCateg.descripcion = descSele;
            frmCateg.listarCategoria =listCategoria;
            frmCateg.Text = "Actualizar Categoria De Productos";

            if (frmCateg.ShowDialog() == DialogResult.OK)
            {
                CargarPresentacion();
            }
        }
        //validar que solo se acepten letras en la descripcion
        private void Agregar()
        {
            FrmCategoriaActualiza frmCateg = new FrmCategoriaActualiza();
            //frmPresent.MdiParent = this.MdiParent;
            frmCateg.tipo = 2;
            frmCateg.Text = "Registar Categoria De Productos";

            if (frmCateg.ShowDialog() == DialogResult.OK)
            {
                CargarPresentacion();
            }
        }
        #endregion
    }
}
