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
        double posBarra = 30;
        double posTopPelota = 5;
        double posLeftPelota = 5;
        int pausa = 10030;
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
            StartPelota();
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

        private void mniEmpezar_Click(object sender, RoutedEventArgs e)
        {
            tiempo.Start();
        }

        private void mniParar_Click(object sender, RoutedEventArgs e)
        {
            tiempo.Stop();
        }

        private void mniEmpezar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right && Canvas.GetLeft(rtgBarra) < cvsPrincipal.MaxWidth - rtgBarra.Width)
                Canvas.SetLeft(rtgBarra, Canvas.GetLeft(rtgBarra) + posBarra);
            if (e.Key == Key.Left && Canvas.GetLeft(rtgBarra) > cvsPrincipal.MinWidth)
                Canvas.SetLeft(rtgBarra, Canvas.GetLeft(rtgBarra) - posBarra); 
        }

        /*if (MensajeStart())
            {
                Canvas.SetLeft(rtgPelota, posicionIzquierdaPelota++);
                Canvas.SetRight(rtgPelota, posicionDerechaPelota++);
            }
         */
    }
}
