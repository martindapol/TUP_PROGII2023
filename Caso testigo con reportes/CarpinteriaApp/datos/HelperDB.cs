using CarpinteriaApp.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CarpinteriaApp.datos
{
    class HelperDB
    {
        private static HelperDB instancia;
        private SqlConnection cnn;

        private HelperDB()
        {
            cnn = new SqlConnection(Properties.Resources.cnnString);
        }

        public static HelperDB ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new HelperDB();
            return instancia;
        }
        public DataTable ConsultaSQL(string spNombre, List<Parametro> values)
        {
            DataTable tabla = new DataTable();

            cnn.Open();
            SqlCommand cmd = new SqlCommand(spNombre, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (values != null)
            {
                foreach (Parametro oParametro in values)
                {
                    cmd.Parameters.AddWithValue(oParametro.Clave, oParametro.Valor);
                }
            }
            tabla.Load(cmd.ExecuteReader());
            cnn.Close();

            return tabla;
        }



        public int EjecutarSQL(string strSql, List<Parametro> values)
        {
            int afectadas = 0;
            SqlTransaction t = null;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                t = cnn.BeginTransaction();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = strSql;
                cmd.Transaction = t;

                if (values != null)
                {
                    foreach (Parametro param in values)
                    {
                        cmd.Parameters.AddWithValue(param.Clave, param.Valor);
                    }
                }

                afectadas = cmd.ExecuteNonQuery();
                t.Commit();
            }
            catch (SqlException)
            {
                if (t != null) { t.Rollback(); }
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();

            }

            return afectadas;
        }

        public int ProximoPresupuesto()
        {
            SqlCommand cmd = new SqlCommand();
            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandText = "SP_PROXIMO_ID";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter pOut = new SqlParameter();
            pOut.ParameterName = "@next";
            pOut.DbType = DbType.Int32;
            pOut.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(pOut);
            cmd.ExecuteNonQuery();

            cnn.Close();
            return (int)pOut.Value;

        }

        public bool ConfirmarPresupuesto(Presupuesto oPresupuesto)
        {
            bool ok = true;
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
        public bool ModificarPresupuesto(Presupuesto oPresupuesto)
        {
            bool ok = true;
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

    }
}