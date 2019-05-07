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

namespace Ejercicio8
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Inicializa();
        }

        void Inicializa()
        {
            txbPalindromo.Text = "Escribe o selecciona una frase de la caja";
            tbxNPrimo.Text = "100";
        }

        private void btnPalindromo_Click(object sender, RoutedEventArgs e)
        {
            if (EsPalindromo(txbPalindromo.Text))
                lbPalindromo.Content = "ES PALINDROMO";
            else
                lbPalindromo.Content = "NO ES PALINDROMO";
        }
        
        private void txbPalindromo_GotFocus(object sender, RoutedEventArgs e)
        {
            txbPalindromo.Text = string.Empty;            
        }
        
        private void cbxPalindromo_LostFocus(object sender, RoutedEventArgs e)
        {
            txbPalindromo.Text = cbxPalindromo.Text;
        }
        
        bool EsPalindromo(string texto)
        {
            char[] tmp1 = null;
            string tmp2 = "";

            if (texto.Length < 2)
                return true;

            texto = SustituirTildes(texto);

            for (int i = 0; i < texto.Length; i++)
            {
                if (texto[i] == ' ')
                    texto = texto.Remove(i, 1);
                if (texto[i] == ',')
                    texto = texto.Remove(i, 1);
            }

            tmp1 = texto.ToCharArray();

            Array.Reverse(tmp1);

            tmp2 = new string(tmp1).ToLower();

            return tmp2.Equals(texto.ToLower());
        }

        private string SustituirTildes(string texto)
        {
            for (int i = 0; i < texto.Length; i++)
            {
                switch (texto[i])
                {
                    case 'á':
                        texto = texto.Replace('á', 'a');
                        break;
                    case 'é':
                        texto = texto.Replace('é', 'e');
                        break;
                    case 'í':
                        texto = texto.Replace('í', 'i');
                        break;
                    case 'ó':
                        texto = texto.Replace('ó', 'o');
                        break;
                    case 'ú':
                        texto = texto.Replace('ú', 'u');
                        break;
                    default:
                        break;
                }
            }

            return texto;
        }

        private void btnNPrimo_Click(object sender, RoutedEventArgs e)
        {
            tbxNPrimoResultado.Text = "";
            try
            {
                NumerosPrimos(int.Parse(tbxNPrimo.Text));
            }
            catch
            {
                MessageBox.Show("Error: Intente de nuevo");
            }
        }

        void NumerosPrimos(int nIntroducido)
        {
            for (int i = nIntroducido; i > 0; i--)
            {
                if (EsPrimo(i))
                    tbxNPrimoResultado.Text += i.ToString() + "  ";
            }
        }

        bool EsPrimo(int numero)
        {
            int cont = 0;

            if (numero == 1)
                return false;

            if(numero == 2 || numero == 3)
                return true;

            for (int i = 1; i < numero; i++)
			{
                if (numero % i == 0)
                    cont++;
                if (cont == 2)
                    return false;
			}

            return true;
        }
    }
}
