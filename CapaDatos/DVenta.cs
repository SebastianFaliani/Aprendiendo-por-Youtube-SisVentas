using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using CapaDatos;


namespace CapaDatos
{
    public class DVenta
    {
        private int _idventa;
        private int _idcliente;
        private int _idtrabajador;
        private DateTime _fecha;
        private string _tipo_comprobante;
        private string _serie;
        private string _correlativo;
        private decimal _igv;

        public int Idventa { get => _idventa; set => _idventa = value; }
        public int Idcliente { get => _idcliente; set => _idcliente = value; }
        public int Idtrabajador { get => _idtrabajador; set => _idtrabajador = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public string Tipo_comprobante { get => _tipo_comprobante; set => _tipo_comprobante = value; }
        public string Serie { get => _serie; set => _serie = value; }
        public string Correlativo { get => _correlativo; set => _correlativo = value; }
        public decimal Igv { get => _igv; set => _igv = value; }

        public DVenta()
        {

        }

        public DVenta(int idventa, int idcliente, int idtrabajador ,DateTime fecha, string tipo_comprobante, string serie, string correlativo, decimal igv)
        {
            this.Idventa = idventa;
            this.Idcliente = idcliente;
            this.Idtrabajador = idtrabajador;
            this.Fecha = fecha;
            this.Tipo_comprobante = tipo_comprobante;
            this.Serie = serie;
            this.Correlativo = correlativo;
            this.Igv = igv;

        }

        public string DisminuirStock(int iddetalle_ingreso, int cantidad)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                // Establece el commando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spdisminuir_stock";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Pariddetalle_ingreso = new SqlParameter();
                Pariddetalle_ingreso.ParameterName = "@iddetalle_ingreso";
                Pariddetalle_ingreso.SqlDbType = SqlDbType.Int;
                Pariddetalle_ingreso.Value = iddetalle_ingreso;
                SqlCmd.Parameters.Add(Pariddetalle_ingreso);

                SqlParameter Parcantidad = new SqlParameter();
                Parcantidad.ParameterName = "@cantidad";
                Parcantidad.SqlDbType = SqlDbType.Int;
                Parcantidad.Value = cantidad;
                SqlCmd.Parameters.Add(Parcantidad);

                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Actualizo el Stock";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return rpta;
        }

        //Metodo Insertar
        public string Insertar(DVenta Venta, List<DDetalle_Venta> Detalle)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                //Establece la transaccion
                SqlTransaction SqlTra = SqlCon.BeginTransaction();

                // Establece el commando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Paridventa = new SqlParameter();
                Paridventa.ParameterName = "@idventa";
                Paridventa.SqlDbType = SqlDbType.Int;
                Paridventa.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(Paridventa);

                SqlParameter Paridcliente = new SqlParameter();
                Paridcliente.ParameterName = "@idcliente";
                Paridcliente.SqlDbType = SqlDbType.Int;
                Paridcliente.Value = Venta.Idcliente;
                SqlCmd.Parameters.Add(Paridcliente);

                SqlParameter Paridtrabajador = new SqlParameter();
                Paridtrabajador.ParameterName = "@idtrabajador";
                Paridtrabajador.SqlDbType = SqlDbType.Int;
                Paridtrabajador.Value = Venta.Idtrabajador;
                SqlCmd.Parameters.Add(Paridtrabajador);

                SqlParameter Parfecha = new SqlParameter();
                Parfecha.ParameterName = "@fecha";
                Parfecha.SqlDbType = SqlDbType.DateTime;
                Parfecha.Value = Venta.Fecha;
                SqlCmd.Parameters.Add(Parfecha);

                SqlParameter Partipo_comprobante = new SqlParameter();
                Partipo_comprobante.ParameterName = "@tipo_comprobante";
                Partipo_comprobante.SqlDbType = SqlDbType.VarChar;
                Partipo_comprobante.Size = 20;
                Partipo_comprobante.Value = Venta.Tipo_comprobante;
                SqlCmd.Parameters.Add(Partipo_comprobante);

