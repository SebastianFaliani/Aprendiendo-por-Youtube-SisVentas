using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;
namespace CapaNegocio
{
    public class NTrabajador
    {
        //Método Insertar que llama al método Insertar de la clase DTrabajador de la CapaDatos
        public static string Insertar( string nombre, string apellido, string sexo, DateTime fecha_nacimiento, string num_documento,
            string direccion, string telefono, string email, string acceso, string usuario, string password)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Sexo = sexo;
            Obj.Fecha_nacimiento = fecha_nacimiento;
            Obj.Num_documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;

            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DTrabajador de la CapaDatos
        public static string Editar(int idtrabajador, string nombre, string apellido, string sexo, DateTime fecha_nacimiento, string num_documento,
            string direccion, string telefono, string email, string acceso, string usuario, string password)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Idtrabajador = idtrabajador;
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Sexo = sexo;
            Obj.Fecha_nacimiento = fecha_nacimiento;
            Obj.Num_documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;

            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DTrabajador de la CapaDatos
        public static string Eliminar(int idtrabajador)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Idtrabajador = idtrabajador;

            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DTrabajador de la CapaDatos
        public static DataTable Mostrar()
        {
            DTrabajador Obj = new DTrabajador();

            return Obj.Mostrar();
            //return new DCategoria().Mostrar();
        }

        //Método BuscarApellido que llama al método BuscarApellido de la clase DTrabajador de la CapaDatos
        public static DataTable BuscarApellido(string textobuscar)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Textobuscar = textobuscar;

            return Obj.BuscarApellido(Obj);
        }

        //Método BuscarTrabajadorDocumento que llama al método BuscarTrabajadorDocumento de la clase DTrabajador de la CapaDatos
        public static DataTable BuscarTrabajadorDocumento(string textobuscar)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Textobuscar = textobuscar;

            return Obj.BuscarTrabajadorDocumento(Obj);
        }

        //Método Login que llama al método Login de la clase DTrabajador de la CapaDatos
        public static DataTable Login(string usuario, string password)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Usuario = usuario;
            Obj.Password = password;

            return Obj.Login(Obj);
        }
    }
}
