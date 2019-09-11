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
using System.IO;
using Microsoft.Win32;

namespace Ejercicio_21
{
	/// <summary>
	/// Lógica de interacción para MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		List<string> listaPalindromo = new List<string>();
		List<string> listaPalabras = new List<string>();
		string ruta = string.Empty;
		string linea = string.Empty;
		char[] separadores = { '-', '.', ',', ';', ':', ' ' };

		int posicionLinea = 0;
		string palabraLarga = string.Empty;
		string palabraCorta = "                             ";
		long nLineaPalabraLarga = 0;
		long nLineaPalabraCorta = 0;
		string palabraRepMax = string.Empty;
		string palabraRepMin = string.Empty;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			lbxResultado.Items.Clear();

			ruta = tbxRuta.Text;
			string[] tmpLinea = null;
			using(FileStream flujo = new FileStream(ruta,FileMode.Open,FileAccess.Read))
			using (StreamReader lector = new StreamReader(flujo, UTF8Encoding.UTF8))
			{
				while ((linea = lector.ReadLine()) != null)
				{
					tmpLinea = linea.Split(separadores, StringSplitOptions.RemoveEmptyEntries);
					posicionLinea++;
					foreach (string palabra in tmpLinea)
					{
						if (palabra.Length > palabraLarga.Length)
						{
							palabraLarga = palabra;
							nLineaPalabraLarga = posicionLinea;
						}
						if (palabra.Length < palabraCorta.Length)
						{
							palabraCorta = palabra;
							nLineaPalabraCorta = posicionLinea;
						}
						if (esPalindromo(palabra))
							listaPalindromo.Add(palabra);
						listaPalabras.Add(palabra);

						
						if (listaPalabras.Count(n => n == palabra) > listaPalabras.Count(n => n == palabraRepMax))
							palabraRepMax = palabra;
						if (listaPalabras.Count(n => n == palabra) < listaPalabras.Count(n => n == palabraRepMin))
							palabraRepMin = palabra;
					}
				}
			}
			
			lbxResultado.Items.Add(string.Format("La palabra más larga: {0}, su longitud: {1}\n y en que linea aparece: {2}", palabraLarga, palabraLarga.Length, nLineaPalabraLarga));
			lbxResultado.Items.Add(string.Format("La palabra más corta: {0}, su longitud: {1}\n y en que linea aparece: {2}", palabraCorta, palabraCorta.Length, nLineaPalabraCorta));
			lbxResultado.Items.Add(string.Format("La palabra que más se repite: {0}",palabraRepMax));
			lbxResultado.Items.Add(string.Format("La palabra que menos se repite: {0}",palabraRepMin));
			lbxResultado.Items.Add(string.Format("Palabras palindromos: \n"));
			for (int i = 0; i < listaPalindromo.Count; i++)
			{
				lbxResultado.Items.Add(listaPalindromo[i]);
			}
		}

		public bool esPalindromo(string palabra)
		{
			string tmpPalabra = string.Empty;
			
			for (int i = palabra.Length-1; i > 0; i--)
			{
				tmpPalabra += palabra[i];
			}

			return tmpPalabra.Equals(palabra);
		}

		private void TbxRuta_GotFocus(object sender, RoutedEventArgs e)
		{
			OpenFileDialog ventana = new OpenFileDialog();

			ventana.ShowDialog();

			tbxRuta.Text = ventana.FileName;
		}
	}
}
