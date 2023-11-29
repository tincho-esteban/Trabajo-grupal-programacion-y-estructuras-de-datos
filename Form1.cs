using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo_grupal_programacion_y_estructuras_de_datos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public inicio_sesion frmInicio = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            frmInicio = new inicio_sesion(this);
            frmInicio.MdiParent = this;
            frmInicio.Show();
            frmInicio.Dock = DockStyle.Fill;
        }

        public void abrirFormulario()
        {
            frmInicio.Close();
            Contenedor_Principal frmCont = new Contenedor_Principal();
            frmCont.MdiParent = this;
            frmCont.Show();
            frmCont.Dock = DockStyle.Fill;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
