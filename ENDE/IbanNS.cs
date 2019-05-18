using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R6_Ejercicio10
{
    class Program
    {
		static void Main(string[] args)
        {
			// ES7100302053091234567895
			try
			{
				Console.WriteLine(EsIbanValido("ES7100302053091234567895") + "\nEl iban es correcto");
			}
			catch (ArgumentNullException)
			{
				Console.WriteLine("ERROR: Debe de tener 20 dígitos");
			}
			catch (NullReferenceException)
			{
				Console.WriteLine("ERROR: Debe de tener 20 dígitos");
			}
            Console.ReadLine();
        }

		static bool EsIbanValido(string cc) => cc == CalcularIBAN(cc.Substring(4));

		private static string CalcularIBAN(string cc)
		{
			if (!ComprobarLongitudCC(ref cc))
                return "EL CC debe tener 20 dígitos";

            // ES00 España
            string ES = cc + "142800";

            string[] partesCC = new string[5];			
            TrocearCC(ES, ref partesCC);

            int iresultado = 0;
            string resultado = partesCC[0];

            CalcularModulo(partesCC, ref iresultado, ref resultado);

            int iRestoIban = 98 - int.Parse(resultado);
            string restoIban = iRestoIban.ToString();
            if (restoIban.Length == 1)
                restoIban = "0" + restoIban;
			
			return "ES" + restoIban + cc;
        }

		private static void CalcularModulo(string[] partesCC, ref int iresultado, ref string resultado)
        {
            for (int i = 0; i < partesCC.Length-1; i++)
            {
                iresultado = int.Parse(resultado + partesCC[i+1]) % 97;
                resultado = iresultado.ToString();
            }
        }

		private static void TrocearCC(string cc, ref string[] partesCC)
        {
			partesCC[0] = cc.Substring(0, 5);
			partesCC[1] = cc.Substring(5, 5);
            partesCC[2] = cc.Substring(10, 5);
            partesCC[3] = cc.Substring(15, 5);
			partesCC[4] = cc.Substring(20, 6);
        }

		private static bool ComprobarLongitudCC(ref string cc)
        {
            for (int i = 0; i < cc.Length; i++)
			{
                if(cc[i] == ' ')
			        cc = cc.Remove(i,1);
			}
            if (cc.Length != 20)
                return false;
            return true;
        }
    }
}
