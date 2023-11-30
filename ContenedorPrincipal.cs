using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo_grupal_programacion_y_estructuras_de_datos
{
    public partial class Contenedor_Principal : Form
    {
        public Form1 frm1;
        public Contenedor_Principal(Form1 frm1)
        {
            InitializeComponent();
            this.frm1 = frm1;
        }

        private void Contenedor_Principal_Load(object sender, EventArgs e)
        {
            
        }

        private Reportes frmR = null;
        private Agregar frmA = null;
        private Stock frmS = null;
        private Ventas frmV = null;
        private ControlUsuarios frmAU = null;


        private void btnReportes_Click(object sender, EventArgs e)
        {
            if (frmR == null)
            {
                frmR = new Reportes();
                frmR.TopLevel = false;
                frmR.Dock = DockStyle.Fill;
                this.panelContenedor.Controls.Add(frmR);
            }
            frmR.BringToFront();
            frmR.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (frmA == null)
            {
                frmA = new Agregar();
                frmA.TopLevel = false;
                frmA.Dock = DockStyle.Fill;
                this.panelContenedor.Controls.Add(frmA);
            }
            frmA.BringToFront();
            frmA.Show();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            if (frmS == null)
            {
                frmS = new Stock();
                frmS.TopLevel = false;
                frmS.Dock = DockStyle.Fill;
                this.panelContenedor.Controls.Add(frmS);
            }
            frmS.BringToFront();
            frmS.Show();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            if (frmV == null)
            {
                frmV = new Ventas();
                frmV.TopLevel = false;
                frmV.Dock = DockStyle.Fill;
                this.panelContenedor.Controls.Add(frmV);
            }
            frmV.BringToFront();
            frmV.Show();
        }

        private void btnControlUsuarios_Click(object sender, EventArgs e)
        {
            if (frmAU == null)
            {
                frmAU = new ControlUsuarios();
                frmAU.TopLevel = false;
                frmAU.Dock = DockStyle.Fill;
                this.panelContenedor.Controls.Add(frmAU);
            }
            frmAU.BringToFront();
            frmAU.Show();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            frm1.cerrarSesion();
        }

        
    }
}
