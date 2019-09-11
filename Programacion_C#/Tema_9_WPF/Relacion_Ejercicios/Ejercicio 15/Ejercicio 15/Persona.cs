using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_15
{
    [Serializable]
    class Persona
    {
        private static int contador = 0;
        private int _codigo;
        private string _apellido;
		private string _nombre;
		private float _sueldo;
		private DateTime _fechaNacimiento;
		private bool _borrado;
        // ETC

		public Persona()
		{ }
		public Persona(string apellido, string nombre)
		{
			this._codigo = contador++;
			Apellido = apellido;
			Nombre = nombre;
		}
		public Persona(string apellido, string nombre, float sueldo)
		{
			this._codigo = contador++;
			Apellido = apellido;
			Nombre = nombre;
			Sueldo = sueldo;
		}
		public Persona(string apellido, string nombre, float sueldo, DateTime fechaNac)
        {
            this._codigo = contador++;
            Apellido = apellido;
            Nombre = nombre;
            Sueldo = sueldo;
            FechaNac = fechaNac;
            Borrado = false;
        }

        public int Codigo
        {
            get { return _codigo; }
        }
        public string Apellido
        {
            get { return _apellido; }
            set
            {
                if (value.Length > 15)
                    value = value.Substring(0, 15);
                _apellido = value;
            }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public float Sueldo
        {
            get { return _sueldo; }
            set { _sueldo = value; }
        }
        public DateTime FechaNac
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }
        public bool Borrado
        {
            get { return _borrado; }
            set { _borrado = value; }
        }
        // ETC

        public override string ToString()
        {
            return Codigo.ToString("000").PadRight(10)+ _apellido.PadRight(30) + _nombre.PadRight(20) + _sueldo.ToString().PadRight(10) + _fechaNacimiento.ToShortDateString().PadRight(10);
        }
    }
}
