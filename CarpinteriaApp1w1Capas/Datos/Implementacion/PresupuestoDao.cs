using CarpinteriaApp.Datos.Interfaz;
using CarpinteriaApp.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpinteriaApp.Datos.Implementacion
{
    public class PresupuestoDao : IPresupuestoDao
    {
        public bool Actualizar(Presupuesto oPresupuesto)
        {
            throw new NotImplementedException();
        }

        public bool Borrar(int numero)
        {
            throw new NotImplementedException();
        }

 
        public Presupuesto ObtenerPresupuestoPorNro(int numero)
        {
            throw new NotImplementedException();
        }

        public List<Presupuesto> ObtenerPresupuestosPorFiltros(DateTime desde, DateTime hasta, string cliente)
        {
            throw new NotImplementedException();
        }
       public bool Crear(Presupuesto oPresupuesto)
        {
            bool resultado = true;
            SqlConnection conexion = HelperDao.ObtenerInstancia().ObtenerConexion();
            SqlTransaction t = null;
            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.Transaction = t;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_INSERTAR_MAESTRO";
                comando.Parameters.AddWithValue("@cliente", oPresupuesto.Cliente);
                comando.Parameters.AddWithValue("@dto", oPresupuesto.Descuento);
                comando.Parameters.AddWithValue("@total", oPresupuesto.CalcularTotal());

                SqlParameter parametro = new SqlParameter();
                parametro.ParameterName = "@presupuesto_nro";
                parametro.SqlDbType = SqlDbType.Int;
                parametro.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parametro);

                comando.ExecuteNonQuery();

                int presupuestoNro = (int)parametro.Value;
                int detalleNro = 1;
                SqlCommand cmdDetalle;

                foreach (DetallePresupuesto dp in oPresupuesto.Detalles)
                {
                    cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLE", conexion, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@presupuesto_nro", presupuestoNro);
                    cmdDetalle.Parameters.AddWithValue("@detalle", detalleNro);
                    cmdDetalle.Parameters.AddWithValue("@id_producto", dp.Producto.ProductoNro);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", dp.Cantidad);
                    cmdDetalle.ExecuteNonQuery();
                    detalleNro++;
                }
                t.Commit();
            }
            catch
            {
                if (t != null)
                    t.Rollback();
                resultado = false;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }

            return resultado;
        }

        public List<Producto> ObtenerProductos()
        {
            List<Producto> lProductos= new List<Producto>();
            DataTable tabla = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_PRODUCTOS");
            //mapear un registro de la tabla a un objeto del modelo de dominio
            foreach (DataRow fila in tabla.Rows)
            {
                int numero = int.Parse(fila["id_producto"].ToString());
                string nombre = fila["n_producto"].ToString();
                double precio = double.Parse(fila["precio"].ToString());
                bool activo = fila["activo"].ToString().Equals("S");
                Producto p = new Producto(numero, nombre, precio);
                p.Activo= activo;
                lProductos.Add(p);
            }
            return lProductos;
        }


        public int ObtenerProximoPresupuesto()
        {
            return HelperDao.ObtenerInstancia().ConsultarEscalar("SP_PROXIMO_ID", "@next");
        }
    }
}
