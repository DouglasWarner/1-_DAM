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

namespace Ejercicio11
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] _tamano = new int[] {10, 12, 16, 20, 24, 28 };
        FontFamily[] _fuente = new FontFamily[] { new FontFamily("Stencil"), new FontFamily("Comic MS Sans"), new FontFamily("SinSum") };
        SolidColorBrush[] _color = new SolidColorBrush[] { Brushes.MediumPurple, Brushes.Red, Brushes.Green };
        SolidColorBrush[] _bgcolor = new SolidColorBrush[] { Brushes.Gray, Brushes.Black, Brushes.White };
        Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
            Inicializar();
        }

        void Inicializar()
        {
            for (int i = 0; i < _fuente.Length; i++)
            {
                lbxFuente.Items.Add(_fuente[i]);
            }
            for (int i = 0; i < _color.Length; i++)
            {
                lbxColor.Items.Add(_color[i].ToString());
            }
            for (int i = 0; i < _tamano.Length; i++)
            {
                lbxTamaño.Items.Add(_tamano[i]);
            }
        }

        private void tbkTexto1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            tbkTexto1.FontSize = _tamano[rnd.Next(_tamano.Length)];
            tbkTexto1.FontFamily = _fuente[rnd.Next(_fuente.Length)];
            tbkTexto1.Foreground = _color[rnd.Next(_color.Length)];
            tbkTexto1.Background = _bgcolor[rnd.Next(_bgcolor.Length)];
        }
    }
}
