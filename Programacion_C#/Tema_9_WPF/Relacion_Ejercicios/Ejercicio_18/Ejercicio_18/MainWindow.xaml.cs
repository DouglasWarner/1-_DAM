using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Ejercicio_18
{
	/// <summary>
	/// Lógica de interacción para MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Jarra jarraA;
		Jarra jarraB;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void BtnCrearJarras_Click(object sender, RoutedEventArgs e)
		{
			sbrMensaje.Items.Clear();
			if (!btnCrearJarras.IsEnabled)
				return;

			int tmpJarra = 0;
			if(!int.TryParse(tbxJarraA.Text, out tmpJarra))
			{
				sbrMensaje.Items.Add("Ingresa una cantidad");
				return;
			}
			jarraA = new Jarra(tmpJarra);
			if(!int.TryParse(tbxJarraB.Text,out tmpJarra))
			{
				sbrMensaje.Items.Add("Ingresa una cantidad");
				return;
			}
			jarraB = new Jarra(tmpJarra);

			pgbJarraA.Maximum = Math.Max(jarraA.Capacidad, jarraB.Capacidad);
			pgbJarraB.Maximum = Math.Max(jarraA.Capacidad, jarraB.Capacidad);
			sbrMensaje.Items.Add("Las Jarras se han inicializado");
			btnCrearJarras.IsEnabled = false;
		}

		private async void BtnDemo_Click(object sender, RoutedEventArgs e)
		{
			await Task.Run(() => { Thread.Sleep(1000); });
		}

		private void BtnLlenarA_Click(object sender, RoutedEventArgs e)
		{
			jarraA.Llenar();
			pgbJarraA.Value = jarraA.Contenido;
			lbxResultado.Items.Add("Se llena la jarra A");
		}

		private void BtnLlenarB_Click(object sender, RoutedEventArgs e)
		{
			jarraB.Llenar();
			pgbJarraB.Value = jarraB.Contenido;
			lbxResultado.Items.Add("Se llena la jarra B");
		}

		private void BtnFinalizar_Click(object sender, RoutedEventArgs e)
		{
			jarraA = new Jarra();
			jarraB = new Jarra();
			tbxJarraA.Text = "";
			tbxJarraB.Text = "";
			btnCrearJarras.IsEnabled = true;
			sbrMensaje.Items.Clear();

			lbxResultado.Items.Clear();

			pgbJarraA.Value = 0;
			pgbJarraB.Value = 0;
		}

		private void BtnVaciarA_Click(object sender, RoutedEventArgs e)
		{
			jarraA.Vaciar();			
			pgbJarraA.Value = jarraA.Contenido;	
		}

		private void BtnVaciarB_Click(object sender, RoutedEventArgs e)
		{
			jarraB.Vaciar();
			pgbJarraB.Value = jarraB.Contenido;
		}

		private void AtoB_Click(object sender, RoutedEventArgs e)
		{
			if (pgbJarraB.Value == pgbJarraB.Maximum)
				return;
			if (pgbJarraA.Value != pgbJarraA.Maximum+1)
			{
				jarraB.LlenarDesde(jarraA);
				pgbJarraB.Value = jarraB.Contenido;
				pgbJarraA.Value = jarraA.Contenido;
				lbxResultado.Items.Add("Se vuelca la jarra A sobre la jarra B");
			}
			else
			{
				sbrMensaje.Items.Clear();
				sbrMensaje.Items.Insert(0, "Las Jarra han llegado a su limite");
			}
		}

		private void BtoA_Click_1(object sender, RoutedEventArgs e)
		{
			if (pgbJarraA.Value == pgbJarraA.Maximum)
				return;
			if (pgbJarraB.Value != pgbJarraB.Maximum+1)
			{
				jarraA.LlenarDesde(jarraB);
				pgbJarraA.Value = jarraA.Contenido;
				pgbJarraB.Value = jarraB.Contenido;
				lbxResultado.Items.Add("Se vuelca la jarra B sobre la jarra A");
			}
			else
			{
				sbrMensaje.Items.Clear();
				sbrMensaje.Items.Insert(0, "Las Jarra han llegado a su limite");
			}
		}
	}
}
