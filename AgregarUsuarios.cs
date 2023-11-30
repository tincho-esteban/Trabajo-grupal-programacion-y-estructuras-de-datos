using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo_grupal_programacion_y_estructuras_de_datos
{
    public partial class AgregarUsuarios : Form
    {
        public AgregarUsuarios()
        {
            InitializeComponent();
        }
        bool click = false;
        private void imgContrasena_Click(object sender, EventArgs e)
        {
            if (click == false)
            {
                string img = Path.Combine(Application.StartupPath, "img/ojoAbierto.png");
                imgContrasena.Image = Image.FromFile(img);
                txtContrasena.PasswordChar = '\0';
                txtRepetirContrasena.PasswordChar = '\0';
                click = true;
            }
            else
            {
                string img = Path.Combine(Application.StartupPath, "img/ojoCerrado.png");
                imgContrasena.Image = Image.FromFile(img);
                txtContrasena.PasswordChar = '*';
                txtRepetirContrasena.PasswordChar = '*';
                click = false;
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
