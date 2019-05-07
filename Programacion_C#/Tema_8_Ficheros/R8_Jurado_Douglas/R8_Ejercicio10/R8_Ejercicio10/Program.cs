/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		Ejercicio 10
 *  Autor:		    Douglas W. Jurado Peña
 *  Versión:		DAM 2018/2019
 *  Descripción:	Haz un programa en C# que muestre por pantalla el contenido de un fichero de texto al revés, comenzando por el
 *                  final hasta el principio.
-------------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace R8_Ejercicio10
{
    class Program
    {
        static void Main(string[] args)
        {
            string ruta = @"C:\Prueba\EJ10.txt";

            FileStream flujo;
            int caracter;

            flujo = new FileStream(ruta, FileMode.Open, FileAccess.Read);

            Console.WriteLine("Lectura Normal\n");

            for (int i = 0; i < flujo.Length; i++)
            {
                if ((caracter = flujo.ReadByte()) != -1)
                    Console.Write((char)caracter);
            }

            Console.WriteLine("\n\n"+"".PadLeft(40,'─'));
            Console.WriteLine("\nLectura Alreves\n");

            for (long i = flujo.Length; i > 0; i--)
            {
                flujo.Seek(i-1, SeekOrigin.Begin);
                if ((caracter = flujo.ReadByte()) != -1)
                    Console.Write((char)caracter);
            }

            flujo.Close();

            Console.ReadLine();
        }
    }
}
