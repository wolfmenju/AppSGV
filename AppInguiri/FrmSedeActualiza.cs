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
    public partial class FrmSedeActualiza : Form
    {
        SedeNegocio objSedeNeg = new SedeNegocio();
        public int tipo=0;
        public int idSede = 0;
        public string descripcion = "";
        public string direccion = "";
        private bool cerrarFormulario = true;

        public FrmSedeActualiza()
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
            else if (txtDireccion .Text.Equals(""))
            {
                MessageBox.Show("El campo Dirección se encuentra vacía, por favor ingrese un valor", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }

            cerrarFormulario = resp;
            return resp;
        }


        private void CmdGuardar_Click(object sender, EventArgs e)
        {
            int respuesta = 0, idSedeSele = 0;
            string descSele = "", direSele="";

            if (!Validar()) return;
            if (tipo == 2)
            {
                descSele = txtDescripcion.Text;
                direSele = txtDireccion.Text;

                Sede objSede = new Sede()
                {
                    sDescripcion = descSele,
                    sDireccion= direSele,
                    sUsuario = Funciones.UsuarioActual()
                };

                respuesta = objSedeNeg.RegistrarSede(objSede);

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
                idSedeSele = Convert.ToInt32(LblCodigo.Text);
                descSele = txtDescripcion.Text;
                direSele = txtDireccion.Text;

                Sede objSede = new Sede()
                {
                    nIdSede= idSedeSele,
                    sDescripcion = descSele,
                    sDireccion=direSele,
                    sUsuario = Funciones.UsuarioActual()
                };

                respuesta = objSedeNeg.ActualizarSede(objSede);

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
        private void FrmSedeActualiza_Load(object sender, EventArgs e)
        {
            if (tipo == 2)
            {
                LblCodigo.Text = "AUTOGENERADO";
            }
            else
            {
                //Actualizar
                LblCodigo.Text = Convert.ToString(idSede.ToString());
                txtDescripcion.Text = descripcion.ToString();
                txtDireccion.Text = direccion.ToString();
            }
        }

        private void FrmSedeActualiza_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrarFormulario) e.Cancel = false;
            else e.Cancel = true;
        }
    }
}
