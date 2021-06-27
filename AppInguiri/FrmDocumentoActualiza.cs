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
    public partial class FrmDocumentoActualiza : Form
    {
        DocumentoNegocio objDocumentNeg = new DocumentoNegocio();
        public int tipo=0;
        public string idDoc = "";
        public string descripcion = "";
        public string abreviatura="";
        private bool cerrarFormulario = true;

        public FrmDocumentoActualiza()
        {
            InitializeComponent();
        }

        private bool Validar()
        {
            bool resp = true;
            if (txtDescripcion.Text.Equals(""))
            {
                MessageBox.Show("El campo Descripción se encuentra vacía, por favor ingrese un valor", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }

            else if (txtAbreviatura.Text.Equals(""))
            {
                MessageBox.Show("El campo Abreviatura se encuentra vacía, por favor ingrese un valor", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }

            else if (tipo == 2)
            {
                if (txtCodigo.Text.Equals(""))
                {
                    MessageBox.Show("El campo Codigo se encuentra vacía, por favor ingrese un valor", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    resp = false;
                }
            }

            cerrarFormulario = resp;
            return resp;
        }


        private void CmdGuardar_Click(object sender, EventArgs e)
        {
            int respuesta = 0;
            string idDocSele="";
            string descSele = "";
            string abrevi = "";

            if (!Validar()) return;
            if (tipo == 2)
            {
                descSele = txtDescripcion.Text;
                abrevi = txtAbreviatura.Text;

                Documento objPre = new Documento()
                {
                    sDescripcion = descSele,
                    sAbreviatura=abrevi,
                    sUsuario = Funciones.UsuarioActual()
                };

                respuesta = objDocumentNeg.RegistrarDocumento(objPre);

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
                idDocSele = txtCodigo.Text;
                descSele = txtDescripcion.Text;
                abrevi = txtAbreviatura.Text;

                Documento objDoc = new Documento()
                {
                    sIdDocumento= idDocSele,
                    sDescripcion = descSele,
                    sAbreviatura= abrevi,
                    sUsuario = Funciones.UsuarioActual()
                };

                respuesta = objDocumentNeg.ActualizarDocumento(objDoc);

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
                txtCodigo.Enabled = true;
            }
            else
            {
                //Actualizar
                txtCodigo.Text = Convert.ToString(idDoc.ToString());
                txtDescripcion.Text = descripcion.ToString();
                txtAbreviatura.Text = abreviatura.ToString();
            }
        }

        private void FrmDocumentoActualiza_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrarFormulario) e.Cancel = false;
            else e.Cancel = true;
        }
        
    }
}
