using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace urt_presentaciones.Nucleo
{
    

   
   
        public class EntidadesNucleo
        {
            public static Juguetes? Juguetes()
            {
                var entidad = new Juguetes();
                //entidad.Id = 1;
                entidad.Nombre = "fire";
                entidad.Descripcion = "juguete de fuego";
                entidad.Stock = 10;
                entidad.Precio = 10.3m;
                entidad.estantes = 1;
                return entidad;
            }
            public static Estantes? estantes()
            {
                var entidad = new Estantes();
                //entidad.Id = 1;
                entidad.Ubicacion = "A1";
                entidad.Seccion = "A";
                return entidad;
            }
            public static Usuarios? Usuarios()
            {
                var entidad = new Usuarios();
                //entidad.Id = 1;
                entidad.Nombre = "Juan";
                entidad.Correo= "perez@.gmail.com";
                entidad.Direccion = "Calle 123";
                entidad.Clave = " 123";
                entidad.RolId = 1;


            return entidad;
            }
            public static Empleados? Empleados()
            {
                var entidad = new Empleados();
                //entidad.Id = 1;
                entidad.Nombre = "Andres";
                entidad.Correo = "Holguin@.gmail.com";
                entidad.Cargo = "Gerente";
                entidad.Telefono = "123456789";
                entidad.roles = 1; 

            return entidad;
            }
            public static Pedidos? Pedidos()
            {
                var entidad = new Pedidos();
                //entidad.Id = 1;
                entidad.Fecha = DateTime.Now;
                entidad.proveedores = 1;
                  entidad.empleados = 1;

                return entidad;
            }
            public static Ventas? Ventas()
            {
                var entidad = new Ventas();
                //entidad.Id = 1;
                entidad.Fecha = DateTime.Now;
                entidad.Total = 100.0m;
                entidad.usuarios = 1;
                entidad.empleados = 1;

                return entidad;
            }
            public static DetallesVenta? DetallesVenta()
            {
                var entidad = new DetallesVenta();
                //entidad.Id = 1;
                entidad.Cantidad = 2;
                entidad.Preciounitario = 10.0m;
                entidad.juguetes = 1;
                entidad.ventas = 1;

                return entidad;
            }
            public static Proveedores? Proovedores()
            {
                var entidad = new Proveedores();
                //entidad.Id = 1;
                entidad.Nombre = "Proveedor 1";
            entidad.Correo = "provedor@.gmail.com";
            entidad.Direccion = "Calle 456";
            entidad.Telefono = "123456789";
                return entidad;
            }
        public static Permisos? Permisos()
        {
            var entidad = new Permisos();
            //entidad.Id = 1;
            entidad.Nombre = "Permiso 1";
           
            return entidad;
        }
        public static Roles? Roles()
        {
            var entidad = new Roles();
            //entidad.Id = 1;
            entidad.Nombre = "Rol 1";

            return entidad;
        }
    }
    }

