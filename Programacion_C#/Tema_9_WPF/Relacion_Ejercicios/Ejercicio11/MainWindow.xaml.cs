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
        double[] _tamano = new double[] {10, 12, 16, 20, 24, 28 };
        FontFamily[] _fuente = new FontFamily[] { new FontFamily("Stencil"), new FontFamily("Segoe script"), new FontFamily("SinSum") };
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
                lbxColor.Items.Add(_color[i]);
            }
            for (int i = 0; i < _tamano.Length; i++)
            {
                lbxTamaño.Items.Add(_tamano[i]);
            }
            for (int i = 0; i < _bgcolor.Length; i++)
            {
                lbxBgColor.Items.Add(_bgcolor[i]);
            }
            lbxFuente.SelectedIndex = 1;
            lbxColor.SelectedIndex = 1;
            lbxTamaño.SelectedIndex = 1;
            lbxBgColor.SelectedIndex = 1;
        }

        private void tbkTexto1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            tbkTexto1.FontSize = (double)lbxTamaño.SelectedItem;
            tbkTexto1.FontFamily = (FontFamily)lbxFuente.SelectedItem;
            tbkTexto1.Foreground = (Brush)lbxColor.SelectedItem;
            tbkTexto1.Background = (Brush)lbxBgColor.SelectedItem;
        }
    }
}
