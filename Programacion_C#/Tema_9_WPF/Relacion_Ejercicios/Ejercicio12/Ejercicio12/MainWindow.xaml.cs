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

namespace Ejercicio12
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
            Pintar();
        }

        private void sldRojo_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Pintar();
        }

        void Pintar()
        {
            Color colorRectangle = Color.FromRgb((byte)sldRojo.Value, (byte)sldVerde.Value, (byte)sldAzul.Value);

            stpColor.Fill = new SolidColorBrush(colorRectangle);
        }

        private void sldVerde_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Pintar();
        }

        private void sldAzul_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Pintar();
        }
    }
}
