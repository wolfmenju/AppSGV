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
    }
}