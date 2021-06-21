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
using Entidad;
using Negocio;

namespace AppInguiri
{
    public partial class FrmPrincipal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        List<Permiso> listPerm = new List<Permiso>();
        PermisoNegocio objPermNeg = new PermisoNegocio();

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

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            HabilitarMenu(false);
            ValidarPermisosUsuario();
        }

        private void ValidarPermisosUsuario()
        {
            listPerm = objPermNeg.ListarPermiso(CodUsuario.Caption);

            if (listPerm.Count == 0) return;

            foreach (var elemento in Ribbon.Items)
            {
                var TipoElemento = elemento.GetType();

                if (TipoElemento.FullName == "DevExpress.XtraBars.BarButtonItem")
                {
                    BarButtonItem barButton = (BarButtonItem)elemento;

                    if (barButton.Tag != null)
                    {
                        foreach (var permiso in listPerm)
                        {
                            if (Convert.ToInt32(barButton.Tag) == permiso.nTag)
                            {
                                barButton.Enabled = true;
                                break;
                            }
                            else
                            {
                                barButton.Enabled = false;
                            }
                        }
                    }
                }
            }
        }

        private void HabilitarMenu(bool bHabilitar)
        {
            foreach (var elemento in Ribbon.Items)
            {
                var TipoElemento = elemento.GetType();

                if (TipoElemento.FullName == "DevExpress.XtraBars.BarButtonItem")
                {
                    BarButtonItem barButton = (BarButtonItem)elemento;
                    if (bHabilitar)
                        barButton.Enabled = true;
                    barButton.Enabled = false;
                }
            }
        }
    }
}