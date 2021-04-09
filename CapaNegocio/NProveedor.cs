using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NProveedor
    {
        //Método Insertar que llama al método Insertar de la clase DProveedor de la CapaDatos
        public static string Insertar(string razon_social, string sector_comercial, string tipo_documento,
            string num_documento, string direccion, string telefono, string email, string url)
        {
            DProveedor Obj = new DProveedor();
            Obj.Razon_social = razon_social;
            Obj.Sector_comercial = sector_comercial;
            Obj.Tipo_documento = tipo_documento;
            Obj.Num_documento = num_documento;
            Obj.Direccion= direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Url = url;

            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DProveedor de la CapaDatos
        public static string Editar(int idproveedor, string razon_social, string sector_comercial, string tipo_documento,
            string num_documento, string direccion, string telefono, string email, string url)
        {
            DProveedor Obj = new DProveedor();
            Obj.Idproveedor = idproveedor;
            Obj.Razon_social = razon_social;
            Obj.Sector_comercial = sector_comercial;
            Obj.Tipo_documento = tipo_documento;
            Obj.Num_documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Url = url;
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DProveedor de la CapaDatos
        public static string Eliminar(int idproveedor)
        {
            DProveedor Obj = new DProveedor();
            Obj.Idproveedor = idproveedor;

            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DProveedor de la CapaDatos
        public static DataTable Mostrar()
        {
            DProveedor Obj = new DProveedor();

            return Obj.Mostrar();
            //return new DCategoria().Mostrar();
        }

        //Método BuscarRazonSocial que llama al método BuscarRazonSocial de la clase DProveedor de la CapaDatos
        public static DataTable BuscarRazonSocial(string textobuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.Textobuscar = textobuscar;

            return Obj.BuscarRazonSocial(Obj);
        }

        //Método BuscarDocumento que llama al método BuscarDocumento de la clase DProveedor de la CapaDatos
        public static DataTable BuscarDocumento(string textobuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.Textobuscar = textobuscar;

            return Obj.BuscarDocumento(Obj);
        }
    }
}
