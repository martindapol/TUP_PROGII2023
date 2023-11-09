using CarpinteriaApp.datos.Interfaz;
using CarpinteriaApp.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpinteriaApp.datos.Implementacion
{
    public class PresupuestoDao : IDaoPresupuesto
    {
        public int ObtenerProximoNro()
        {
            string sp = "SP_PROXIMO_ID";
            return HelperDB.ObtenerInstancia().ConsultaEscalarSQL(sp, "@next");
        }

        public List<Producto> ObtenerProductos()
        {
            List<Producto> lst = new List<Producto>();

            string sp = "SP_CONSULTAR_PRODUCTOS";
            DataTable t = HelperDB.ObtenerInstancia().ConsultaSQL(sp, null);

            foreach (DataRow dr in t.Rows)
            {
                //Mapear un registro a un objeto del modelo de dominio
                int nro = int.Parse(dr["id_producto"].ToString());
                string nombre = dr["n_producto"].ToString();
                double precio = double.Parse(dr["precio"].ToString());
                bool activo = dr["activo"].ToString().Equals("S");

                Producto aux = new Producto(nro, nombre, precio);
                aux.Activo = activo;
                lst.Add(aux);

            }

            return lst;
        }

        public bool Crear(Presupuesto oPresupuesto)
        {
            bool ok = true;
            SqlConnection cnn = HelperDB.ObtenerInstancia().ObtenerConexion();
            SqlTransaction t = null;
            SqlCommand cmd = new SqlCommand();
            try
            {

                cnn.Open();
                t = cnn.BeginTransaction();
                cmd.Connection = cnn;
                cmd.Transaction = t;
                cmd.CommandText = "SP_INSERTAR_MAESTRO";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cliente", oPresupuesto.Cliente);
                cmd.Parameters.AddWithValue("@dto", oPresupuesto.Descuento);
                cmd.Parameters.AddWithValue("@total", oPresupuesto.CalcularTotalConDescuento());

                //parámetro de salida:
                SqlParameter pOut = new SqlParameter();
                pOut.ParameterName = "@presupuesto_nro";
                pOut.DbType = DbType.Int32;
                pOut.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pOut);
                cmd.ExecuteNonQuery();

                int presupuestoNro = (int)pOut.Value;

                SqlCommand cmdDetalle;
                int detalleNro = 1;
                foreach (DetallePresupuesto item in oPresupuesto.Detalles)
                {
                    cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLE", cnn, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@presupuesto_nro", presupuestoNro);
                    cmdDetalle.Parameters.AddWithValue("@detalle", detalleNro);
                    cmdDetalle.Parameters.AddWithValue("@id_producto", item.Producto.ProductoNro);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", item.Cantidad);
                    cmdDetalle.ExecuteNonQuery();

                    detalleNro++;
                }
                t.Commit();
            }

            catch (Exception)
            {
                if (t != null)
                    t.Rollback();
                ok = false;
            }

            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            return ok;
        }

        public bool Actualizar(Presupuesto oPresupuesto)
        {
            bool ok = true;
            SqlConnection cnn = HelperDB.ObtenerInstancia().ObtenerConexion();
            SqlTransaction t = null;
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                cmd.Connection = cnn;
                cmd.Transaction = t;
                cmd.CommandText = "SP_MODIFICAR_MAESTRO";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cliente", oPresupuesto.Cliente);
                cmd.Parameters.AddWithValue("@dto", oPresupuesto.Descuento);
                cmd.Parameters.AddWithValue("@total", oPresupuesto.CalcularTotalConDescuento());
                cmd.Parameters.AddWithValue("@presupuesto_nro", oPresupuesto.PresupuestoNro);
                cmd.ExecuteNonQuery();

                SqlCommand cmdDetalle;
                int detalleNro = 1;
                foreach (DetallePresupuesto item in oPresupuesto.Detalles)
                {
                    cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLE", cnn, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@presupuesto_nro", oPresupuesto.PresupuestoNro);
                    cmdDetalle.Parameters.AddWithValue("@detalle", detalleNro);
                    cmdDetalle.Parameters.AddWithValue("@id_producto", item.Producto.ProductoNro);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", item.Cantidad);
                    cmdDetalle.ExecuteNonQuery();

                    detalleNro++;
                }
                t.Commit();
            }

            catch (Exception)
            {
                if (t != null)
                    t.Rollback();
                ok = false;
            }

            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            return ok;
        }

        public bool Borrar(int nro)
        {
            string sp = "SP_ELIMINAR_PRESUPUESTO";
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@presupuesto_nro", nro));
            int afectadas = HelperDB.ObtenerInstancia().EjecutarSQL(sp, lst);
            return afectadas > 0;
        }

        public List<Presupuesto> ObtenerPresupuestosPorFiltros(DateTime desde, DateTime hasta, string cliente)
        {
            List<Presupuesto> presupestos = new List<Presupuesto>();
            string sp = "SP_CONSULTAR_PRESUPUESTOS";
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@fecha_desde", desde));
            lst.Add(new Parametro("@fecha_hasta", hasta));
            lst.Add(new Parametro("@cliente", cliente));
            DataTable dt = HelperDB.ObtenerInstancia().ConsultaSQL(sp, lst);

            foreach (DataRow row in dt.Rows)
            {
                Presupuesto presupuesto = new Presupuesto();
                presupuesto.Cliente = row["cliente"].ToString();
                presupuesto.PresupuestoNro = int.Parse(row["presupuesto_nro"].ToString());
                presupuesto.Fecha = DateTime.Parse(row["fecha"].ToString());
                presupuesto.Descuento = double.Parse(row["descuento"].ToString());
                presupestos.Add(presupuesto);
            }

            return presupestos;
        }

        public DataTable ObtenerReporte(DateTime desde, DateTime hasta)
        {
            string sp = "SP_REPORTE_PRODUCTOS";
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@fecha_desde", desde));
            lst.Add(new Parametro("@fecha_hasta", hasta));
            DataTable dt = HelperDB.ObtenerInstancia().ConsultaSQL(sp, lst);
            return dt;
        }

        public Presupuesto ObtenerPresupuestoPorNro(int nro)
        {
            Presupuesto presupuesto = new Presupuesto();
            string sp = "SP_CONSULTAR_DETALLES_PRESUPUESTO";
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@presupuesto_nro", nro));

            DataTable dt = HelperDB.ObtenerInstancia().ConsultaSQL(sp, lst);
            bool primero = true;

            foreach (DataRow fila in dt.Rows)
            {
                if (primero)
                {
                    presupuesto.Cliente = fila["cliente"].ToString();
                    presupuesto.Fecha = DateTime.Parse(fila["fecha"].ToString());
                    presupuesto.Descuento = Double.Parse(fila["descuento"].ToString());
                    primero = false;
                }
                int nroProducto = int.Parse(fila["id_producto"].ToString());
                string nombre = fila["n_producto"].ToString();
                double precio = double.Parse(fila["precio"].ToString());
                Producto producto = new Producto(nroProducto, nombre, precio);
                int cantidad = int.Parse(fila["cantidad"].ToString());
                DetallePresupuesto detalle = new DetallePresupuesto(producto,cantidad);
                presupuesto.AgregarDetalle(detalle);
            
            }

            return presupuesto;
        }
    }
}

