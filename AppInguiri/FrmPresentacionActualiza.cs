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
    public partial class FrmPresentacionActualiza : Form
    {
        PresentacionNegocio objPresenNeg = new PresentacionNegocio();
        public int tipo=0;
        public int idPresentacion = 0;
        public string descripcion = "";
        public List<Presentacion> listarPresentacion = null; 

        public FrmPresentacionActualiza()
        {
            InitializeComponent();
        }

        private void CmdGuardar_Click(object sender, EventArgs e)
        {
            int respuesta =0, idPresSele=0;
            string descSele = "";
            
            if (tipo == 2)
            {
                if (Funciones.DatosVacios(TxtDescripcion.Text))
                {
                    MessageBox.Show("Campo esta vacío, por favor ingrese un valor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    descSele = TxtDescripcion.Text;
                    respuesta = objPresenNeg.RegistrarPresentacion(descSele);

                    if (respuesta == 1)
                    {
                        MessageBox.Show("Se Registro Correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se Registro Correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                if (Funciones.DatosVacios(TxtDescripcion.Text))
                {
                    MessageBox.Show("Campo esta vacío, por favor ingrese un valor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    idPresSele = Convert.ToInt32(LblCodigo.Text);
                    descSele = TxtDescripcion.Text;
                    respuesta = objPresenNeg.ActualizarPresentacion(idPresSele, descSele);

                    if (respuesta == 1)
                    {
                        MessageBox.Show("Se Actualizó Correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }

        private void CmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPresentacionNuevo_Load(object sender, EventArgs e)
        {
            if (tipo == 2)
            {
                //Insertar
            }
            else
            {
                //Actualizar
                LblCodigo.Text = Convert.ToString(idPresentacion.ToString());
                TxtDescripcion.Text = descripcion.ToString();
            }
        }
    }
}
