using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NCliente
    {
        //Método Insertar que llama al método Insertar de la clase DCliente de la CapaDatos
        public static string Insertar(string nombre, string apellidos, string sexo, DateTime fecha_nacimiento, string tipo_documento,
            string num_documento, string direccion, string telefono, string email)
        {
            DCliente Obj = new DCliente();
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_nacimiento = fecha_nacimiento;
            Obj.Tipo_documento = tipo_documento;
            Obj.Num_documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            
            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DCliente de la CapaDatos
        public static string Editar(int idcliente, string nombre, string apellidos, string sexo, DateTime fecha_nacimiento, string tipo_documento,
            string num_documento, string direccion, string telefono, string email)
        {
            DCliente Obj = new DCliente();
            Obj.Idcliente = idcliente;
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_nacimiento = fecha_nacimiento;
            Obj.Tipo_documento = tipo_documento;
            Obj.Num_documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DCliente de la CapaDatos
        public static string Eliminar(int idcliente)
        {
            DCliente Obj = new DCliente();
            Obj.Idcliente = idcliente;

            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DCliente de la CapaDatos
        public static DataTable Mostrar()
        {
            DCliente Obj = new DCliente();

            return Obj.Mostrar();
            //return new DCategoria().Mostrar();
        }

        //Método BuscarApellido que llama al método BuscarApellido de la clase DCliente de la CapaDatos
        public static DataTable BuscarApellido(string textobuscar)
        {
            DCliente Obj = new DCliente();
            Obj.Textobuscar = textobuscar;

            return Obj.BuscarApellido(Obj);
        }

        //Método BuscarDocumento que llama al método BuscarDocumento de la clase DCliente de la CapaDatos
        public static DataTable BuscarClienteDocumento(string textobuscar)
        {
            DCliente Obj = new DCliente();
            Obj.Textobuscar = textobuscar;

            return Obj.BuscarClienteDocumento(Obj);
        }
    }
}
