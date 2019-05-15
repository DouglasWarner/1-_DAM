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
//--------------------------
using System.Windows.Threading;

namespace Ejercicio17
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double posBarra = 5;
        double posTopPelota = 5;
        double posLeftPelota = 5;
        int pausa = 10030;
        bool limiteBarra = false;
        bool limitePelotaTop = false;
        bool limitePelotaLeft = false;
        DispatcherTimer tiempo = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            Inicializar();
        }

        void Inicializar()
        {
            tiempo.Interval = new TimeSpan(pausa);
            tiempo.Tick += tiempo_Tick;
        }

        void tiempo_Tick(object sender, EventArgs e)
        {
            StartBarra();
            StartPelota();
        }

        bool MensajeStart()
        {
            MessageBoxResult resultado = MessageBox.Show("Quieres empezar una partida nueva?", "Menu", MessageBoxButton.YesNo, MessageBoxImage.Information);

            return resultado == MessageBoxResult.Yes;
        }

        void StartBarra()
        {
            if (limiteBarra)
                Canvas.SetLeft(rtgBarra, Canvas.GetLeft(rtgBarra) - posBarra);

            if (!limiteBarra)
                Canvas.SetLeft(rtgBarra, Canvas.GetLeft(rtgBarra) + posBarra);

            if (Canvas.GetLeft(rtgBarra) == cvsPrincipal.MaxWidth-rtgBarra.Width)
                limiteBarra = true;
            if (Canvas.GetLeft(rtgBarra) == cvsPrincipal.MinWidth)
                limiteBarra = false;
        }

        void StartPelota()
        {
            if (limitePelotaLeft)
                Canvas.SetLeft(rtgPelota, Canvas.GetLeft(rtgPelota) - posLeftPelota);
            else
                Canvas.SetLeft(rtgPelota, Canvas.GetLeft(rtgPelota) + posLeftPelota);

            if (limitePelotaTop)
                Canvas.SetTop(rtgPelota, Canvas.GetTop(rtgPelota) - posTopPelota);
            else
                Canvas.SetTop(rtgPelota, Canvas.GetTop(rtgPelota) + posTopPelota);

            if (Canvas.GetLeft(rtgPelota) == cvsPrincipal.MaxWidth-rtgPelota.Width)
                limitePelotaLeft = true;
            if (Canvas.GetLeft(rtgPelota) == cvsPrincipal.MinWidth)
                limitePelotaLeft = false;
            if (Canvas.GetTop(rtgPelota) > cvsPrincipal.MaxHeight-rtgPelota.Height)
                limitePelotaTop = true;
            if (Canvas.GetTop(rtgPelota) == cvsPrincipal.MinHeight)
                limitePelotaTop = false;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            tiempo.Start();
        }

        /*if (MensajeStart())
            {
                Canvas.SetLeft(rtgPelota, posicionIzquierdaPelota++);
                Canvas.SetRight(rtgPelota, posicionDerechaPelota++);
            }
         */
    }
}
