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
    public partial class inicio_sesion : Form
    {
        public Form1 frm1;
        public inicio_sesion(Form1 form1)
        {
            InitializeComponent();
            frm1 = form1;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            if (File.Exists("Usuarios.txt")) {
                FileStream FSAux = new FileStream("Usuarios.txt", FileMode.Create);
                StreamWriter SW = new StreamWriter(FSAux);
                SW.WriteLine("admin;admin;1");
                SW.Close();
                FSAux.Close();
            }

            FileStream FS = new FileStream("Usuarios.txt", FileMode.OpenOrCreate);
            StreamReader SR = new StreamReader(FS);
            string linea = null;
            string[] datos;


            if (txtUsuario.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Debe llenar todos los campos", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                while (!(SR.Peek() == -1))
                {
                    linea = SR.ReadLine();
                    datos = linea.Split(';');

                    if (txtUsuario.Text == datos[0] && txtPassword.Text == datos[1])
                    {
                        frm1.abrirFormulario();
                        break;
                    }
                    linea = SR.ReadLine();
                }
                if (linea == null)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtUsuario.Clear();
                    txtUsuario.Focus();
                }
            }
            SR.Close();
            FS.Close();
        }
    }
}
