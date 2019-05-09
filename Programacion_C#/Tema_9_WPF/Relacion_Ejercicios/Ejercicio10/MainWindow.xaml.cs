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
using System.Text.RegularExpressions;

namespace Ejercicio10
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int num1 = 0;
        int num2 = 1;

        public MainWindow()
        {
            InitializeComponent();
            tbxNumero.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tbxNumero.Text += ((Button)sender).Content.ToString();
        }

        private void btnSuma_Click(object sender, RoutedEventArgs e)
        {
            num1 = int.Parse(tbxNumero.Text);
            tbxNumero.Text = "";
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            num1 = int.Parse(tbxNumero.Text) + num1;
            tbxNumero.Text = num1.ToString();
        }

        private void btnResta_Click(object sender, RoutedEventArgs e)
        {
            num1 = int.Parse(tbxNumero.Text) - num1;
            tbxNumero.Text = num1.ToString();
        }

        private void btnMultiplicacion_Click(object sender, RoutedEventArgs e)
        {
            num1 = int.Parse(tbxNumero.Text) * num1;
            tbxNumero.Text = num1.ToString();
        }

        private void btnDividir_Click(object sender, RoutedEventArgs e)
        {
            num1 = int.Parse(tbxNumero.Text) / num2;
            tbxNumero.Text = num1.ToString();
        }

        private void btnLimpiarTxb_Click(object sender, RoutedEventArgs e)
        {
            tbxNumero.Text = "";
        }

        private void btnLimpiarNumero_Click(object sender, RoutedEventArgs e)
        {
            tbxNumero.Text = "";
        }
        

    }
}
