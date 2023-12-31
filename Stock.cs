﻿using System;
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
        

        public void ListarProductos()
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
            txtId.Text = "";
            txtProducto.Text = "";
            txtCosto.Text = "";
            txtPrecio.Text = "";
            txtUnidades.Text = "";
            botonAct = "agregar";
            txtId.Visible = false;
            txtProducto.Visible = true;
            txtProducto.BringToFront();
            txtCosto.Visible = true;
            txtCosto.BringToFront();
            txtPrecio.Visible = true;
            txtPrecio.BringToFront();
            txtUnidades.Visible = true;
            txtUnidades.BringToFront();
            lblAccion.Text = "Agregar producto";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtProducto.Text = "";
            txtCosto.Text = "";
            txtPrecio.Text = "";
            txtUnidades.Text = "";
            botonAct = "editar";
            txtId.Visible = true;
            txtId.BringToFront();
            txtProducto.Visible = true;
            txtProducto.BringToFront();
            txtCosto.Visible = true;
            txtCosto.BringToFront();
            txtPrecio.Visible = true;
            txtPrecio.BringToFront();
            txtUnidades.Visible = true;
            txtUnidades.BringToFront();
            lblAccion.Text = "Editar producto";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtProducto.Text = "";
            txtCosto.Text = "";
            txtPrecio.Text = "";
            txtUnidades.Text = "";
            botonAct = "eliminar";
            txtId.Visible = true;
            txtId.BringToFront();
            txtProducto.Visible = false;
            txtCosto.Visible = false;
            txtPrecio.Visible = false;
            txtUnidades.Visible = false;
            lblAccion.Text = "Eliminar producto";
        }

        private void agregar()
        {
            int precio = 0;
            string nombre = "";
            int costo = 0;
            int id = 0;
            string linea = null;
            string linea2 = null;
            int unidades = 0;

            if (txtProducto.Text == "" || txtCosto.Text == "" || txtPrecio.Text == "" || txtUnidades.Text == "")
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
                costo = Convert.ToInt32(txtCosto.Text);
                unidades = Convert.ToInt32(txtUnidades.Text);
                precio = Convert.ToInt32(txtPrecio.Text);
                MessageBox.Show("Producto agregado correctamente", "Producto agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProducto.Text = "";
                txtCosto.Text = "";
                txtPrecio.Text = "";
                txtUnidades.Text = "";
            }


            id++;
            linea2 = id + ";" + nombre + ";" + costo + ";" + precio + ";" + unidades;
            FileStream FSAux = new FileStream("Productos.txt", FileMode.Append);
            StreamWriter SW = new StreamWriter(FSAux);
            FileStream FS2 = new FileStream("ProductosVendidos.txt", FileMode.Append);
            StreamWriter SW2 = new StreamWriter(FS2);
            SW.WriteLine(linea2);
            SW2.WriteLine(nombre + ";0;0");
            SW2.Close();
            FS2.Close();
            SW.Close();
            FSAux.Close();

            ListarProductos();
        }

        

        private void editar()
        {

            //editar txt
            int precio = 0;
            string nombre = "";
            int costo = 0;
            int id = 0;
            int unidades = 0;
            string linea = null;
            string linea2 = null;

            if (txtId.Text == "")
            {
                MessageBox.Show("Debe seleccionar un producto", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProducto.Focus();
                return;
            }
            if (txtProducto.Text == "" || txtPrecio.Text == "" || txtUnidades.Text == "")
            {
                MessageBox.Show("Debe llenar todos los campos", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProducto.Focus();
                return;
            }

            FileStream FS = new FileStream("Productos.txt", FileMode.OpenOrCreate);
            FileStream FSAux = new FileStream("ProductosAux.txt", FileMode.OpenOrCreate);
            StreamWriter SW = new StreamWriter(FSAux);
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
                unidades = Convert.ToInt32(datos[4]);
                if (txtId.Text == datos[0])
                {
                    nombre = txtProducto.Text;
                    unidades = Convert.ToInt32(txtUnidades.Text);
                    costo = Convert.ToInt32(txtCosto.Text);
                    precio = Convert.ToInt32(txtPrecio.Text);
                    id = Convert.ToInt32(txtId.Text);
                    linea2 = id + ";" + nombre + ";" + costo + ";" + precio + ";" + unidades;
                    MessageBox.Show("Producto editado correctamente", "Producto editado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtProducto.Text = "";
                    txtCosto.Text = "";
                    txtPrecio.Text = "";
                    txtUnidades.Text = "";
                    txtId.Text = "";
                    SW.WriteLine(linea2);
                }
                else
                {
                    SW.WriteLine(linea);
                }
            }
            SW.Close();
            SR.Close();
            FS.Close();
            FSAux.Close();
            File.Delete("Productos.txt");
            File.Move("ProductosAux.txt", "Productos.txt");
            ListarProductos();

        }

        private void eliminar()
        {
            if(txtId.Text == "")
            {
                MessageBox.Show("Debe seleccionar un producto", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProducto.Focus();
                return;
            }
            if (MessageBox.Show("¿Desea eliminar el producto?", "Eliminar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            FileStream FS = new FileStream("Productos.txt", FileMode.OpenOrCreate);
            FileStream FSAux = new FileStream("ProductosAux.txt", FileMode.OpenOrCreate);
            StreamWriter SW = new StreamWriter(FSAux);
            StreamReader SR = new StreamReader(FS);

            string linea;
            string[] datos;
            while (!(SR.Peek() == -1))
            {
                linea = SR.ReadLine();
                datos = linea.Split(';');

                if (txtId.Text != datos[0])
                {
                    if (int.Parse(datos[0]) > int.Parse(txtId.Text))
                    {
                        linea = (int.Parse(datos[0]) - 1) + ";" + datos[1] + ";" + datos[2] + ";" + datos[3] + ";" + datos[4];
                        SW.WriteLine(linea);
                    }
                    else
                    {
                        SW.WriteLine(linea);
                    }
                }
            }
            MessageBox.Show("Producto eliminado correctamente", "Producto eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SW.Close();
            SR.Close();
            FS.Close();
            FSAux.Close();
            File.Delete("Productos.txt");
            File.Move("ProductosAux.txt", "Productos.txt");
           
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPrecio.Text, out int precio) || !int.TryParse(txtUnidades.Text, out int unidades) || precio <= 0 || unidades <= 0)
            {
                MessageBox.Show("Ingrese valores válidos y mayores a cero en los campos de precio y unidades", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecio.Focus();
                return;
            }

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
            ListarProductos();
        }

        private void dgProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (botonAct == "editar" || botonAct == "eliminar")
            {
                txtId.Text = dgProductos.CurrentRow.Cells[0].Value.ToString();
                txtProducto.Text = dgProductos.CurrentRow.Cells[1].Value.ToString();
                txtCosto.Text = dgProductos.CurrentRow.Cells[2].Value.ToString();
                txtPrecio.Text = dgProductos.CurrentRow.Cells[3].Value.ToString();
                txtUnidades.Text = dgProductos.CurrentRow.Cells[4].Value.ToString();
            }

        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            // buscar en data grid
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
                
                    if (datos[1].ToLower().Contains(txtBuscarProducto.Text.ToLower()))
                    {
                        dgProductos.Rows.Add(datos);
                    }
                }
            SR.Close();
            FS.Close();
        }
    }
}