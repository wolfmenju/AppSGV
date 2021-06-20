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

        private void CmdGuardar_Click(object sender, EventArgs e)
        {

        }

        private void CmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
