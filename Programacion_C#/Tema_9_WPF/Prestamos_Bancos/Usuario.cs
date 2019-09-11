using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos_Bancos
{
    class Usuario
    {
        private string _nombre = string.Empty;
        private string _contraseña = string.Empty;
        private bool _esRiesgo = false;

        public bool EsRiesgo
        {
            get { return _esRiesgo; }
            set { _esRiesgo = value; }
        }
        public string Contraseña
        {
            get { return _contraseña; }
            set {
                if (value.Length < 16)
                    _contraseña = value;
                else
                    _contraseña = value.Substring(0, 15);
            }
        }
        public string Nombre
        {
            get { return _nombre; }
            set {
                if (value.Length < 21)
                    _nombre = value;
                else
                    _nombre = value.Substring(0, 20);
            }
        }

        public Usuario() { }

        public Usuario(string nombre, string contraseña)
        {
            Nombre = nombre;
            Contraseña = contraseña;
            EsRiesgo = false;
        }
    }
}
