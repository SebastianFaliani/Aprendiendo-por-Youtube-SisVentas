using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NIngreso
    {
        //Método Insertar que llama al método Insertar de la clase DIngreso de la CapaDatos
        public static string Insertar(int idtrabajador, int idproveedor, DateTime fecha, string tipo_comprobante, string serie, string correlativo, decimal igv,
            string estado,DataTable dtDetalles)
        {
            DIngreso Obj = new DIngreso();
            Obj.Idtrabajador = idtrabajador;
            Obj.Idproveedor = idproveedor;
            Obj.Fecha = fecha;
            Obj.Tipo_comprobante = tipo_comprobante;
            Obj.Serie = serie;
            Obj.Correlativo = correlativo;
            Obj.Igv = igv;
            Obj.Estado = estado;
                     List<DDetalle_Ingreso> detalles = new List<DDetalle_Ingreso>();
                      foreach(DataRow row in dtDetalles.Rows)
                      {
                          DDetalle_Ingreso detalle = new DDetalle_Ingreso();
                          detalle.Idarticulo = Convert.ToInt32(row["idarticulo"].ToString());
                          detalle.Precio_compra = Convert.ToDecimal(row["PrecioCompra"].ToString());
                          detalle.Precio_venta = Convert.ToDecimal(row["PrecioVenta"].ToString());
                          detalle.Stock_inicial = Convert.ToInt32(row["StockInicial"].ToString());
                          detalle.Stock_actual = Convert.ToInt32(row["StockInicial"].ToString());
                          detalle.Fecha_produccion = Convert.ToDateTime(row["FechaProduccion"].ToString());
                          detalle.Fecha_vencimiento = Convert.ToDateTime(row["FechaVencimiento"].ToString());
                          detalles.Add(detalle);
                      }

            return Obj.Insertar(Obj,detalles);
        }

        //Método Anular que llama al método Anular de la clase DIngreso de la CapaDatos
        public static string Anular(int idingreso)
        {
            DIngreso Obj = new DIngreso();
            Obj.Idingreso = idingreso;

            return Obj.Anular(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DIngreso de la CapaDatos
        public static DataTable Mostrar()
        {
            DIngreso Obj = new DIngreso();

            return Obj.Mostrar();
            //return new DCategoria().Mostrar();
        }

        //Método BuscarFechas que llama al método BuscarFechas de la clase DIngreso de la CapaDatos
        public static DataTable BuscarFechas(string textobuscar, string textobuscar2)
        {
            DIngreso Obj = new DIngreso();
            return Obj.BuscarFechas(textobuscar,textobuscar2);
        }

        //Método MostrarDetalle que llama al método MostrarDetalle de la clase DIngreso de la CapaDatos
        public static DataTable Mostrardetalle(int textobuscar)
        {
            DIngreso Obj = new DIngreso();
            return Obj.Mostrardetalle(textobuscar);
        }
    }
   
}
