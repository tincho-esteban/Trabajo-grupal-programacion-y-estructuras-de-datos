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
using System.Web.UI.WebControls;
using System.Windows.Forms.DataVisualization.Charting;
using Guna.Charts.WinForms;


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
            actualizar();
        }

        public void actualizar()
        {
            calcVentas();
            calcGastos();
            calcGananacias();
        }

        private void calcVentas()
        {
            string linea = null;
            string[] datos;
            string nombre;

            FileStream FS = new FileStream("ProductosVendidos.txt", FileMode.OpenOrCreate);
            StreamReader SR = new StreamReader(FS);
            ventas = 0;

            crtVentas.YAxes.Display = false;
            crtVentas.XAxes.Display = false;
            crtVentas.Datasets.Clear();
            var dataset = new Guna.Charts.WinForms.GunaBarDataset();
            crtVentas.Legend.Display = false;

            while (!(SR.Peek() == -1))
            {
                linea = SR.ReadLine();
                datos = linea.Split(';');
                nombre = datos[0];
                ventas += Convert.ToInt32(datos[2]);

                dataset.DataPoints.Add(nombre, int.Parse(datos[2]));
            }

            crtVentas.Datasets.Add(dataset);
            crtVentas.Update();

            SR.Close();
            FS.Close();

            lblVentas.Text = "$" + ventas.ToString();

            float prom=0;
            int ultimaVenta=0,auxprom=0;
            FileStream FSv = new FileStream("ventas.txt", FileMode.OpenOrCreate);
            StreamReader SRv = new StreamReader(FSv);
            string linea2 = null;
            string[] datos2;

            crtUltimasVentas.YAxes.Display = false;
            crtUltimasVentas.Datasets.Clear();
            crtUltimasVentas.Legend.Display = false;
            var dataset2 = new Guna.Charts.WinForms.GunaSplineAreaDataset();
            dataset2.PointRadius = 3;
            dataset2.PointStyle = PointStyle.Circle;

            while (!(SRv.Peek() == -1))
            {
                linea2 = SRv.ReadLine();
                datos2 = linea2.Split(';');
                ultimaVenta = int.Parse(datos2[1]);
                auxprom++;
                prom += float.Parse(datos2[1]);
                dataset2.DataPoints.Add(datos2[0], int.Parse(datos2[1]));
            }
            lblUltVenta.Text = "$" + ultimaVenta.ToString();
            lblVentaProm.Text = "$" + Math.Round(prom / auxprom, 2).ToString();

            SRv.Close();
            FSv.Close();
            
            crtUltimasVentas.Datasets.Add(dataset2);
            crtUltimasVentas.Update();

        }

        private void calcGastos()
        {
            FileStream FS = new FileStream("productos.txt", FileMode.OpenOrCreate);
            StreamReader SR = new StreamReader(FS);
            string linea = null;
            string[] datos;
            int costoProducto=0;

            crtGastos.YAxes.Display = false;
            crtGastos.XAxes.Display = false;
            crtGastos.Datasets.Clear();
            var dataset = new Guna.Charts.WinForms.GunaBarDataset();
            crtGastos.Legend.Display = false;

            gastos = 0;

            while (!(SR.Peek() == -1))
            {
                linea = SR.ReadLine();
                datos = linea.Split(';');
                costoProducto = Convert.ToInt32(datos[2]) * Convert.ToInt32(datos[4]);
                FileStream FSpv = new FileStream("ProductosVendidos.txt", FileMode.OpenOrCreate);
                StreamReader SRpv = new StreamReader(FSpv);
                string linea2 = null;
                string[] datos2;
                while (!(SRpv.Peek() == -1))
                {
                    linea2 = SRpv.ReadLine();
                    datos2 = linea2.Split(';');
                    if (datos[1] == datos2[0])
                    {
                        costoProducto += (Convert.ToInt32(datos[2]) * Convert.ToInt32(datos2[1]));
                    } 
                }
                gastos += costoProducto;
                SRpv.Close();
                FSpv.Close();
    
                dataset.DataPoints.Add(datos[1], costoProducto);

            }

            SR.Close();
            FS.Close();
            lblGastos.Text = "$" + gastos.ToString();
            crtGastos.Datasets.Add(dataset);
            crtGastos.Update();
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
            crtGanancias.Datasets.Clear();
            var dataset = new Guna.Charts.WinForms.GunaBarDataset();
            crtGanancias.Legend.Display = false;
            dataset.DataPoints.Add("ventas", ventas);
            dataset.DataPoints.Add("gastos", gastos);
            crtGanancias.Datasets.Add(dataset);
            crtGanancias.Update();
        }

    }

}
