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
    public partial class FrmUsuarioActualiza : Form
    {
        UsuarioNegocio objUserNeg = new UsuarioNegocio();
        public int tipo=0;
        public List<Usuario> listarUsuario = null;
        private bool cerrarFormulario = true;
        
        public FrmUsuarioActualiza()
        {
            InitializeComponent();
        }

        private bool Validar()
        {
            bool resp = true;
            if (txtNombres.Text.Equals(""))
            {
                MessageBox.Show("El campo Nombres se encuentra vacía, por favor ingrese un valor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
            else if (txtDni.Text.Equals(""))
            {
                MessageBox.Show("El campo Dni se encuentra vacía, por favor ingrese un valor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
            else if (txtDireccion.Text.Equals(""))
            {
                MessageBox.Show("El campo Dirección se encuentra vacía, por favor ingrese un valor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
            else if (txtCelular.Text.Equals(""))
            {
                MessageBox.Show("El campo Celular se encuentra vacía, por favor ingrese un valor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
            else if (txtLogin.Text.Equals(""))
            {
                MessageBox.Show("El campo Login se encuentra vacía, por favor ingrese un valor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
            else if (txtClave.Text.Equals(""))
            {
                MessageBox.Show("El campo Clave se encuentra vacía, por favor ingrese un valor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }

            cerrarFormulario = resp;
            return resp;
        }

        private void CmdGuardar_Click(object sender, EventArgs e)
        {
            int respuesta = 0;
            
            if (tipo == 2)
            {
                if (Validar())
                {
                    Usuario objUser = new Usuario();
                    objUser.sNombres = txtNombres.Text.ToUpper().Trim();
                    objUser.sDni = txtDni.Text.ToUpper().Trim();
                    objUser.sDireccion=txtDireccion.Text.ToUpper().Trim();
                    objUser.sCelular = txtCelular.Text.ToUpper().Trim();
                    objUser.sLogin = txtLogin.Text.ToUpper().Trim();
                    objUser.sClave = txtClave.Text.ToUpper().Trim();

                    respuesta = objUserNeg.RegistrarUsuario(objUser);

                    if (respuesta == 1)
                    {
                        MessageBox.Show("Se Registro Correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se Registro Correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cerrarFormulario = false;
                    }
                }
            }
        }

        private void FrmUsuarioActualiza_Load(object sender, EventArgs e)
        {
            if (tipo == 2)
            {
                LblCodigo.Text = "AUTOGENERADO";
            }
            else
            {
                //Actualizar
                //LblCodigo.Text = Convert.ToString(idPresentacion.ToString());
                //TxtDescripcion.Text = descripcion.ToString();
            }
        }

        private void CmdCancelar_Click(object sender, EventArgs e)
        {
            cerrarFormulario = true;
            this.Close();
        }


        private void FrmUsuarioActualiza_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrarFormulario) e.Cancel = false;
            else e.Cancel = true;
        }
        
    }
}
