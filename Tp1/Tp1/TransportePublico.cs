using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1
{
    /// <summary>
    /// Representa la generalizacion de los transportes publicos.
    /// </summary>
    public abstract class TransportePublico
    {
        private int _pasajeros;

        public int Pasajeros
        {
            get { return _pasajeros; }
            set 
            { 
                _pasajeros = value; 
            }
        }

        public string Avanzar()
        {
            return "Avanzo";
        }
        public string Retroceder()
        {
            return "Retrocedo";
        }
    }
}
