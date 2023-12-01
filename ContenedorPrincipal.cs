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

        private Reportes frmR = null;
        private Stock frmS = null;
        private Ventas frmV = null;
        private ControlUsuarios frmU = null;

        private void Contenedor_Principal_Load(object sender, EventArgs e)
        {
            frmR = new Reportes();
            frmR.TopLevel = false;
            frmR.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(frmR);
            frmR.Show();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            frmR.BringToFront();
            frmR.Show();
            frmR.actualizar();
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
            frmS.ListarProductos();
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
            frmV.ListarProductos();
        }

        private void btnControlUsuarios_Click(object sender, EventArgs e)
        {
            if (frmU == null)
            {
                frmU = new ControlUsuarios();
                frmU.TopLevel = false;
                frmU.Dock = DockStyle.Fill;
                this.panelContenedor.Controls.Add(frmU);
            }
            frmU.BringToFront();
            frmU.Show();
            frmU.listar();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            frm1.cerrarSesion();
        }

        
    }
}
