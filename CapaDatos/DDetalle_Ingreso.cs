using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalle_Ingreso
    {
        private int _iddetalle_ingreso;
        private int _idingreso;
        private int _idarticulo;
        private decimal _precio_compra;
        private decimal _precio_venta;
        private int _stock_inicial;
        private int _stock_actual;
        private DateTime _fecha_produccion;
        private DateTime _fecha_vencimiento;

        public int Iddetalle_ingreso { get => _iddetalle_ingreso; set => _iddetalle_ingreso = value; }
        public int Idingreso { get => _idingreso; set => _idingreso = value; }
        public int Idarticulo { get => _idarticulo; set => _idarticulo = value; }
        public decimal Precio_compra { get => _precio_compra; set => _precio_compra = value; }
        public decimal Precio_venta { get => _precio_venta; set => _precio_venta = value; }
        public int Stock_inicial { get => _stock_inicial; set => _stock_inicial = value; }
        public int Stock_actual { get => _stock_actual; set => _stock_actual = value; }
        public DateTime Fecha_produccion { get => _fecha_produccion; set => _fecha_produccion = value; }
        public DateTime Fecha_vencimiento { get => _fecha_vencimiento; set => _fecha_vencimiento = value; }

        public DDetalle_Ingreso()
        {

        }

        public DDetalle_Ingreso(int iddetalle_ingreso, int idingreso, int idarticulo, decimal precio_compra, decimal precio_venta, int stock_inicial,
            int stock_actual, DateTime fecha_produccion, DateTime fecha_vencimiento)
        {
            Iddetalle_ingreso = iddetalle_ingreso;
            Idingreso = idingreso;
            Idarticulo = idarticulo;
            Precio_compra = precio_compra;
            Precio_venta = precio_venta;
            Stock_inicial = stock_inicial;
            Stock_actual = stock_actual;
            Fecha_produccion = fecha_produccion;
            Fecha_vencimiento = fecha_vencimiento;
        }

        //Metodo Insertar
        public string Insertar(DDetalle_Ingreso Detalle_Ingreso, ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string rpta = "";
            try
            {
                // Establece el commando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_detalle_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddetalle_ingreso = new SqlParameter();
                ParIddetalle_ingreso.ParameterName = "@iddetalle_ingreso";
                ParIddetalle_ingreso.SqlDbType = SqlDbType.Int;
                ParIddetalle_ingreso.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIddetalle_ingreso);

                SqlParameter ParIdingreso = new SqlParameter();
                ParIdingreso.ParameterName = "@idingreso";
                ParIdingreso.SqlDbType = SqlDbType.Int;
                ParIdingreso.Value = Detalle_Ingreso.Idingreso;
                SqlCmd.Parameters.Add(ParIdingreso);

                SqlParameter ParIdarticulo = new SqlParameter();
                ParIdarticulo.ParameterName = "@idarticulo";
                ParIdarticulo.SqlDbType = SqlDbType.Int;
                ParIdarticulo.Value = Detalle_Ingreso.Idarticulo;
                SqlCmd.Parameters.Add(ParIdarticulo);

                SqlParameter ParPrecio_compra = new SqlParameter();
                ParPrecio_compra.ParameterName = "@precio_compra";
                ParPrecio_compra.SqlDbType = SqlDbType.Money;
                ParPrecio_compra.Value = Detalle_Ingreso.Precio_compra;
                SqlCmd.Parameters.Add(ParPrecio_compra);

                SqlParameter ParPrecio_venta = new SqlParameter();
                ParPrecio_venta.ParameterName = "@precio_venta";
                ParPrecio_venta.SqlDbType = SqlDbType.Money;
                ParPrecio_venta.Value = Detalle_Ingreso.Precio_venta;
                SqlCmd.Parameters.Add(ParPrecio_venta);

                SqlParameter ParStock_inicial = new SqlParameter();
                ParStock_inicial.ParameterName = "@stock_inicial";
                ParStock_inicial.SqlDbType = SqlDbType.Int;
                ParStock_inicial.Value = Detalle_Ingreso.Stock_inicial;
                SqlCmd.Parameters.Add(ParStock_inicial);

                SqlParameter ParStock_actual = new SqlParameter();
                ParStock_actual.ParameterName = "@stock_actual";
                ParStock_actual.SqlDbType = SqlDbType.Int;
                ParStock_actual.Value = Detalle_Ingreso.Stock_actual;
                SqlCmd.Parameters.Add(ParStock_actual);

                SqlParameter ParFecha_produccion = new SqlParameter();
                ParFecha_produccion.ParameterName = "@fecha_produccion";
                ParFecha_produccion.SqlDbType = SqlDbType.DateTime;
                ParFecha_produccion.Value = Detalle_Ingreso.Fecha_produccion;
                SqlCmd.Parameters.Add(ParFecha_produccion);

                SqlParameter ParFecha_vencimiento = new SqlParameter();
                ParFecha_vencimiento.ParameterName = "@fecha_vencimiento";
                ParFecha_vencimiento.SqlDbType = SqlDbType.DateTime;
                ParFecha_vencimiento.Value = Detalle_Ingreso.Fecha_vencimiento;
                SqlCmd.Parameters.Add(ParFecha_vencimiento);


                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            return rpta;
        }

    }
}
