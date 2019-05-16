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

namespace Concesionario
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DAO_Coches_M conexionM;
        DAO_Coches_S conexionS;
        int tipo = 0;

        public MainWindow()
        {
            InitializeComponent();
            conexionM = new DAO_Coches_M();
            conexionS = new DAO_Coches_S();
        }

        private void btnConectar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tipo == 0)
                {
                    conexionM.Conectar(tbxIp.Text, tbxBD.Text, tbxUser.Text, tbxPwd.Password);
                    lblEstado.Content = "Conectado con éxisto a MariaBD";
                }
                else
                {
                    conexionS.Conectar(tbxIp.Text, tbxBD.Text, tbxUser.Text, tbxPwd.Password);
                    lblEstado.Content = "Conectado con éxisto a SQLite";
                }
            }
            catch (Exception ex)
            {
                lblEstado.Content = "Error: " + ex.Message;
            }
        }

        private void btnDesconectar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(tipo == 0)
                    conexionM.Desconectar();
                else
                    conexionS.Desconectar();
                lblEstado.Content = "Sin conexion";
            }
            catch (Exception ex)
            {
                lblEstado.Content = "Error: " + ex.Message;
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            // dgListaCoches.FrozenColumnCount = 1;
            // dgListaCoches.RowCount = 1;
            // dgListaCoches[0,].Value = null;

            dgListaCoches.ItemsSource = null;
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            List<Coche> datos;
            if(tipo == 0)
                datos = conexionM.Select("select codcoche, cifm, nombre, modelo from coches;");
            else
                datos = conexionS.Select("select codcoche, cifm, nombre, modelo from coches;");

            dgListaCoches.ItemsSource = datos;
        }

        private void rdbMariaDB_Checked(object sender, RoutedEventArgs e)
        {
            tipo = 0;
        }

        private void rdbSQLite_Checked(object sender, RoutedEventArgs e)
        {
            tipo = 1;
        }

       

    }
}
