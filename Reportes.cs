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
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();
        }

        int ganancia = 0, ventas = 0, gastos = 0;

        private void Reportes_Load(object sender, EventArgs e)
        {
            calcVentas();
            calcGastos();
            calcGananacias();
        }

        private void calcVentas()
        {
            FileStream FS = new FileStream("ProductosVendidos.txt", FileMode.OpenOrCreate);
            StreamReader SR = new StreamReader(FS);
            string linea = null;
            string[] datos;
            while (!(SR.Peek() == -1))
            {
                linea = SR.ReadLine();
                datos = linea.Split(';');
                ventas += Convert.ToInt32(datos[4]);
            }
            SR.Close();
            FS.Close();
            lblVentas.Text = "$" + ventas.ToString();
        }

        private void calcGastos()
        {
            FileStream FS = new FileStream("productos.txt", FileMode.OpenOrCreate);
            StreamReader SR = new StreamReader(FS);
            string linea = null;
            string[] datos;
            while (!(SR.Peek() == -1))
            {
                linea = SR.ReadLine();
                datos = linea.Split(';');
                int costoProducto = Convert.ToInt32(datos[2]) * Convert.ToInt32(datos[4]);
                gastos +=costoProducto;
                FileStream FSpv = new FileStream("ProductosVendidos.txt", FileMode.OpenOrCreate);
                StreamReader SRpv = new StreamReader(FSpv);
                string linea2 = null;
                string[] datos2;
                while (!(SRpv.Peek() == -1))
                {
                    linea2 = SRpv.ReadLine();
                    datos2 = linea2.Split(';');
                    if (datos[1] == datos2[1])
                    {
                        int costoProducto2 = Convert.ToInt32(datos[2]) * Convert.ToInt32(datos2[2]);
                        gastos += costoProducto2;
                    }
                }
                SRpv.Close();
                FSpv.Close();
            }
            SR.Close();
            FS.Close();
            lblGastos.Text = "$" + gastos.ToString();
        }

        private void calcGananacias()
        {
            ganancia = ventas - gastos;
            if (ganancia < 0)
            {
                ganancia *= -1;
                lblGanancia.ForeColor = Color.Red;
                lblGanancia.Text = "-$" + ganancia.ToString();
            }
            else
            {
                lblGanancia.ForeColor = Color.Green;
                lblGanancia.Text = "$" + ganancia.ToString();
            }
            crtGanancias.YAxes.Display = false;
            var dataset = new Guna.Charts.WinForms.GunaBarDataset();
            dataset.Label = "Ganancias";
            dataset.DataPoints.Add("ventas", ventas);
            dataset.DataPoints.Add("gastos", gastos);
            crtGanancias.Datasets.Add(dataset);
            crtGanancias.Update();
        }

    }

}
