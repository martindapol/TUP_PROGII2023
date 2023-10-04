using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloParcial.Dominio
{
    public class Material
    {
        public int codigoMaterial { get; set; }
        public string nombreMaterial { get; set; }
        public int stockMaterial { get; set; }

        public Material()
        {
            codigoMaterial = 0;
            nombreMaterial = string.Empty;
            stockMaterial = 0;
        }

        public Material(int cod, string nom, int stock)
        {
            codigoMaterial = cod;
            nombreMaterial = nom;
            stockMaterial = stock;
        }

        public override string ToString()
        {
            return nombreMaterial;
        }
    }
}
