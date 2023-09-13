using PilasColas.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilasColas.implementaciones
{
    public class Pila : Lista
    {
  
        public override object Extraer()
        {
            object e = null;

            if (!EstaVacia())
            {
                int ultimo = elementos.Count - 1;
                e = elementos[ultimo];
                elementos.RemoveAt(ultimo);
            }
            return e;
        }

    }
}
