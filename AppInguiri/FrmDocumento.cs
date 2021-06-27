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
    public partial class FrmDocumento : Form
    {
        #region Variables Privadas
        private DocumentoNegocio objDocumentNeg = new DocumentoNegocio();
        private List<Documento> listDocumento = new List<Documento>();
        private bool estado = true;
        #endregion

        #region Principal Load

        public FrmDocumento()
        {
            InitializeComponent();
        }

        private void FrmDocumento_Load(object sender, EventArgs e)
        {
            CargarDocumento();
        }

        #endregion

        private void FrmDocumento_KeyDown(object sender, KeyEventArgs e)
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

        #region Eventos

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
            CargarDocumento();
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

            CargarDocumento();

        }
    
        #endregion

        #region Metodo Privados
        private void CargarDocumento()
        {
            listDocumento.Clear();
            listDocumento = objDocumentNeg.ListarDocumento(estado);

            if (listDocumento.Count() > 0)
            {
                DgvDocumento.AutoGenerateColumns = false;
                DgvDocumento.DataSource = listDocumento;
                LblTotal.Text = "Se Encontraron " + DgvDocumento.Rows.Count + " Registros";
            }
            else
            {
                DgvDocumento.DataSource = listDocumento;
            }
        }
        private void Eliminar()
        {
            int respuesta = 0;

            if (DgvDocumento.RowCount > 0)
            {
                string msg = "";
                if (estado) { estado = false; msg = "Eliminar"; }
                else { estado = true; msg = "Activar"; }

                DialogResult res;
                res = MessageBox.Show("¿Desea " + msg + " el registro?", "InguiriSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    string idDocSele = DgvDocumento.CurrentRow.Cells[0].Value.ToString();

                    Documento objDoc= new Documento()
                    {
                        sIdDocumento = idDocSele,
                        bEstado = estado,
                        sUsuario = Funciones.UsuarioActual()
                    };
                    
                    respuesta = objDocumentNeg.EliminarActivarDocumento(objDoc);

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

                        CargarDocumento();
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
                    MessageBox.Show("No se registran Documento para eliminar", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    MessageBox.Show("No se registran Documento para Activar", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void Buscar()
        {
            if (DgvDocumento.Rows.Count == 0) return;

            List<Documento> listDocumento = new List<Documento>();
            string DocBuscar = Interaction.InputBox("", "Buscar Documento...");

            if (!DocBuscar.Equals(""))
            {
                listDocumento = objDocumentNeg.ListarBuscarDocumento(estado, DocBuscar.Trim());
                DgvDocumento.DataSource = listDocumento;
                LblTotal.Text = "Se Encontraron " + DgvDocumento.Rows.Count + " Registros";
            }
        }
        private void Modificar()
        {
            if (DgvDocumento.Rows.Count == 0) return;

            string idDocSele = DgvDocumento.CurrentRow.Cells[0].Value.ToString();
            string descSele = Convert.ToString(DgvDocumento.CurrentRow.Cells[1].Value);
            string abreSele = Convert.ToString(DgvDocumento.CurrentRow.Cells[2].Value);
            
            FrmDocumentoActualiza frmDocument = new FrmDocumentoActualiza();
            //frmPresent.MdiParent = this.MdiParent;
            frmDocument.tipo = 3;
            frmDocument.idDoc = idDocSele;
            frmDocument.descripcion = descSele;
            frmDocument.abreviatura = abreSele;
            frmDocument.Text = "Actualizar Documento";
            
            if (frmDocument.ShowDialog() == DialogResult.OK)
            {
                CargarDocumento();
            }

        }
        //validar que solo se acepten letras en la descripcion
        private void Agregar()
        {
            FrmDocumentoActualiza frmDocument = new FrmDocumentoActualiza();
            //frmPresent.MdiParent = this.MdiParent;
            frmDocument.tipo = 2;
            frmDocument.Text = "Registar Documento";

            if (frmDocument.ShowDialog() == DialogResult.OK)
            {
                CargarDocumento();
            }
        }
        #endregion

    }
}
