using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------------------
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
//--------------------------------

namespace Ejercicio_15
{
    class GestionPersona
    {
        string _fichero;

        public GestionPersona(string fichero)
        {
            _fichero = fichero;
        }

        #region MyMethods

        public string GenerarHtml()
        {
            // Crea un fichero con formato HTML con tabla para mostrar el contenido de las personas
            // DEVUELVE: La ruta del fichero html o un string vacio si no se creó.
            int nLinea = 1;
            string ficheroCreado = Path.ChangeExtension(_fichero, "html");
            Persona tmp = null;
            StringBuilder docHtml = new StringBuilder();
            if (!File.Exists(_fichero))
                return "";

            // Añadiendo etiquetas ...
            docHtml.Append("<html>");
            docHtml.Append("<head>");
            docHtml.Append("<title>Listado de Personas</title>");
            docHtml.Append("</head>");
            docHtml.Append("<body>");
            docHtml.Append("<h1>Listado de Personas</h1>");
            docHtml.Append("<table border='1'>");
            docHtml.Append("<tr bgcolor='red'> <th>Orden</th> <th>Apellido</th> <th>Nombre</th> <th>Sueldo</th> <th>Fecha de Nacimiento</th> </tr>");
            
            // Cuerpo con los datos ...
            using (FileStream flujo = new FileStream(_fichero, FileMode.Open, FileAccess.Read))
            {
                IFormatter formate = new BinaryFormatter();
                while (true)
                {
                    try
                    {
                        tmp = (Persona)formate.Deserialize(flujo);
                        if (tmp.Borrado)
                            continue;
                        if (nLinea % 2 == 0)
                            docHtml.Append("<tr bgcolor='white'>");
                        else
                            docHtml.Append("<tr bgcolor='yellow'>");
                        docHtml.Append("<td>" + nLinea++.ToString("000") + "</td>");
                        docHtml.Append("<td>" + tmp.Apellido + "</td>");
                        docHtml.Append("<td>" + tmp.Nombre + "</td>");
                        docHtml.Append("<td>" + tmp.Sueldo.ToString("0000.0") + "</td>");
                        docHtml.Append("<td>" + tmp.FechaNac.ToShortDateString() + "</td>");
                        docHtml.Append("</tr>");
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }// Fin del while
            }// Fin using
            docHtml.Append("</table></body></html>");

            // Crear el fichero de salida ...
            using (FileStream flujoSalida = new FileStream(ficheroCreado, FileMode.Create, FileAccess.Write))
            {
                using(StreamWriter salido = new StreamWriter(flujoSalida, Encoding.Default))
                {
                    salido.Write(docHtml.ToString());
                }
            }
            return ficheroCreado;
        }

        public bool Anadir(Persona persona)
        {
            // Forma de instanciar utilizando el Poliformismo
            IFormatter formato = new BinaryFormatter();
            
            /* La forma normal de instanciar un objeto
            BinaryFormatter formatoB = new BinaryFormatter();
            */

            using(FileStream flujo = new FileStream(_fichero, FileMode.Append, FileAccess.Write))
            {
                // Este método añade en flujo, del tiron, todo los campos de persona.
                formato.Serialize(flujo, persona);
            }

            return true;
        }

        public void AnadirVariasPruebas(int nPersonas)
        {
            string[] nombres = { "Pepe", "Hector", "Juan", "Sandra", "Alejandro", "Manuel", "Maria" };
            string[] apellidos = { "Gil", "Muñoz", "Rodriguez", "Sanchez", "Garcia", "Moreno", "Pendor" };

            Random rnd = new Random();
            Persona tmp = null;

            // Añade varias personas a la lista Personas
            for (int i = 0; i < nPersonas; i++)
            {
                tmp = new Persona(apellidos[rnd.Next(apellidos.Length)], nombres[rnd.Next(nombres.Length)], (float)rnd.NextDouble() * 1000, DateTime.Now - TimeSpan.FromDays(rnd.Next(1, 365 * 20)));

                Anadir(tmp);
            }
        }

        public void Listar()
        {
            if (!File.Exists(_fichero))
            {
                Console.Write("No hay datos a listar. El fichero {0} no existe...",_fichero);
                Console.ReadLine();
                return;
            }

            Persona tmp = null;
            using (FileStream flujo = new FileStream(_fichero, FileMode.Open, FileAccess.Read))
            {
                IFormatter formato = new BinaryFormatter();
                while (true)
                {
                    try
                    {
                        tmp = (Persona)formato.Deserialize(flujo);
                        if (tmp.Borrado)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(tmp.ToString());
                            Console.ResetColor();
                        }
                        Console.WriteLine(tmp.ToString());
                    }
                    catch
                    {
                        // Se terminó el fichero
                        break;
                    }
                }
            }
        }

        public long Buscar(string apellido)
        {
            long PosPersonaAnterior = 0;
            long PosPersonaActual = 0;

            if (!File.Exists(_fichero))
                return -1; // Si no existe sale cantando bajito.

            Persona tmp = null;
            using (FileStream flujo = new FileStream(_fichero, FileMode.Open, FileAccess.Read))
            {
                IFormatter formato = new BinaryFormatter();
                while (true)
                {
                    try
                    {
                        PosPersonaAnterior = flujo.Position; // Esto es lo devuelto
                        tmp = (Persona)formato.Deserialize(flujo);

                        if (tmp.Apellido == apellido && !tmp.Borrado)
                        {
                            PosPersonaActual = flujo.Position;
                            
                            return PosPersonaAnterior;
                        }
                        
                    }
                    catch
                    {
                        return -1;
                    }
                }
            }
        }

        public bool Borrar(long PosBorrar)
        {
            if (PosBorrar == -1)
                return false;

            Persona tmp = null;

            using (FileStream flujo = new FileStream(_fichero, FileMode.Open, FileAccess.ReadWrite))
            {
                IFormatter formato = new BinaryFormatter();
                flujo.Position = PosBorrar;
                tmp = (Persona)formato.Deserialize(flujo);
                tmp.Borrado = true;
                flujo.Position = PosBorrar;
                formato.Serialize(flujo, tmp);
            }

            return true;
        }

        public string Ver(long PosVer)
        {
            if (PosVer == -1)
                return "";

            Persona tmp = null;

            using (FileStream flujo = new FileStream(_fichero, FileMode.Open, FileAccess.Read))
            {
                IFormatter formato = new BinaryFormatter();
                flujo.Position = PosVer;
                tmp = (Persona)formato.Deserialize(flujo);

				return tmp.Borrado ? "No encontrado" : tmp.ToString(); 
            }
        }
        #endregion
    }
}