                SqlParameter Parserie = new SqlParameter();
                Parserie.ParameterName = "@serie";
                Parserie.SqlDbType = SqlDbType.VarChar;
                Parserie.Size = 4;
                Parserie.Value = Venta.Serie;
                SqlCmd.Parameters.Add(Parserie);

                SqlParameter Parcorrelativo = new SqlParameter();
                Parcorrelativo.ParameterName = "@correlativo";
                Parcorrelativo.SqlDbType = SqlDbType.VarChar;
                Parcorrelativo.Size = 7;
                Parcorrelativo.Value = Venta.Correlativo;
                SqlCmd.Parameters.Add(Parcorrelativo);

                SqlParameter Parigv = new SqlParameter();
                Parigv.ParameterName = "@igv";
                Parigv.SqlDbType = SqlDbType.Decimal;
                Parigv.Precision = 4;
                Parigv.Scale = 2;
                Parigv.Value = Venta.Igv;
                SqlCmd.Parameters.Add(Parigv);

                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el Registro";

                if (rpta.Equals("OK"))
                {
                    //Obtener el codigo del ingreso generado
                    this.Idventa = Convert.ToInt32(SqlCmd.Parameters["@idventa"].Value);
                    foreach (DDetalle_Venta det in Detalle)
                    {
                        det.Idventa = this.Idventa;
                        //llamar al metodo insertar de la clase DDetalle_ingreso
                        rpta = det.Insertar(det, ref SqlCon, ref SqlTra);
                        if (!rpta.Equals("OK"))
                        {
                            break;
                        }
                        else
                        {
                            //Actualizamos el Stock
                            rpta = DisminuirStock(det.Iddetalle_ingreso, det.Cantidad);
                            if (!rpta.Equals("OK"))
                            {
                                break;
                            }
                        }
                    }
                }

                if (rpta.Equals("OK"))
                {
                    //Si esta todo bien envio la transaccion
                    SqlTra.Commit();
                }
                else
                {
                    //Si hay error niego la transaccion
                    SqlTra.Rollback();
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return rpta;
        }

        //Metodo Eliminar
        public string Eliminar(DVenta Venta)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                // Establece el commando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[speliminar_venta]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdventa = new SqlParameter();
                ParIdventa.ParameterName = "@idventa";
                ParIdventa.SqlDbType = SqlDbType.Int;
                ParIdventa.Value = Venta.Idventa;
                SqlCmd.Parameters.Add(ParIdventa);

                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "OK";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return rpta;
        }

        //Metodo Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("venta");
           

            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                //Establece la transaccion
                SqlTransaction SqlTra = SqlCon.BeginTransaction();

                // Establece el commando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "[spmostrar_venta]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        //Metodo BuscarFechas
        public DataTable BuscarFechas(string textobuscar, string textobuscar2)
        {
            DataTable DtResultado = new DataTable("venta");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_venta_fecha";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.DateTime;
                ParTextoBuscar.Value = textobuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlParameter ParTextoBuscar2 = new SqlParameter();
                ParTextoBuscar2.ParameterName = "@textobuscar2";
                ParTextoBuscar2.SqlDbType = SqlDbType.DateTime;
                ParTextoBuscar2.Value = textobuscar2;
                SqlCmd.Parameters.Add(ParTextoBuscar2);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }

        //Metodo Mostrar detalle
        public DataTable Mostrardetalle(int textobuscar)
        {
            DataTable DtResultado = new DataTable("detalle_venta");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostra_detalle_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.Int;
                ParTextoBuscar.Value = textobuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }

        //Mostrar Articulos por nombre
        public DataTable MostrarArticulo_Venta_Nombre(string textobuscar)
        {
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_buscararticulo_venta_nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = textobuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }

        //Mostrar Articulos por codigo
        public DataTable MostrarArticulo_Venta_Codigo(string textobuscar)
        {
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_buscararticulo_venta_codigo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = textobuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }
    }
}
