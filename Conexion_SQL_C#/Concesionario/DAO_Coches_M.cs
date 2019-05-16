using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//-----------------------
using MySql.Data.MySqlClient;

namespace Concesionario
{
    class DAO_Coches_M
    {
        public MySqlConnection conexion;

        public void Conectar(string srv, string db, string user, string pwd)
        {
            string cadenaConexion = string.Format("server={0};database={1};uid={2};pwd={3}", srv, db,user,pwd);
            conexion = new MySqlConnection(cadenaConexion);
            try
            {
                conexion.Open(); // Establece la llamada a la session
            }
            catch (MySqlException ex)
            // Resultado
            // 0 --> No hay conexion con el servidor
            // 1045 --> Usuario/contraseña no valido
            {
                switch (ex.Number)
                {
                    case 0: throw new Exception("Cannot connect to server. Contact Firulais");
                    case 1045: throw new Exception("Invalid User/Password, please try again, torpedo");
                    default: throw;
                }
            }
        }

        public void Desconectar()
        {
            try
            {
                if (conexion != null)
                    conexion.Clone();
            }
            catch (MySqlException)
            {
                throw;
            }
        }

        public List<Coche> Select(string sql)
        {
            List<Coche> listado = new List<Coche>();

            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            // Creamos un datareader y recuperamos la consulta ejecutada
            MySqlDataReader lector = cmd.ExecuteReader();
            while (lector.Read())
            {
                Coche unCoche = new Coche();
                unCoche.codCoche = lector["codCoche"].ToString();
                unCoche.cifm = lector["cifm"].ToString();
                unCoche.nombre = lector["nombre"].ToString();
                unCoche.modelo = lector["modelo"].ToString();
                listado.Add(unCoche);
            }
            lector.Close();
            return listado;
        }

        public List<Coche> Rutina(int num)
        {
            return null;
        }


    }
}
