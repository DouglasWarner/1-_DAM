using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos_Bancos
{
    class Prestamo
    {
        private const double INTERES = 1.10;
        private const double CARGOEXTRA = 1.01;
        private double _cantidad;
        private int _meses;
        private bool _esRiesgo;

        public bool EsRiesgo
        {
            get { return _esRiesgo; }
            set { _esRiesgo = value; }
        }
        public int Meses
        {
            get { return _meses; }
            set
            {
                if (value < 25 && value > 0)
                    _meses = value;
                else
                    _meses = 0;
            }
        }
        public double Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public Prestamo()
        { }

        public Prestamo(double cantidad, int meses)
        {
            Cantidad = cantidad;
            Meses = meses;
            EsRiesgo = false;
        }

        public double CalcularCantidadMensual()
        {
            if (EsRiesgo)
            {
                return ((Cantidad * CARGOEXTRA) * INTERES) / Meses;
            }
            else
            {
                return (Cantidad * INTERES) / Meses;
            }
        }
    }
}
