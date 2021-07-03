using Comun;
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

namespace AppInguiri
{
    public partial class FrmDocumentoSerieActualiza : Form
    {
        DocumentoNegocio objDocumentNeg = new DocumentoNegocio();
        DocumentoSerieNegocio objDocumentSerieNeg = new DocumentoSerieNegocio();

        public int tipo=0;
        public int idSerie = 0;
        public string sidDoc="";
        public string sSerie = "";
        private bool cerrarFormulario = true;

        public FrmDocumentoSerieActualiza()
        {
            InitializeComponent();
            LLenarMaestro();
        }

        private void LLenarMaestro()
        {
            List<Documento> lis = objDocumentNeg.ListarDocumento(true);
            cboDocumentoSerie.ValueMember = "sIdDocumento";
            cboDocumentoSerie.DisplayMember = "sDescripcion";
            cboDocumentoSerie.DataSource = lis;
        }

        private bool Validar()
        {
            bool resp = true;
            if (txtSerie.Text.Equals(""))
            {
                MessageBox.Show("El campo Descripción se encuentra vacía, por favor ingrese un valor", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
            
            cerrarFormulario = resp;
            return resp;
        }


        private void CmdGuardar_Click(object sender, EventArgs e)
        {
            int respuesta = 0;
            string idDocSele="";
            string descSele = "";

            if (!Validar()) return;
            if (tipo == 2)
            {
                descSele = txtSerie.Text;

                DocumentoSerie objPre = new DocumentoSerie()
                {
                    nIdDocumentoSerie= idSerie,
                    sSerie = descSele,
                    sIdDocumento=cboDocumentoSerie.SelectedValue.ToString(),
                    sUsuario = Funciones.UsuarioActual()
                };

                respuesta = objDocumentSerieNeg.RegistrarDocumentoSerie(objPre);

                if (respuesta == 1)
                {
                    MessageBox.Show("Se Registro Correctamente", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cerrarFormulario = true;
                }
                else
                {
                    MessageBox.Show("No se Registro Correctamente", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cerrarFormulario = false;
                }
            }
            else
            {
                descSele = txtSerie.Text;

                DocumentoSerie objPre = new DocumentoSerie()
                {
                    nIdDocumentoSerie= idSerie,
                    sSerie= descSele,
                    sIdDocumento = cboDocumentoSerie.SelectedValue.ToString(),
                    sUsuario = Funciones.UsuarioActual()
                };

                respuesta = objDocumentSerieNeg.ActualizarDocumentoSerie(objPre);

                if (respuesta == 1)
                {
                    MessageBox.Show("Se Actualizó Correctamente", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cerrarFormulario = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se Actualizó Correctamente", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cerrarFormulario = false;
                }

            }
        }

        private void CmdCancelar_Click(object sender, EventArgs e)
        {
            cerrarFormulario = true;
            this.Close();
        }
        
        private void FrmDocumentoActualiza_Load(object sender, EventArgs e)
        {
            if (tipo == 2)
            {
                LblCodigo.Text = "AUTOGENERADO";
                LblCodigo.Enabled = true;
            }
            else
            {
                //Actualizar
                LblCodigo.Text =idSerie.ToString();
                txtSerie.Text = sSerie;
                txtSerie.SelectionStart = txtSerie.Text.Length;
                txtSerie.Focus();
                cboDocumentoSerie.SelectedValue = sidDoc;
                
            }
        }

        private void FrmDocumentoActualiza_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrarFormulario) e.Cancel = false;
            else e.Cancel = true;
        }
        
    }
}
