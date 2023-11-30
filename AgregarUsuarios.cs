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
        private bool elUsuarioExiste()
        {
            FileStream FS = new FileStream("Usuarios.txt", FileMode.OpenOrCreate);
            StreamReader SR = new StreamReader(FS);
            string linea;
            string[] datos;
            while (!(SR.Peek() == -1))
            {
                linea = SR.ReadLine();
                datos = linea.Split(';');
                if (txtUsuario.Text == datos[0])
                {
                    SR.Close();
                    FS.Close();
                    return true;
                }
            }
            SR.Close();
            FS.Close();
            return false;   
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnAgregar.PerformClick();

                e.Handled = true;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" || txtContrasena.Text == "" || txtRepetirContrasena.Text == "")
            {
                MessageBox.Show("Debe llenar todos los campos", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (txtUsuario.Text == "")
                {
                    txtUsuario.Focus();
                }
                else if (txtContrasena.Text == "")
                {
                    txtContrasena.Focus();
                }
                else if (txtRepetirContrasena.Text == "")
                {
                    txtRepetirContrasena.Focus();
                }
            }
            else if (elUsuarioExiste())
            {
                MessageBox.Show("El usuario ya existe", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtContrasena.Text != txtRepetirContrasena.Text)
            {
                MessageBox.Show("La contraseña debe ser igual en ambos campos", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FileStream FS = new FileStream("Usuarios.txt", FileMode.Append);
                StreamWriter SW = new StreamWriter(FS);
                string permisos;
                if (chbAdmin.Checked)
                {
                    permisos = "admin";
                }
                else
                {
                    permisos = "user";
                }
                string linea = txtUsuario.Text + ";" + txtContrasena.Text + ";" + permisos;
                SW.WriteLine(linea);
                SW.Close();
                FS.Close();
            }
        }
    }
}
    