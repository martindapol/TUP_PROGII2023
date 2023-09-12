using PilasColas.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilasColas.implementaciones
{
    public class Pila : IColeccion
    {
        private List<object> elementos;

        public Pila()
        {
            elementos = new List<object>();
        }
        public bool Agregar(object obj)
        {
            elementos.Insert(0, obj);
            return true;
        }

        public bool EstaVacia()
        {
            return elementos.Count == 0;
        }

        public object Extraer()
        {
            object e = null;

            if (!EstaVacia())
            {
                e = elementos[0];
                elementos.RemoveAt(0);
            }
            return e;
        }

        public object Primero()
        {
            object e = null;
            if (!EstaVacia())
                e = elementos[0];
            return e;
        }

    }
}
