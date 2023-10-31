using System;
using System.Collections.Generic;

namespace ProduccionLib.Entidades
{
    public class OrdenProduccion
    {
        public int Nro { get; set; }
        
        public DateTime Fecha { get; set; } 

        public List<DetalleOrden> ListaDetalles { get; set; }

        public string Modelo { get; set; }

        public string Estado { get; set; }

        public int Cantidad { get; set; }

        public OrdenProduccion(int nro, DateTime fecha, string modelo, string estado, int cantidad)
        {
            Nro = nro;
            Fecha = fecha;
            ListaDetalles = new List<DetalleOrden>();
            Modelo = modelo;
            Estado = estado;
            Cantidad = cantidad;
        }

        public OrdenProduccion()
        {
            Nro = 0;
            Fecha = DateTime.Now;
            Modelo = "";
            ListaDetalles = new List<DetalleOrden>();
            Cantidad = 0;
        }

        public void QuitarDetalle(int index)
        {
            ListaDetalles.RemoveAt(index);
        }

        public void AgregarDetalle(DetalleOrden detalle)
        {
            ListaDetalles.Add(detalle);
        }
    }
}
