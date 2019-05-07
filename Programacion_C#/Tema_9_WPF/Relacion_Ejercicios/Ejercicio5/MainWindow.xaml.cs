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
//-----------------------------
using System.IO;


namespace Ejercicio5
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int desplazamiento = 1;

        public MainWindow()
        {
            InitializeComponent();
            Inicializa();
        }

        void Inicializa()
        {
            txbDesplazamiento.Text = desplazamiento.ToString();
            tblEncriptado.Foreground = Brushes.Red;
        }

        private void btnAumentar_Click(object sender, RoutedEventArgs e)
        {
            if (desplazamiento == 4)
            {
                btnAumentar.IsEnabled = false;
                return;
            }
            txbDesplazamiento.Text = (++desplazamiento).ToString();
            btnDisminuir.IsEnabled = true;
        }

        private void btnDisminuir_Click(object sender, RoutedEventArgs e)
        {
            if (desplazamiento == 1)
            {
                btnDisminuir.IsEnabled = false;
                return;
            }
            txbDesplazamiento.Text = (--desplazamiento).ToString();
            btnAumentar.IsEnabled = true;
        }

        private void btnEncriptar_Click(object sender, RoutedEventArgs e)
        {
            tblOriginal.Text = tbxFrase.Text;
            tblEncriptado.Text = Encriptar(tbxFrase.Text, int.Parse(txbDesplazamiento.Text));
            tblDesencriptado.Text = Desencriptar(tblEncriptado.Text, int.Parse(txbDesplazamiento.Text));
        }

        string Encriptar(string frase, int desplazamiento)
        {
            string resultado = string.Empty;

            for (int i = 0; i < frase.Length; i++)
            {
                resultado += (char)(frase[i]+desplazamiento);
            }

            return resultado;
        }

        string Desencriptar(string frase, int desplazamiento)
        {
            string resultado = string.Empty;

            for (int i = 0; i < frase.Length; i++)
            {
                resultado += (char)(frase[i] - desplazamiento);
            }

            return resultado;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FicheroTextoEncriptado fh = new FicheroTextoEncriptado();
            fh.Show();
            fh.textoEncriptado.Text = EncriptarTextoFichero();
            fh.textoDesencriptado.Text = DesencriptarTextoFichero(fh.textoEncriptado.Text.ToString());
        }

        string EncriptarTextoFichero()
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();

            if (ofd.ShowDialog() == false)
                return "";
            
            FileStream flujo = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);

            int caracter;
            StringBuilder texto = new StringBuilder();


            while ((caracter = flujo.ReadByte()) != -1)
            {
                texto.Append((char)caracter);
            }

            return Encriptar(texto.ToString(), int.Parse(txbDesplazamiento.Text));
        }

        string DesencriptarTextoFichero(string texto)
        {
            string resultado = string.Empty;

            for (int i = 0; i < texto.Length; i++)
            {
                resultado += (char)(texto[i] - desplazamiento);
            }

            return resultado;
        }
    }
}
