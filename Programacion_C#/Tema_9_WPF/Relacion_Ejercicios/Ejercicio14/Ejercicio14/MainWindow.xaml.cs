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
//---------------
using Microsoft.Win32;
using System.IO;

namespace Ejercicio14
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int _numeroDeLineas = 0;
        int _numeroDePalabras = 0;
        char[] _separadores = { ' ', ',', ';', '-', '.', '/', '(', ')', '?', '¿', '!', '¡', ':', '=' };
        string _fichero = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void tbxFichero_Click(object sender, RoutedEventArgs e)
        {
            tbkAtributos.Text = "Atributos: ";
            tbkLineas.Text = "Número de Lineas: ";
            tbkPalabras.Text = "Número de Palabras: ";
            tbkTamaño.Text = "Tamaño: ";

            OpenFileDialog _ventana = new OpenFileDialog();

            if (_ventana.ShowDialog() == true)
            {
                _fichero = _ventana.FileName;
            }

            tbkAtributos.Text += Atributos(_fichero);
            tbkLineas.Text += CuentaLineas(_fichero).ToString();
            tbkPalabras.Text += CuentaPalabras(_fichero).ToString();
            tbkTamaño.Text += TamañoFichero(_fichero).ToString();
        }

        string Atributos(string fichero)
        {
            string atributos;

            return atributos = File.GetAttributes(fichero).ToString();
        }
        int CuentaLineas(string fichero)
        {
            using(FileStream flujo = new FileStream(fichero, FileMode.Open, FileAccess.Read))
            using (StreamReader lector = new StreamReader(flujo))
            {
                while (lector.ReadLine() != null)
                {
                    _numeroDeLineas++;
                }
            }
            return _numeroDeLineas;
        }
        int CuentaPalabras(string fichero)
        {
            string[] palabras;
            string lineaLeida = "";

            using (FileStream flujo = new FileStream(fichero, FileMode.Open, FileAccess.Read))
            using (StreamReader lector = new StreamReader(flujo))
            {
                while ((lineaLeida = lector.ReadLine()) != null)
                {
                    palabras = lineaLeida.Split(_separadores, StringSplitOptions.RemoveEmptyEntries);
                    _numeroDePalabras += palabras.Length;
                }
            }

            return _numeroDePalabras;
        }
        double TamañoFichero(string fichero)
        {
            FileInfo propiedades = new FileInfo(fichero);

            return (propiedades.Length / 1024) / 1024;
        }
    }
}
