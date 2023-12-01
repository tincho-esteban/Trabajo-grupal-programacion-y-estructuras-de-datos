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
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
        }

        void ListarCarrito()
        {
            dgCarrito.Rows.Clear();
            FileStream FS = new FileStream("Carrito.txt", FileMode.OpenOrCreate);
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
                dgCarrito.Rows.Add(datos);
            }
            SR.Close();
            FS.Close();
            calcularTotal();
        }

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

        private void Ventas_Load(object sender, EventArgs e)
        {
            ListarProductos();
            ListarCarrito();
            calcularTotal();
        }

        private void btnCarrito_Click(object sender, EventArgs e)
        {
            string producto = "";
            int cantidad = 0;
            int precio = 0;
            int total = 0;
            int ID = 0;

            if (txtUnidades.Text == "")
            {
                MessageBox.Show("Debe llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUnidades.Focus();
                return;
            }

            if (txtProducto.Text == "" || txtId.Text == "")
            {
                MessageBox.Show("Debe Seleccionar un producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUnidades.Focus();
                return;
            }

            if(Convert.ToInt32(txtUnidades.Text) <= 0)
            {
                MessageBox.Show("Debe ingresar una cantidad mayor a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUnidades.Focus();
                return;
            }

            cantidad = Convert.ToInt32(txtUnidades.Text);
            precio = Convert.ToInt32(txtPrecio.Text);
            total = cantidad * precio;
            producto = txtProducto.Text;
            ID = Convert.ToInt32(txtId.Text);

            //eliminar unidades de producto
            FileStream FS = new FileStream("Productos.txt", FileMode.OpenOrCreate);
            FileStream FSAUX = new FileStream("ProductosAux.txt", FileMode.OpenOrCreate);
            StreamWriter SW = new StreamWriter(FSAUX);
            StreamReader SR = new StreamReader(FS);

            while (!(SR.Peek() == -1))
            {
                string linea = SR.ReadLine();
                string[] datos = linea.Split(';');
                if (datos.Length == 0)
                {
                    break;
                }


                if (ID != Convert.ToInt32(datos[0]))
                {
                    SW.WriteLine(datos[0] + ";" + datos[1] + ";" + datos[2] + ";" + datos[3] + ";" + datos[4]);
                }
                else
                {
                    if (cantidad > Convert.ToInt32(datos[3]))
                    {
                        MessageBox.Show("No hay suficientes unidades de " + datos[1] + " " + datos[4], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SR.Close();
                        SW.Close();
                        FS.Close();
                        FSAUX.Close();
                        return;
                    }

                    SW.WriteLine(datos[0] + ";" + datos[1] + ";" + datos[2] + ";" + datos[3] + ";" + (Convert.ToInt32(datos[4]) - cantidad));
                }
            }
            SR.Close();
            SW.Close();
            FS.Close();
            FSAUX.Close();
            File.Delete("Productos.txt");
            File.Move("ProductosAux.txt", "Productos.txt");

            FileStream FSCR = new FileStream("Carrito.txt", FileMode.Append);
            StreamWriter SWCR = new StreamWriter(FSCR);
            SWCR.WriteLine(ID + ";" + producto + ";" + cantidad + ";" + precio + ";" + total);
            SWCR.Close();
            FSCR.Close();

            ListarCarrito();
            ListarProductos();
            txtUnidades.Text = "";

        }

        private void txtUnidades_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgProductos.CurrentRow.Cells[0].Value.ToString();
            txtProducto.Text = dgProductos.CurrentRow.Cells[1].Value.ToString();
            txtPrecio.Text = dgProductos.CurrentRow.Cells[2].Value.ToString();
            txtUnidades.Text = "";

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgCarrito_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtEliminarCarrito.Text = dgCarrito.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnEliminarCarrito_Click(object sender, EventArgs e)
        {

            int id = 0;

            if (txtEliminarCarrito.Text == "")
            {
                MessageBox.Show("Seleccione un producto a eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            id = Convert.ToInt32(txtEliminarCarrito.Text);
            if (id == 0)
            {
                MessageBox.Show("Seleccione un producto a eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FileStream FS = new FileStream("Carrito.txt", FileMode.OpenOrCreate);
            FileStream FSAUX = new FileStream("CarritoAux.txt", FileMode.OpenOrCreate);
            StreamWriter SW = new StreamWriter(FSAUX);
            StreamReader SR = new StreamReader(FS);

            string linea = null;
            string[] datos;
            int unitsRecuperar = 0;
            while (!(SR.Peek() == -1))
            {
                linea = SR.ReadLine();
                datos = linea.Split(';');
                if (datos.Length == 0)
                {
                    break;
                }
                if (id != Convert.ToInt32(datos[0]))
                {
                    SW.WriteLine(datos[0] + ";" + datos[1] + ";" + datos[2] + ";" + datos[3] + ";" + datos[4]);
                }
                else
                {
                    unitsRecuperar =+ Convert.ToInt32(datos[2]);
                    MessageBox.Show("Se han eliminado " + unitsRecuperar + " unidades de " + datos[1], "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            SR.Close();
            SW.Close();
            FS.Close();
            FSAUX.Close();
            File.Delete("Carrito.txt");
            File.Move("CarritoAux.txt", "Carrito.txt");
            ListarCarrito();

            //sumar unidades al producto
            FileStream FS2 = new FileStream("Productos.txt", FileMode.OpenOrCreate);
            FileStream FSAUX2 = new FileStream("ProductosAux.txt", FileMode.OpenOrCreate);
            StreamWriter SW2 = new StreamWriter(FSAUX2);
            StreamReader SR2 = new StreamReader(FS2);

            string linea2 = null;
            string[] datos2;
            while (!(SR2.Peek() == -1))
            {
                linea2 = SR2.ReadLine();
                datos2 = linea2.Split(';');
                if (datos2.Length == 0)
                {
                    break;
                }
                if (id == Convert.ToInt32(datos2[0]))
                {
                    SW2.WriteLine(datos2[0] + ";" + datos2[1] + ";" + datos2[2] + ";" + datos2[3] + ";" + (Convert.ToInt32(datos2[4]) + unitsRecuperar));
                }
                else
                {
                    SW2.WriteLine(datos2[0] + ";" + datos2[1] + ";" + datos2[2] + ";" + datos2[3] + ";" + datos2[4]);
                }
            }
            SR2.Close();
            SW2.Close();
            FS2.Close();
            FSAUX2.Close();
            File.Delete("Productos.txt");
            File.Move("ProductosAux.txt", "Productos.txt");
            ListarProductos();

        }

        void calcularTotal()
        {
            int total = 0;
            for (int i = 0; i < dgCarrito.Rows.Count; i++)
            {
                total += Convert.ToInt32(dgCarrito.Rows[i].Cells[4].Value);
            }
            txtPrecioTotal.Text = total.ToString();
            
        }
        private void dgCarrito_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            calcularTotal();
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
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


                if (datos[1].ToLower().Contains(txtBuscarProducto.Text.ToLower()))
                {
                    dgProductos.Rows.Add(datos);
                }
            }
            SR.Close();
            FS.Close();
        }

        void limpiarCarrito()
        {
            FileStream FS = new FileStream("Carrito.txt", FileMode.Create);
            FS.Close();
            ListarCarrito();
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            //venta
            FileStream FS = new FileStream("Ventas.txt", FileMode.Append);
            StreamWriter SW = new StreamWriter(FS);
            for (int i = 0; i < dgCarrito.Rows.Count; i++)
            {
                SW.WriteLine(dgCarrito.Rows[i].Cells[0].Value + ";" + dgCarrito.Rows[i].Cells[1].Value + ";" + dgCarrito.Rows[i].Cells[2].Value + ";" + dgCarrito.Rows[i].Cells[3].Value + ";" + dgCarrito.Rows[i].Cells[4].Value);
            }
            SW.Close();
            FS.Close();

            ListarCarrito();
            limpiarCarrito();

            MessageBox.Show("Venta realizada con exito", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
