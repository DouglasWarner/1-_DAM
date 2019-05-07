using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ejercicio7
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txbPrimeraMatriz.Focus();
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            txbResultado.Text = string.Empty;
            MultiplicacionMatriz();
        }

        void MultiplicacionMatriz()
        {
            string matriz1 = txbPrimeraMatriz.Text;
            string matriz2 = txbSegundaMatriz.Text;
            string[,] resultado = new string[matriz1.Length, matriz2.Length];

            for (int i = 0; i < matriz1.Length; i++)
            {
                for (int j = 0; j < matriz2.Length; j++)
                {
                    try
                    {
                        resultado[i, j] += int.Parse(matriz1[i].ToString()) * int.Parse(matriz2[j].ToString());
                        txbResultado.Text += resultado[i, j] + "".PadLeft(10);
                    }
                    catch
                    {
                        MessageBox.Show("ERROR: No se ha podido realizar la operación");
                        return;
                    }
                }
                txbResultado.Text += "\n\n";
            }
        }
    }
}
