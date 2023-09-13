using PilasColas.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilasColas.implementaciones
{
    public class Cola : Lista
    {
        public override object Extraer()
        {
            object e = null;

            if (!EstaVacia())
            {
                e = elementos[0];
                elementos.RemoveAt(0);
            }
            return e;
        }
    }
}
