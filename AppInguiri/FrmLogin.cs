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
    public partial class FrmLogin : Form
    {
        #region Variables Privadas
        AlmacenNegocio objAlmacNeg = new AlmacenNegocio();
        List<Almacen> listAlmac = new List<Almacen>();
        UsuarioNegocio objUserNeg = new UsuarioNegocio();

        #endregion

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            CargarAlmacen();
        }

        #region Metodos Privados
        private void CargarAlmacen()
        {
            listAlmac = objAlmacNeg.ListarAlmacen();

            if(listAlmac.Count>0)
            {
                cbxAlmacen.ValueMember = "nIdAlmacen";
                cbxAlmacen.DisplayMember = "sDescripcion";
                cbxAlmacen.DataSource = listAlmac;
            }
        }
        #endregion

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            InicioSession();
        }
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Metodo Privados

        private void InicioSession()
        {
            if (!Validar()) return;
            
            Usuario user = objUserNeg.IniciarSesionUsuario(txtUsuario.Text.Trim(),txtClave.Text.Trim());

            if (user != null)
            {
                this.Hide();
                FrmPrincipal frmPrin = new FrmPrincipal();
                frmPrin.CodAlmacen.Caption = cbxAlmacen.SelectedValue.ToString();
                frmPrin.NomAlmacen.Caption = cbxAlmacen.Text.ToUpper();
                frmPrin.CodUsuario.Caption = user.sLogin.ToUpper();
                frmPrin.NomUsuario.Caption = user.sNombres.ToUpper();
                frmPrin.CodFecha.Caption = user.sDni;
                frmPrin.Show();
            }
            else
            {
                MessageBox.Show("Usuario Y Claves Incorrectas", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool Validar()
        {
            bool resp = true;
            if (txtUsuario.Text.Equals(""))
            {
                MessageBox.Show("El campo Usuario se encuentra vacía, por favor ingrese un valor", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                resp = false;
            }

            if (txtClave.Text.Equals(""))
            {
                MessageBox.Show("El campo Clave se encuentra vacía, por favor ingrese un valor", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.Focus();
                resp = false;
            }
            
            return resp;
        }
        #endregion

    }
}
