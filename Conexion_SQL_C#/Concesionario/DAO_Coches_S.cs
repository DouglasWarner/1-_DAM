using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------
using System.Data.SQLite;

namespace Concesionario
{
    class DAO_Coches_S
    {
        public SQLiteConnection conexion;

        public void Conectar(string srv, string db, string user, string pwd)
        {
            string cadenaConexion = string.Format("Data Source={0};Version=3;FailIfMissing=true",db);
            conexion = new SQLiteConnection(cadenaConexion);
            try
            {
                conexion.Open(); // Establece la llamada a la session
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Error de conexion: " + ex.Data);
            }
        }

        public void Desconectar()
        {
            try
            {
                if (conexion != null)
                    conexion.Clone();
            }
            catch (SQLiteException)
            {
                throw;
            }
        }

        public List<Coche> Select(string sql)
        {
            List<Coche> listado = new List<Coche>();
            List<Ajedrez> listadoAjedrez = new List<Ajedrez>();

            SQLiteCommand cmd = new SQLiteCommand(sql, conexion);
            // Creamos un datareader y recuperamos la consulta ejecutada
            SQLiteDataReader lector = cmd.ExecuteReader();
            while (lector.Read())
            {
                Coche unCoche = new Coche();
                /*Ajedrez unAjedrez = new Ajedrez();
                unAjedrez.nSocio = lector["nSocio"].ToString();
                listadoAjedrez.Add(unAjedrez);*/
                
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
