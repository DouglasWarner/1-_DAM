﻿﻿/*-------------------------------------------------------------------------------------------------------------
 *  Programa:		Ejercicio 12
 *  Autor:		    Douglas W. Jurado Peña
 *  Versión:		DAM 2018/2019
 *  Descripción:	Haz un programa permita acceder, usando un componente, a un fichero de texto y cuente el número de líneas que 
 *                  hay, su tamaño, sus atributos y el número de palabras, el resultado se mostrará en pantalla.
-------------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace R8_Ejercicio12
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            double tamañoKiloBytes = 1024F;
            string palabra;
            string[] catPalabras;
            string[] lineas;
            char[] separadores = { ',', ' ', (char)13 };
            string ruta = "";
            FileInfo info;

            OpenFileDialog ventada = new OpenFileDialog();

            if (ventada.ShowDialog() == DialogResult.OK)
                ruta = ventada.FileName;

            // CANTIDAD DE LINEAS
            lineas = File.ReadAllLines(ruta);
            
            // CANTIDAD DE PALABRAS
            palabra = File.ReadAllText(ruta);
            catPalabras = palabra.Split(separadores, StringSplitOptions.RemoveEmptyEntries);

            // ATRIBUTOS
            info = new FileInfo(ruta);
            info.Attributes |= FileAttributes.ReadOnly;
            info.Attributes |= FileAttributes.Archive;

            Console.WriteLine("Nombre fichero: {0}", ventada.FileName);
            Console.WriteLine("Cantidad de palabras: {0}", catPalabras.Length);
            Console.WriteLine("Cantidad de lineas: {0} --> {1}", lineas.Length);
            Console.WriteLine("Tamaño: {0:F} KiloBytes", info.Length / tamañoKiloBytes);
            Console.WriteLine("Atributos: {0}", info.Attributes);

            Console.ReadLine();
        }
    }
}
