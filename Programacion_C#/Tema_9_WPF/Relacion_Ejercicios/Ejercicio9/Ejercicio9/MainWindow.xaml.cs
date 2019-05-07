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

namespace Ejercicio9
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int totaltiradas = 0;
        private List<int> dados = new List<int>();
        private Random rnd = new Random();
        private int[] resultado = new int[7];
        private int aleatorio;
        private BitmapImage[] _imagenes = new BitmapImage[7];

        public MainWindow()
        {
            InitializeComponent();
            Inicizaliza();
        }

        void Inicizaliza()
        {
            string _ruta = string.Empty;
            Uri _url = null;

            for (int i = 1; i < _imagenes.Length; i++)
            {
                _ruta = @".\Dados\Dado_" + (i).ToString() + ".png";
                _url = new Uri(_ruta, UriKind.Relative);
                _imagenes[i] = new BitmapImage(_url);
            }
        }
        void TirarDado(int nTiradas)
        {
            totaltiradas += nTiradas;

            dados.Clear();

            for (int i = 0; i < nTiradas; i++)
            {
                aleatorio = rnd.Next(1, 7);
                dados.Add(aleatorio);

                resultado[aleatorio]++;
            }

            MostrarResultado();
        }

        void MostrarResultado()
        {
            txbResultado.Text = "";

            for (int i = 1; i < resultado.Length; i++)
            {
                if (chbxSimular.IsChecked.Value)
                    imgDado.Source = _imagenes[aleatorio];
                txbResultado.Text += i + " -> " + ContarDados()[i] + "\n";
            }
        }

        void MostrarEstadisticas()
        {
            for (int i = 1; i < 7; i++)
            {
                txbEstadistica.Text += i + " -> " + resultado[i] + " -> " + PorcentajeDados(i).ToString("00.00") +"%" + "\n";
            }
        }

        string[] ContarDados()
        {
            string[] resultado = new string[7];

            for (int i = 0; i < 7; i++)
            {
                resultado[i] = dados.Count(n => n == i).ToString();
            }

            return resultado;
        }

        int PorcentajeDados(int posicion)
        {
            return (resultado[posicion] * 100) / totaltiradas;
        }
        
        private void btnTirar_Click(object sender, RoutedEventArgs e)
        {
            txbEstadistica.Text = "";
            TirarDado(1);
            tbxTotalTiradas.Text = totaltiradas.ToString();
            MostrarEstadisticas();
        }

        private void btnAutomatico_Click(object sender, RoutedEventArgs e)
        {
            int aux;

            txbEstadistica.Text = "";
            if (!int.TryParse(tbxNumeroTirar.Text, out aux))
            {
                MessageBox.Show("Algo ocurrio con el parametro pasado", "ERROR", MessageBoxButton.OK);
                tbxNumeroTirar.Focus();
                return;
            }
            TirarDado(aux);
            tbxTotalTiradas.Text = totaltiradas.ToString();
            MostrarEstadisticas();
        }

        private void chbxSimular_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
