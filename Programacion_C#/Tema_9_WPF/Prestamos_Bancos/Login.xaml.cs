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
using System.Windows.Shapes;
using System.IO;

namespace Prestamos_Bancos
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Dictionary<string, string> Usuario = new Dictionary<string, string>();

        public Login()
        {
            InitializeComponent();
            inicializar();
        }

        void inicializar()
        {
            Usuario tmpUser = new Usuario();
            string ruta = @"C:\Prueba\usuarios.txt";
            string tmpUsuario = string.Empty;
            char separador = ';';

            if (!File.Exists(ruta))
            {
                MessageBox.Show("Error: Fichero no existe");
                this.Close();
                return;
            }

            using (StreamReader lector = new StreamReader(ruta))
            {
                while ((tmpUsuario = lector.ReadLine()) != null)
                {
                    tmpUser.Nombre = tmpUsuario.Substring(0, tmpUsuario.IndexOf(separador));
                    tmpUser.Contraseña = tmpUsuario.Substring(tmpUsuario.IndexOf(separador)+1);
                    Usuario.Add(tmpUser.Nombre,tmpUser.Contraseña);
                    tmpUser = new Usuario();
                }
            }
        }

        private void Window_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Return)
                {
                    if (Usuario.ContainsKey(tbxNombre.Text) && Usuario.ContainsValue(pbxContraseña.Password))
                    {
                        MainWindow ventaa = new MainWindow();
                        ventaa.Show();
                    }
                    else
                        MessageBox.Show("El usuario o la contraseña son incorrectas");
                }

            }
            catch 
            {
                MessageBox.Show("Error: el usuario o la contraseña es incorrecta");
            }

        }
    }
}
