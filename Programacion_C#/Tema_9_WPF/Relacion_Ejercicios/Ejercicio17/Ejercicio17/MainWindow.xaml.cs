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
        double posBarra = 35;
        double posTopPelota = 5;
        double posLeftPelota = 5;
        int pausa = 300000;
        bool limitePelotaTop = false;
        bool limitePelotaLeft = false;
        DispatcherTimer tiempo = new DispatcherTimer();
		int jugador = 1;
		double puntuacion = 0;
		string dificultad = "";

        public MainWindow()
        {
            InitializeComponent();
            Inicializar();
        }

        void Inicializar()
        {
            tiempo.Tick += tiempo_Tick;
        }

        void tiempo_Tick(object sender, EventArgs e)
		{
			puntuacion += 0.5;
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

            if (Canvas.GetLeft(rtgPelota) > cvsPrincipal.MaxWidth-rtgPelota.Width) // Para que la pelota valla a la izquierda
				limitePelotaLeft = true;
            if (Canvas.GetLeft(rtgPelota) < cvsPrincipal.MinWidth) // Para que la pelota valla a la derecha
                limitePelotaLeft = false;
			if (ColisionPelotaBarra()) // Para que la pelota suba
				 limitePelotaTop = true;
			if (Canvas.GetTop(rtgPelota) < cvsPrincipal.MinHeight) // Para que la pelota baje
				limitePelotaTop = false;
			if (Canvas.GetTop(rtgPelota) > cvsPrincipal.MaxHeight)
				MensajeLosser();				
        }

        private void mniEmpezar_Click(object sender, RoutedEventArgs e)
        {
			if (rbtnFacil.IsChecked == true)
				pausa = 300000;
			if (rbtnNormal.IsChecked == true)
				pausa = 190000;
			if (rbtnDificil.IsChecked == true)
				pausa = 99000;

			tiempo.Interval = new TimeSpan(pausa);
			Canvas.SetTop(rtgPelota, 5);
			Canvas.SetLeft(rtgPelota, 5);
			limitePelotaLeft = false;
			limitePelotaTop = false;
            tiempo.Start();
        }

        private void mniParar_Click(object sender, RoutedEventArgs e)
        {
            tiempo.Stop();
			puntuacion = 0;
        }

        private void mniEmpezar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right && Canvas.GetLeft(rtgBarra) < cvsPrincipal.MaxWidth - rtgBarra.Width)
                Canvas.SetLeft(rtgBarra, Canvas.GetLeft(rtgBarra) + posBarra);
            if (e.Key == Key.Left && Canvas.GetLeft(rtgBarra) > cvsPrincipal.MinWidth)
                Canvas.SetLeft(rtgBarra, Canvas.GetLeft(rtgBarra) - posBarra); 
        }

		private bool ColisionPelotaBarra()
		{
			Point vPelota = TransformToVisual(rtgPelota).Transform(new Point(0, 0));
			Point vBarra = TransformToVisual(rtgBarra).Transform(new Point(0, 0));
			double rangoAnchura = rtgPelota.Width - rtgBarra.Width;
			double rangoAltura = rtgPelota.Height - rtgBarra.Height;

			Rect rPelota = new Rect(vPelota.X, vPelota.Y, rtgPelota.Width, rtgPelota.Height);
			Rect rBarra = new Rect(vBarra.X + rangoAnchura, vBarra.Y + rangoAltura, rtgBarra.Width, rtgBarra.Height);
			Rect rColision = Rect.Intersect(rPelota, rBarra);

			return !rColision.IsEmpty;
		}

		private void MensajeLosser()
		{
			tiempo.Stop();
			MessageBoxResult resultado = MessageBox.Show(string.Format("Puntuación --> {0:F}\nQuieres empezar una partida nueva?",puntuacion),"Attention",MessageBoxButton.YesNo,MessageBoxImage.Information);
			ltbPuntuacion.Items.Add(string.Format("Jugador {0} -> {1}, {2}", jugador++, puntuacion, dificultad));
			if (resultado == MessageBoxResult.No)
				App.Current.Shutdown();
			else
			{
				Canvas.SetTop(rtgPelota, 5);
				Canvas.SetLeft(rtgPelota, 5);
				limitePelotaLeft = false;
				limitePelotaTop = false;
				puntuacion = 0;
			}
		}

		private void RabioButton_Checked(object sender, RoutedEventArgs e)
		{
			dificultad = ((RadioButton)sender).Content.ToString();
		}
	}
}
