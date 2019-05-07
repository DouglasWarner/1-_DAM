﻿/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		Ejercicio 9
 *  Autor:		    Douglas W. Jurado Peña
 *  Versión:		DAM 2018/2019
 *  Descripción:	Escribe un programa que tome todos los ficheros dados como argumentos en la línea de comando y los muestre por
 *                  pantalla el contenido de uno tras otro, separando cada contenido por una línea horizontal y el nombre del fichero que
 *                  se mostrará.
-------------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace R8_Ejercicio9
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo archivo;
            FileStream flujo;
            StreamReader lector;

            for (int i = 0; i < args.Length; i++)
            {
                flujo = new FileStream(args[i], FileMode.Open, FileAccess.Read);
                lector = new StreamReader(flujo);
                archivo = new FileInfo(args[i]);

                Console.WriteLine("\n\nNombre --> {0}", archivo.Name);
                Console.WriteLine(lector.ReadToEnd());
                Console.WriteLine("".PadLeft(40, '─'));
            }

            Console.ReadLine();
        }
    }
}
