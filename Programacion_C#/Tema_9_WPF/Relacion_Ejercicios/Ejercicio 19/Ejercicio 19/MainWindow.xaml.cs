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

namespace Ejercicio_19
{
	/// <summary>
	/// Lógica de interacción para MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		int fila;
		int columna;

		public MainWindow()
		{
			InitializeComponent();
			Inicializar();
		}

		void Inicializar()
		{
			for (int i = 1; i < 21; i++)
			{
				cbxFilas.Items.Add(i);
				cbxColumnas.Items.Add(i);
			}
			cbxFilas.SelectedItem = cbxFilas.Items[5];
			cbxColumnas.SelectedIndex = 5;
		}

		private void BtnCrearMatriz_Click(object sender, RoutedEventArgs e)
		{
			stpMatriz.Children.Clear();
			fila = int.Parse(cbxFilas.SelectedItem.ToString());
			columna = int.Parse(cbxColumnas.SelectedItem.ToString());
			CBotones btn;
            LineBreak saltoLinea = new LineBreak();
            

			for (int i = 0; i < fila; i++)
			{
				for (int j = 0; j < columna; j++)
				{
					btn = new CBotones(i, j);
					stpMatriz.Children.Add(btn.Btn);
				}
                
			}
		}
		
	}
}
