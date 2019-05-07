﻿/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		Ejercicio 13
 *  Autor:		    Douglas W. Jurado Peña
 *  Versión:		DAM 2018/2019
 *  Descripción:	Haz un programa que tenga un fichero en el que vaya guardando los datos: Nombre usuario, fecha, hora y tiempo de
 *                  conexión, para cada una de las veces que se ha ejecutado.
-------------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;   // Sirve para por ejemplo, poder medir el tiempo transcurrido. Además de poder abrir automaticamente un archivo seleccionado cuando termine de realizar las operaciones.
using System.Security.Principal;    //Para saber información del usuario y sobre windows.

namespace R8_Ejercicio13
{
    class Program
    {
        static void Main(string[] args)
        {
            string ruta = @"C:\Prueba\ej13.txt";
            Stopwatch sw = Stopwatch.StartNew();
            DateTime fechaInicio = DateTime.Now;


            using (FileStream flujo = new FileStream(ruta, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter escritor = new StreamWriter(flujo))
                {
                    escritor.WriteLine("           Nombre de Usuario: {0}", WindowsIdentity.GetCurrent().Name);
                    escritor.WriteLine("           Fecha de conexión: {0}", fechaInicio.ToShortDateString());
                    escritor.WriteLine("            Hora de conexión: {0}", fechaInicio.ToShortTimeString());
                    sw.Stop();
                    escritor.WriteLine("          Tiempo de conexión: {0}", sw.Elapsed);
                    escritor.WriteLine("".PadLeft(40,'─'));
                }
            }

            Process.Start(ruta); // Abre el fichero automaticamente.

            Console.ReadLine();        
        }
    }
}
