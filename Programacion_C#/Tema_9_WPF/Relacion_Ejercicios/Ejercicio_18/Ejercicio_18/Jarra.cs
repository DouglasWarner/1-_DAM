using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_18
{
	class Jarra
	{
		private int capacidad;
		private int contenido;

		public int Capacidad
		{
			get { return capacidad; }
			set {
				if (value < 0)
					capacidad = 1;
				else
					capacidad = value; }
		}
		public int Contenido
		{
			get { return contenido; }
			set { contenido = value; }
		}

		public Jarra() { }

		public Jarra(int capacidad)
		{
			Capacidad = capacidad;
		}

		public void Llenar()
		{
			Contenido = capacidad;
		}

		public void Vaciar()
		{
			Contenido = 0;
		}

		public void LlenarDesde(Jarra jarra)
		{
				++this.Contenido;
				jarra.Contenido--;
		}

		public override string ToString()
		{
			return string.Format("{0}/{1}",this.Contenido,this.Capacidad);
		}
	}
}
