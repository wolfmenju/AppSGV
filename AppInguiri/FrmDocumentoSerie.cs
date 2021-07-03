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
    public partial class FrmDocumentoSerie : Form
    {
        #region Variables Privadas
        private DocumentoSerieNegocio objDocumentSerieNeg = new DocumentoSerieNegocio();
        private List<DocumentoSerie> listDocumentoSerie = new List<DocumentoSerie>();
        private bool estado = true;
        #endregion

        #region Principal Load

        public FrmDocumentoSerie()
        {
            InitializeComponent();
        }
        
        private void FrmDocumentoSerie_Load(object sender, EventArgs e)
        {
            CargarDocumentoSerie();
        }

        #endregion

        #region Eventos
        
        private void FrmDocumentoSerie_KeyDown(object sender, KeyEventArgs e)
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
            CargarDocumentoSerie();
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

            CargarDocumentoSerie();

        }
    
        #endregion

        #region Metodo Privados
        private void CargarDocumentoSerie()
        {
            listDocumentoSerie.Clear();
            listDocumentoSerie = objDocumentSerieNeg.ListarDocumentoSerie(estado);

            if (listDocumentoSerie.Count() > 0)
            {
                DgvDocumentoSerie.AutoGenerateColumns = false;
                DgvDocumentoSerie.DataSource = listDocumentoSerie;
                LblTotal.Text = "Se Encontraron " + DgvDocumentoSerie.Rows.Count + " Registros";
            }
            else
            {
                DgvDocumentoSerie.DataSource = listDocumentoSerie;
            }
        }
        private void Eliminar()
        {
            int respuesta = 0;

            if (DgvDocumentoSerie.RowCount > 0)
            {
                string msg = "";
                if (estado) { estado = false; msg = "Eliminar"; }
                else { estado = true; msg = "Activar"; }

                DialogResult res;
                res = MessageBox.Show("¿Desea " + msg + " el registro?", "InguiriSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    int idSerieSele =Convert.ToInt32(DgvDocumentoSerie.CurrentRow.Cells[0].Value.ToString());

                    DocumentoSerie objDoc= new DocumentoSerie()
                    {
                        nIdDocumentoSerie = idSerieSele,
                        bEstado = estado,
                        sUsuario = Funciones.UsuarioActual()
                    };
                    
                    respuesta = objDocumentSerieNeg.EliminarActivarDocumentoSerie(objDoc);

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

                        CargarDocumentoSerie();
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
            if (DgvDocumentoSerie.Rows.Count == 0) return;

            List<DocumentoSerie> listDocumentoSerie = new List<DocumentoSerie>();
            string DocBuscar = Interaction.InputBox("", "Buscar Serie...");

            if (!DocBuscar.Equals(""))
            {
                listDocumentoSerie = objDocumentSerieNeg.ListarBuscarDocumentoSerie(estado, DocBuscar.Trim());
                DgvDocumentoSerie.DataSource = listDocumentoSerie;
                LblTotal.Text = "Se Encontraron " + DgvDocumentoSerie.Rows.Count + " Registros";
            }
        }
        private void Modificar()
        {
            if (DgvDocumentoSerie.Rows.Count == 0) return;

            int idSerieSele = Convert.ToInt32(DgvDocumentoSerie.CurrentRow.Cells[0].Value.ToString());
            string sDocSele =  DgvDocumentoSerie.CurrentRow.Cells[1].Value.ToString();
            string sSerie = DgvDocumentoSerie.CurrentRow.Cells[3].Value.ToString();

            FrmDocumentoSerieActualiza frmDocument = new FrmDocumentoSerieActualiza();
            //frmPresent.MdiParent = this.MdiParent;
            frmDocument.tipo = 3;
            frmDocument.idSerie = idSerieSele;
            frmDocument.sidDoc = sDocSele;
            frmDocument.sSerie = sSerie;
            frmDocument.Text = "Actualizar Serie";
            
            if (frmDocument.ShowDialog() == DialogResult.OK)
            {
                CargarDocumentoSerie();
            }

        }
        //validar que solo se acepten letras en la descripcion
        private void Agregar()
        {
            FrmDocumentoSerieActualiza frmDocument = new FrmDocumentoSerieActualiza();
            //frmPresent.MdiParent = this.MdiParent;
            frmDocument.tipo = 2;
            frmDocument.Text = "Registar Serie";

            if (frmDocument.ShowDialog() == DialogResult.OK)
            {
                CargarDocumentoSerie();
            }
        }
        #endregion
        
    }
}
