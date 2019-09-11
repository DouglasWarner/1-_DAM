//---------------
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Ejercicio_15
{
	/// <summary>
	/// Lógica de interacción para MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		GestionPersona _listaPersona;
		string _ruta = string.Empty;
		int _posInicial = 0;
		FileStream flujo;
		
		public MainWindow()
		{
			InitializeComponent();
		}

		private void BtnCrearFichero_Click(object sender, RoutedEventArgs e)
		{
			_ruta = Path.GetDirectoryName(Directory.GetCurrentDirectory()) +@"\"+tbxRuta.Text;
			File.Create(_ruta);
		}

		private void BtnAnadir_Click(object sender, RoutedEventArgs e)
		{
			
		}
	}
}
