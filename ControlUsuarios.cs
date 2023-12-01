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
    public partial class ControlUsuarios : Form
    {
        public ControlUsuarios()
        {
            InitializeComponent();
        }
        private void ControlUsuarios_Load(object sender, EventArgs e)
        {
            listar();
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
                btnEnviar.PerformClick();

                e.Handled = true;
            }
        }

        public void listar()
        {
            dgUsuarios.Rows.Clear();
            FileStream FS = new FileStream("Usuarios.txt", FileMode.OpenOrCreate);
            StreamReader SR = new StreamReader(FS);
            string linea;
            string[] datos;
            while (!(SR.Peek() == -1))
            {
                linea = SR.ReadLine();
                datos = linea.Split(';');
                dgUsuarios.Rows.Add(datos[0], datos[2]);
            }
            SR.Close();
            FS.Close();
        }
        
        string botonAct = "agregar";
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "";
            txtContrasena.Text = "";
            txtRepetirContrasena.Text = "";
            chbAdmin.Checked = false;
            botonAct = "agregar";
            txtUsuario.Enabled = true;
            pnlContrasena.Visible = true;
            pnlContrasena.BringToFront();
            pnlAdmin.Visible = true;
            pnlAdmin.BringToFront();
            lblAccion.Text = "Agregar usuario";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "";
            txtContrasena.Text = "";
            txtRepetirContrasena.Text = "";
            chbAdmin.Checked = false;
            botonAct = "editar";
            txtUsuario.Enabled = false;
            pnlContrasena.Visible = true;
            pnlContrasena.BringToFront();
            pnlAdmin.Visible = true;
            pnlAdmin.BringToFront();
            lblAccion.Text = "Editar usuario";
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "";
            txtContrasena.Text = "";
            txtRepetirContrasena.Text = "";
            chbAdmin.Checked = false;
            botonAct = "eliminar";
            txtUsuario.Enabled = false;
            pnlContrasena.Visible = false;
            pnlAdmin.Visible = false;
            lblAccion.Text = "Eliminar usuario";
        }

        private void agregar()
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
                MessageBox.Show("Usuario agregado correctamente", "Usuario agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SW.WriteLine(linea);
                SW.Close();
                FS.Close();
            }
        }

        private void editar()
        {
            if (txtUsuario.Text == "")
            {
                MessageBox.Show("Debe seleccionar un usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContrasena.Focus();
                return;
            }
            if (txtUsuario.Text == "admin")
            {
                MessageBox.Show("No se puede modificar el usuario admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtContrasena.Text == "" || txtRepetirContrasena.Text == "")
            {
                MessageBox.Show("Debe llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContrasena.Focus();
                return;
            }

            FileStream FS = new FileStream("Usuarios.txt", FileMode.OpenOrCreate);
            FileStream FSAux = new FileStream("UsuariosAux.txt", FileMode.OpenOrCreate);
            StreamReader SR = new StreamReader(FS);
            StreamWriter SW = new StreamWriter(FSAux);

            string linea;
            string[] datos;
            string usuario;
            string contrasena;
            string permisos;

            while (!(SR.Peek() == -1))
            {
                linea = SR.ReadLine();
                datos = linea.Split(';');
                usuario = datos[0];
                contrasena = datos[1];
                permisos = datos[2];
                if (txtUsuario.Text == usuario)
                {
                    if (txtContrasena.Text != txtRepetirContrasena.Text)
                    {
                        MessageBox.Show("La contraseña debe ser igual en ambos campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtContrasena.Focus();
                        return;
                    }
                    else
                    {
                        contrasena = txtContrasena.Text;
                    }
                    if (chbAdmin.Checked)
                    {
                        permisos = "admin";
                    }
                    else
                    {
                        permisos = "user";
                    }
                }
                linea = usuario + ";" + contrasena + ";" + permisos;
                SW.WriteLine(linea);
            }
            MessageBox.Show("Usuario modificado correctamente", "Usuario modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SR.Close();
            SW.Close();
            FS.Close();
            FSAux.Close();
            File.Delete("Usuarios.txt");
            File.Move("UsuariosAux.txt", "Usuarios.txt");
        }

        private void eliminar()
        {
            if (txtUsuario.Text == "")
            {
                MessageBox.Show("Debe seleccionar un usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContrasena.Focus();
                return;
            }
            if (txtUsuario.Text == "admin")
            {
                MessageBox.Show("No se puede eliminar el usuario admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Seguro quiere borrar el usuario?", "borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            FileStream FS = new FileStream("Usuarios.txt", FileMode.OpenOrCreate);
            FileStream FSAux = new FileStream("UsuariosAux.txt", FileMode.OpenOrCreate);
            StreamReader SR = new StreamReader(FS);
            StreamWriter SW = new StreamWriter(FSAux);

            string linea;
            string[] datos;
            string usuario;

            while (!(SR.Peek() == -1))
            {
                linea = SR.ReadLine();
                datos = linea.Split(';');
                usuario = datos[0];
                if (txtUsuario.Text != usuario)
                {
                    SW.WriteLine(linea);
                }
            }

            MessageBox.Show("Usuario eliminado correctamente", "Usuario eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            SR.Close();
            SW.Close();
            FS.Close();
            FSAux.Close();

            File.Delete("Usuarios.txt");
            File.Move("UsuariosAux.txt", "Usuarios.txt");

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (botonAct == "agregar")
            {
                agregar();

            }
            else if (botonAct == "editar")
            {
                editar();
            }
            else
            {
                eliminar();
            }
            listar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dgUsuarios.Rows.Clear();
            FileStream FS = new FileStream("Usuarios.txt", FileMode.OpenOrCreate);
            StreamReader SR = new StreamReader(FS);
            string linea;
            string[] datos;
            while (!(SR.Peek() == -1))
            {
                linea = SR.ReadLine();
                datos = linea.Split(';');
                if (datos[0].ToLower().Contains(txtBuscar.Text.ToLower()))
                {
                    dgUsuarios.Rows.Add(datos[0], datos[2]);
                }
            }
            SR.Close();
            FS.Close();
        }

        private void dgUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (botonAct == "editar" || botonAct == "eliminar")
            {
                txtUsuario.Text = dgUsuarios.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }
    }
}
    