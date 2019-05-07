﻿/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		Ejercicio 11
 *  Autor:		    Douglas W. Jurado Peña
 *  Versión:		DAM 2018/2019
 *  Descripción:	Haz un programa en C# que lea líneas desde el teclado (hasta introducir una línea vacía) lo almacene en un fichero 
 *                  muestre su contenido. Usa para ello las funciones codificadas en los ejercicios anteriores.
-------------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace R8_Ejercicio11
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string ruta = "";
            OpenFileDialog ventana = new OpenFileDialog();
            char respuesta;

            if (ventana.ShowDialog() == DialogResult.OK)
                ruta = ventana.FileName;

            Escribir(ruta);
            Console.WriteLine("Quieres ver el contenido?");

            respuesta = char.Parse(Console.ReadLine());

            if(respuesta == 's')
                Leer(ruta);
            else
                Console.WriteLine("bye");
        }

        static string Escribir(string ruta)
        {
            FileStream flujo = new FileStream(ruta, FileMode.Append, FileAccess.Write);
            StreamWriter escritor = new StreamWriter(flujo);
            string frase;

            Console.WriteLine("Escribe en el fichero. Para salir pulse enter 2 veces.");
            Console.WriteLine("".PadLeft(30, '─'));
            do
            {
                frase = Console.ReadLine();
                escritor.WriteLine(frase);
            } while (frase != "");

            escritor.Flush();
            escritor.Close();
            flujo.Close();

            Console.Clear();

            return frase;
        }
        static void Leer(string ruta)
        {
            FileStream flujo = new FileStream(ruta, FileMode.Open, FileAccess.Read);
            StreamReader lector = new StreamReader(flujo);

            Console.WriteLine("Contenido del fichero");
            Console.WriteLine("".PadLeft(30,'─'));

            Console.WriteLine(lector.ReadToEnd());

            lector.Close();
            flujo.Close();

            Console.ReadLine();
        }
    }
}
