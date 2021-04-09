using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalle_Venta
    {
        private int _iddetalle_venta;
        private int _idventa;
        private int _iddetalle_ingreso;
        private int _cantidad;
        private decimal _precio_venta;
        private decimal _descuento;

        public int Iddetalle_venta { get => _iddetalle_venta; set => _iddetalle_venta = value; }
        public int Idventa { get => _idventa; set => _idventa = value; }
        public int Iddetalle_ingreso { get => _iddetalle_ingreso; set => _iddetalle_ingreso = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
        public decimal Precio_venta { get => _precio_venta; set => _precio_venta = value; }
        public decimal Descuento { get => _descuento; set => _descuento = value; }

        public DDetalle_Venta()
        {

        }

        public DDetalle_Venta(int iddetalle_venta, int idventa, int iddetalle_ingreso, int cantidad, decimal precio_venta, decimal descuento)
        {
            this.Iddetalle_venta = iddetalle_venta;
            this.Idventa = idventa;
            this.Iddetalle_ingreso = iddetalle_ingreso;
            this.Cantidad = cantidad;
            this.Precio_venta = precio_venta;
            this.Descuento = descuento;
        }

        //Metodo insertar detalle venta
        public string Insertar(DDetalle_Venta dDetalle_Venta, ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string rpta = "";
            try
            {
                // Establece el commando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_detalle_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Pariddetalle_venta = new SqlParameter();
                Pariddetalle_venta.ParameterName = "@iddetalle_venta";
                Pariddetalle_venta.SqlDbType = SqlDbType.Int;
                Pariddetalle_venta.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(Pariddetalle_venta);

                SqlParameter Paridventa = new SqlParameter();
                Paridventa.ParameterName = "@idventa";
                Paridventa.SqlDbType = SqlDbType.Int;
                Paridventa.Value = dDetalle_Venta.Idventa;
                SqlCmd.Parameters.Add(Paridventa);

                SqlParameter Pariddetalle_ingreso = new SqlParameter();
                Pariddetalle_ingreso.ParameterName = "@iddetalle_ingreso";
                Pariddetalle_ingreso.SqlDbType = SqlDbType.Int;
                Pariddetalle_ingreso.Value = dDetalle_Venta.Iddetalle_ingreso;
                SqlCmd.Parameters.Add(Pariddetalle_ingreso);

                SqlParameter Parcantidad = new SqlParameter();
                Parcantidad.ParameterName = "@cantidad";
                Parcantidad.SqlDbType = SqlDbType.Int;
                Parcantidad.Value = dDetalle_Venta.Cantidad;
                SqlCmd.Parameters.Add(Parcantidad);

                SqlParameter ParPrecio_venta = new SqlParameter();
                ParPrecio_venta.ParameterName = "@precio_venta";
                ParPrecio_venta.SqlDbType = SqlDbType.Money;
                ParPrecio_venta.Value = dDetalle_Venta.Precio_venta;
                SqlCmd.Parameters.Add(ParPrecio_venta);

                SqlParameter Pardescuento = new SqlParameter();
                Pardescuento.ParameterName = "@descuento";
                Pardescuento.SqlDbType = SqlDbType.Money;
                Pardescuento.Value = dDetalle_Venta.Descuento;
                SqlCmd.Parameters.Add(Pardescuento);


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

