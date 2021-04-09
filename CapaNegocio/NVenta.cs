using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NVenta
    {
        //Método Insertar que llama al método Insertar de la clase DVenta de la CapaDatos
        public static string Insertar(int idcliente, int idtrabajador, DateTime fecha, string tipo_comprobante, string serie, string correlativo, 
            decimal igv, DataTable dtDetalles)
        {
            DVenta Obj = new DVenta();
            Obj.Idcliente = idcliente;
            Obj.Idtrabajador = idtrabajador;
            Obj.Fecha = fecha;
            Obj.Tipo_comprobante = tipo_comprobante;
            Obj.Serie = serie;
            Obj.Correlativo = correlativo;
            Obj.Igv = igv;
            
            List<DDetalle_Venta> detalles = new List<DDetalle_Venta>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                DDetalle_Venta detalle = new DDetalle_Venta();
                detalle.Iddetalle_ingreso = Convert.ToInt32(row["iddetalle_ingreso"].ToString());
                detalle.Cantidad = Convert.ToInt32(row["cantidad"].ToString());
                detalle.Precio_venta = Convert.ToDecimal(row["precio_venta"].ToString());
                detalle.Descuento = Convert.ToInt32(row["descuento"].ToString());
                detalles.Add(detalle);
            }

            return Obj.Insertar(Obj, detalles);
        }

        //Método Eliminar que llama al método Eliminar de la clase DVenta de la CapaDatos
        public static string Eliminar(int idventa)
        {
            DVenta Obj = new DVenta();
            Obj.Idventa = idventa;

            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DVenta de la CapaDatos
        public static DataTable Mostrar()
        {
            DVenta Obj = new DVenta();

            return Obj.Mostrar();
            //return new DCategoria().Mostrar();
        }

        //Método BuscarFechas que llama al método BuscarFechas de la clase DVenta de la CapaDatos
        public static DataTable BuscarFechas(string textobuscar, string textobuscar2)
        {
            DVenta Obj = new DVenta();
            return Obj.BuscarFechas(textobuscar, textobuscar2);
        }

        //Método MostrarDetalle que llama al método MostrarDetalle de la clase DVenta de la CapaDatos
        public static DataTable Mostrardetalle(int textobuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.Mostrardetalle(textobuscar);
        }

        //Método MostrarArticulo_Venta_Nombre que llama al método MostrarArticulo_Venta_Nombre de la clase DVenta de la CapaDatos
        public static DataTable MostrarArticulo_Venta_Nombre(string textobuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarArticulo_Venta_Nombre(textobuscar);
        }

        //Método MostrarArticulo_Venta_Codigo que llama al método MostrarArticulo_Venta_Codigo de la clase DVenta de la CapaDatos
        public static DataTable MostrarArticulo_Venta_Codigo(string textobuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarArticulo_Venta_Codigo(textobuscar);
        }
    }
}
