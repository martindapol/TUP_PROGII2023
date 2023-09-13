using PilasColas.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilasColas.implementaciones
{
    public abstract class Lista : IColeccion
    {
        protected List<object> elementos;

        public Lista()
        {
            elementos = new List<object>();
        }

        public bool Agregar(object obj)
        {
            elementos.Add(obj);
            return true;
        }

        public bool EstaVacia()
        {
            return elementos.Count == 0;
        }

        public object Primero()
        {
            object e = null;
            if (!EstaVacia())
                e = elementos[0];
            return e;
        }

       public abstract object Extraer();

    }
}
