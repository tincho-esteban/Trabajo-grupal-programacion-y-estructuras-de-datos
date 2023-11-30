using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Trabajo_grupal_programacion_y_estructuras_de_datos
{
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent(); 
        }
        private void Stock_Load(object sender, EventArgs e)
        {
            ListarProductos();
        }
        string botonAct = "agregar";
        

        void ListarProductos()
        {
            dgProductos.Rows.Clear();
            FileStream FS = new FileStream("Productos.txt", FileMode.OpenOrCreate);
            StreamReader SR = new StreamReader(FS);
            string[] datos;
            string linea = null;
            while (!(SR.Peek() == -1))
            {
                linea = SR.ReadLine();
                datos = linea.Split(';');
                if (datos.Length == 0)
                {
                    break;
                }
                dgProductos.Rows.Add(datos);
            }
            SR.Close();
            FS.Close();
        }
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            botonAct = "agregar";
            txtId.Visible = false;
            txtProducto.Visible = true;
            txtProducto.BringToFront();
            txtPrecio.Visible = true;
            txtPrecio.BringToFront();
            txtUnidades.Visible = true;
            txtUnidades.BringToFront();
            lblAccion.Text = "Agregar";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            botonAct = "editar";
            txtId.Visible = true;
            txtId.BringToFront();
            txtProducto.Visible = true;
            txtProducto.BringToFront();
            txtPrecio.Visible = true;
            txtPrecio.BringToFront();
            txtUnidades.Visible = true;
            txtUnidades.BringToFront();
            lblAccion.Text = "Editar";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            botonAct = "eliminar";
            txtId.Visible = true;
            txtId.BringToFront();
            txtProducto.Visible = false;
            txtPrecio.Visible = false;
            txtUnidades.Visible = false;
            lblAccion.Text = "Eliminar";
        }

        private void agregar()
        {
            int precio = 0;
            string nombre = "";
            int id = 0;
            string linea = null;
            string linea2 = null;

            if (txtProducto.Text == "" || txtPrecio.Text == "")
            {
                MessageBox.Show("Debe llenar todos los campos", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProducto.Focus();
                return;
            }
            else
            {
                FileStream FS = new FileStream("Productos.txt", FileMode.OpenOrCreate);
                StreamReader SR = new StreamReader(FS);
                string[] datos;
                while (!(SR.Peek() == -1))
                {
                    linea = SR.ReadLine();
                    datos = linea.Split(';');
                    if (datos.Length == 0)
                    {
                        break;
                    }
                    id = Convert.ToInt32(datos[0]);
                    if (txtProducto.Text == datos[1])
                    {
                        MessageBox.Show("El producto ya existe", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtProducto.Focus();
                        SR.Close();
                        FS.Close();
                        return;
                    }

                }
                SR.Close();
                FS.Close();

                nombre = txtProducto.Text;
                precio = Convert.ToInt32(txtPrecio.Text);
                MessageBox.Show("Producto agregado correctamente", "Producto agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProducto.Text = "";
                txtPrecio.Text = "";
            }


            id++;
            linea2 = id + ";" + nombre + ";" + precio;
            FileStream FSAux = new FileStream("Productos.txt", FileMode.Append);
            StreamWriter SW = new StreamWriter(FSAux);
            SW.WriteLine(linea2);
            SW.Close();
            FSAux.Close();

            ListarProductos();
        }

        private void editar()
        {

        }

        private void eliminar()
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
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
        }

        
    }
}