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

namespace Prestamos_Bancos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Prestamo cliente = new Prestamo();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalcularCuota_Click(object sender, RoutedEventArgs e)
        {
            double tmpCantidad = 0;
            int tmpMeses = 0;
            try
            {
                if (double.TryParse(tbxCantidad.Text, out tmpCantidad))
                    cliente.Cantidad = tmpCantidad;
                else
                {
                    MessageBox.Show("Error: Algo con la cantidad");
                    return;
                }
                if (int.TryParse(tbxMeses.Text, out tmpMeses))
                    cliente.Meses = int.Parse(tbxMeses.Text);
                else
                {
                    MessageBox.Show("Error: Algo con los meses");
                    return;
                }

                if (cbxRiesgo.IsChecked == true)
                    cliente.EsRiesgo = true;
                else
                    cliente.EsRiesgo = false;

                tbkCuotaMensual.Text = Math.Round(cliente.CalcularCantidadMensual(),4).ToString() + " €";
            }
            catch
            {
                MessageBox.Show("Error: algo ocurrio con la conversion");
            }
        }

        private void tbxMeses_TextInput(object sender, TextCompositionEventArgs e)
        {
            string[] meses = {"1","2","3","4" };   

            if(meses.Contains(e.Text))
                e.Handled = true;
        }
    }
}
