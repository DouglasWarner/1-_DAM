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

namespace Ejercicio_01
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int numeroInsertado = 0;

        public MainWindow()
        {
            InitializeComponent();
            // Para hacer foco a un objeto cuando abra la ventana se puede usar:

            //txbNumero.Focus();
            // o
            // Loaded += (sender, e) => MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
        }

        public long SumaNumeros(int numero)
        {
            long resultadoSuma = 0;

            for (int i = 0; i <= numero; i++)
            {
                resultadoSuma += i;
            }

            return resultadoSuma;
        }

        public bool TeclaPermitida(Key tecla)
        {
            Key[] permitidas = {Key.D0, Key.D1, Key.D2, Key.D3, Key.D4, Key.D5, Key.D6, Key.D7, Key.D8, Key.D9,
                                Key.NumPad0, Key.NumPad1, Key.NumPad2, Key.NumPad3, Key.NumPad4, Key.NumPad5, Key.NumPad6, Key.NumPad7,
                                Key.NumPad8, Key.NumPad9};

            return permitidas.Contains(tecla);
        }

        // Calcula y muestra el resultado
        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                numeroInsertado = int.Parse(txbNumero.Text);

                Resultado.Text = SumaNumeros(numeroInsertado).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Introduce algo crack");
                return;
            }            
        }

        // Cierra aplicación
        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Solo acepta numeros
        private void txbNumero_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !TeclaPermitida(e.Key);
        }
    }
}
