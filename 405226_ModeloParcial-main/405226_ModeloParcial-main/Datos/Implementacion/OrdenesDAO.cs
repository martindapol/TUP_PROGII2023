using ModeloParcial.Datos.Interfaz;
using ModeloParcial.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ModeloParcial.Datos.Implementacion
{
    internal class OrdenesDAO : IOrdenesDAO
    {
        public bool ActualizarOrden(OrdenRetiro ordenRetiro)
        {
            bool aux = true;
            //Creamos la transaccion como nula
            SqlTransaction transaccion = null;
            SqlConnection conexion = HelperDAO.ObtenerInstancia().ObtenerConexion();
            try
            {
                conexion.Open();
                //Abro la conexion y despues abro la transaccion bajo esa conexion!
                transaccion = conexion.BeginTransaction();
                //Al crear el comando le pasamos x parametro: el string del comando, la conexion y la transaccion
                SqlCommand comando2 = new SqlCommand("SP_BORRAR_DETALLES", conexion, transaccion);
                SqlCommand comando = new SqlCommand("SP_ACTUALIZAR_ORDEN", conexion, transaccion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_orden", ordenRetiro.nroOrden);
                comando.Parameters.AddWithValue("@fecha_orden", ordenRetiro.fechaOrden);
                comando.Parameters.AddWithValue("@responsable", ordenRetiro.responsableOrden);
                comando.ExecuteNonQuery();
                comando2.CommandType = CommandType.StoredProcedure;
                comando2.Parameters.AddWithValue("@id_orden", ordenRetiro.nroOrden);
                comando2.ExecuteNonQuery();
                int i = 1;
                foreach (DetalleOrden d in ordenRetiro.listaDetalles)
                {
                    SqlCommand comandoCarga = new SqlCommand("SP_INSERTAR_DETALLE", conexion, transaccion);
                    comandoCarga.CommandType = CommandType.StoredProcedure;
                    comandoCarga.Parameters.AddWithValue("@id_detalle", i);
                    comandoCarga.Parameters.AddWithValue("@id_orden", ordenRetiro.nroOrden);
                    comandoCarga.Parameters.AddWithValue("@material",d.materialDetalle.codigoMaterial);
                    comandoCarga.Parameters.AddWithValue("@cantidad", d.cantidadDetalle);
                    comandoCarga.ExecuteNonQuery();
                    i++;
                }
                transaccion.Commit();
            }
            catch
            {
                if (transaccion != null)
                {
                    transaccion.Rollback();
                    aux = false;
                }
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return aux;
        }

        public bool BorrarOrden(int nroOrden)
        {
            bool aux = true;
            SqlConnection conexion = HelperDAO.ObtenerInstancia().ObtenerConexion();
            SqlTransaction transaccion = null;
            try
            {
                conexion.Open();
                transaccion = conexion.BeginTransaction();
                SqlCommand comando = new SqlCommand("SP_BORRAR_ORDEN", conexion, transaccion);
                comando.CommandType = CommandType.StoredProcedure;
                Parametro param = new Parametro("@id_orden", nroOrden);
                comando.Parameters.AddWithValue(param.Nombre, param.Valor);
                comando.ExecuteNonQuery();
                transaccion.Commit();
            }
            catch
            {
                if (transaccion != null)
                {
                    transaccion.Rollback();
                    aux = false;
                }
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            return aux;
        }

        public bool ConfirmarOrden(OrdenRetiro ordenRetiro)
        {
            bool aux = true;
            //Creamos la transaccion como nula
            SqlTransaction transaccion = null;
            SqlConnection conexion = HelperDAO.ObtenerInstancia().ObtenerConexion();
            try
            {
                conexion.Open();
                //Abro la conexion y despues abro la transaccion bajo esa conexion!
                transaccion = conexion.BeginTransaction();
                //Al crear el comando le pasamos x parametro: el string del comando, la conexion y la transaccion
                SqlCommand comando = new SqlCommand("SP_INSERTAR_ORDEN", conexion, transaccion);
                comando.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@prox_orden", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                comando.Parameters.Add(param);
                comando.Parameters.AddWithValue("@fecha_orden", ordenRetiro.fechaOrden);
                comando.Parameters.AddWithValue("@responsable", ordenRetiro.responsableOrden);
                comando.ExecuteNonQuery();

                int nroOrden = (int)param.Value;
                int i = 1;
                foreach (DetalleOrden d in ordenRetiro.listaDetalles)
                {
                    SqlCommand comandoCarga = new SqlCommand("SP_INSERTAR_DETALLE", conexion, transaccion);
                    comandoCarga.CommandType = CommandType.StoredProcedure;
                    comandoCarga.Parameters.AddWithValue("@id_detalle", i);
                    comandoCarga.Parameters.AddWithValue("@id_orden", nroOrden);
                    comandoCarga.Parameters.AddWithValue("@material", d.materialDetalle.codigoMaterial);
                    comandoCarga.Parameters.AddWithValue("@cantidad", d.cantidadDetalle);
                    comandoCarga.ExecuteNonQuery();
                    i++;
                }
                transaccion.Commit();
            }
            catch
            {
                if (transaccion != null)
                {
                    transaccion.Rollback();
                    aux = false;
                }
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return aux;
        }

        public int ObtenerProximaOrden()
        {
            return HelperDAO.ObtenerInstancia().ObtenerEscalar("SP_PROXIMA_ORDEN", "@next");
        }

        public List<Material> TraerMateriales()
        {
            List<Material> lMaterial = new List<Material>();
            DataTable tabla = HelperDAO.ObtenerInstancia().Consultar("SP_CONSULTAR_MATERIALES");
            foreach (DataRow r in tabla.Rows)
            {
                int nro = int.Parse(r["id_material"].ToString());
                string nom = r["nom_material"].ToString();
                int stock = int.Parse(r["stock_material"].ToString());
                lMaterial.Add(new Material(nro, nom,stock));
            }
            return lMaterial;
        }

        public List<OrdenRetiro> TraerOrdenes(List<Parametro> lParams, string nombreSP)
        {
            DataTable tabla = HelperDAO.ObtenerInstancia().Consultar(nombreSP, lParams);
            List<OrdenRetiro> lOrdenes = new List<OrdenRetiro>();
            foreach (DataRow r in tabla.Rows)
            {
                int nro = int.Parse(r["id_orden"].ToString());
                string resp = r["responsable"].ToString();
                DateTime fecha = DateTime.Parse(r["fecha_orden"].ToString());
                lOrdenes.Add(new OrdenRetiro(nro,fecha,resp));
            }
            return lOrdenes;
        }

        public OrdenRetiro TraerOrdenNro(int nroOrden)
        {
            OrdenRetiro ordenRetiro = new OrdenRetiro();
            SqlConnection conexion = HelperDAO.ObtenerInstancia().ObtenerConexion();
            SqlCommand comando = new SqlCommand();
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_CONSULTAR_ORDEN";
            Parametro param = new Parametro("@id_orden", nroOrden);
            comando.Parameters.AddWithValue(param.Nombre, param.Valor);
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            conexion.Close();
            ordenRetiro.nroOrden = nroOrden;
            foreach (DataRow fila in tabla.Rows)
            {
                ordenRetiro.fechaOrden = DateTime.Parse(fila["fecha_orden"].ToString());
                ordenRetiro.responsableOrden = fila["responsable"].ToString();                
            }
            conexion.Open();
            SqlCommand comandoDetalles = new SqlCommand("SP_CONSULTAR_DETALLES_ORDEN", conexion);
            comandoDetalles.CommandType = CommandType.StoredProcedure;
            Parametro paramDetalles = new Parametro("@id_orden", ordenRetiro.nroOrden);
            comandoDetalles.Parameters.AddWithValue(paramDetalles.Nombre, paramDetalles.Valor);
            DataTable tablaDetalles = new DataTable();
            tablaDetalles.Load(comandoDetalles.ExecuteReader());
            conexion.Close();
            foreach (DataRow r in tablaDetalles.Rows)
            {
                DetalleOrden d = new DetalleOrden();
                d.idDetalle = Convert.ToInt32(r["id_detalle"].ToString());
                d.materialDetalle.codigoMaterial = Convert.ToInt32(r["material"].ToString());
                d.materialDetalle.nombreMaterial = r["nom_material"].ToString();
                d.cantidadDetalle = Convert.ToInt32(r["cantidad"].ToString());
                ordenRetiro.AgregarDetalle(d);
            }
            return ordenRetiro;
        }
    }
}
