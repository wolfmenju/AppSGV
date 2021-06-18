using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace AppInguiri
{
    public partial class FrmPrincipal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void barBtnPresentacion_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmPresentacion fr = new FrmPresentacion();
            fr.MdiParent = this;
            fr.Show();
        }

        private void barBtnProveedor_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmProveedor fr = new FrmProveedor();
            fr.MdiParent = this;
            fr.Show();
        }

        private void barBtnUsuario_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmUsuario fr = new FrmUsuario();
            fr.MdiParent = this;
            fr.Show();
        }
    }
}