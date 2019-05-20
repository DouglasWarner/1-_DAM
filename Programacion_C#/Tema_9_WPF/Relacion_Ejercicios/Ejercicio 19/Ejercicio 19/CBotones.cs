using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Ejercicio_19
{
	class CBotones
	{
		Button btn;

        public Button Btn { get { return btn; } set { btn = value; } }

		public CBotones(int i, int j)
		{
			Btn = new Button();
			Btn.Content = string.Format("[{0},{1}]",i,j);
			Btn.FontSize = 20;
			Btn.Height = 30;
			Btn.Width = 50;
			btn.Background = Brushes.DarkCyan;
			Btn.Margin = new Thickness(10,10,10,10);
			//btn.MouseMove += Btn_MouseMove;
			Btn.MouseLeave += Btn_MouseLeave;
			Btn.Click += Btn_Click;
			//btn.PreviewMouseMove += Btn_PreviewMouseMove;
			//btn.PreviewMouseUp += Btn_PreviewMouseUp;
		}

		private void Btn_PreviewMouseUp(object sender, MouseButtonEventArgs e)
		{
			this.Btn.Background = Brushes.DarkCyan;
		}

		private void Btn_PreviewMouseMove(object sender, MouseEventArgs e)
		{
			this.Btn.Background = Brushes.DarkCyan;
		}

		private void Btn_MouseMove(object sender, MouseEventArgs e)
		{
			this.Btn.Background = Brushes.DarkCyan;
		}

		private void Btn_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show(string.Format("Hola soy el boton {0}", Btn.Content));
		}

		private void Btn_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
		{
			if (this.btn.Background == Brushes.Red)
				this.btn.Background = Brushes.DarkBlue;
			else
				this.Btn.Background = Brushes.Red;
		}
	}
}
