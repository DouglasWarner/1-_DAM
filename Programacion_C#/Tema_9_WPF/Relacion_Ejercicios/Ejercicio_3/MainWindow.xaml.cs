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

namespace Ejercicio3
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();
        int numeroGenerado;
        int numeroIntentos = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, RoutedEventArgs e)
        {
            numeroGenerado = rnd.Next(10);
            btnGenerar.IsEnabled = false;
            btnProbar.IsEnabled = true;
        }

        private void btnProbar_Click(object sender, RoutedEventArgs e)
        {
            numeroIntentos++;
            if (int.Parse(txbNumero.Text) < numeroGenerado)
                lbMensaje.Content = "NO, el número buscado es MAYOR";
            else if (int.Parse(txbNumero.Text) > numeroGenerado)
                lbMensaje.Content = "NO, el número buscado es MENOR";
            else
            {
                MessageBox.Show("Acertaste en " + numeroIntentos + " intentos");
                btnGenerar.IsEnabled = true;
                btnProbar.IsEnabled = false;
                lbMensaje.Content = "";
            }
            txbNumero.Focus();
        }

        private void txbNumero_GotFocus_1(object sender, RoutedEventArgs e)
        {
            txbNumero.Clear();
        }

        private void chbVerNumero_Checked(object sender, RoutedEventArgs e)
        {
            txbNumero.Text = numeroGenerado.ToString();
        }

        private void chbVerNumero_Unchecked(object sender, RoutedEventArgs e)
        {
            txbNumero.Text = string.Empty;
        }
    }
}
