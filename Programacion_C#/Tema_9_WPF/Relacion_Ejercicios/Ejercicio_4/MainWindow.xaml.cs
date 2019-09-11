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

namespace Ejercicio4
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSumar_Click(object sender, RoutedEventArgs e)
        {
            if (tbxN1.Text == string.Empty)
                return;
            else if (tbxN2.Text == string.Empty)
                return;
            else
                try
                {
                    lblResultado.Content = "El resultado de " + tbxN1.Text + " hasta " + tbxN2.Text + " es: " + sumaNumeros(int.Parse(tbxN1.Text), int.Parse(tbxN2.Text)).ToString();
                }
                catch (FormatException)
                {
                    lblResultado.Content = "ERROR: deben ser números";
                }
        }

        int sumaNumeros(int numero1, int numero2)
        {
            int resultado = numero1;

            for (int i = numero1+1; i <= numero2; i++)
            {
                resultado += i;
            }
            return resultado;
        }

        private void tbxN1_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxN1.Text = string.Empty;
        }

        private void tbxN2_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxN2.Text = string.Empty;
        }
    }
}
