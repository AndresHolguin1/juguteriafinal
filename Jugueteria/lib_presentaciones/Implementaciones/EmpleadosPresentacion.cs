using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_presentaciones.Implementaciones
{
    public class EmpleadosPresentacion : IEmpleadosPresentacion
    {
        private Comunicaciones? comunicaciones = null;

        /// <summary>
        /// Obtiene una lista de todos los empleados.
        /// </summary>
        /// <returns>Una tarea que representa la operación asíncrona. El resultado de la tarea es una lista de Empleados.</returns>
        /// <exception cref="Exception">Lanza una excepción si el servicio de comunicaciones devuelve un error.</exception>
        public async Task<List<Empleados>> Listar()
        {
            var lista = new List<Empleados>();
            var datos = new Dictionary<string, object>();

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Empleados/Listar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }

            lista = JsonConversor.ConvertirAObjeto<List<Empleados>>(JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        /// <summary>
        /// Obtiene una lista de empleados filtrados por cargo.
        /// </summary>
        /// <param name="entidad">La entidad Empleados que contiene el cargo a buscar.</param>
        /// <returns>Una tarea que representa la operación asíncrona. El resultado es una lista de Empleados.</returns>
        /// <exception cref="Exception">Lanza una excepción si el servicio de comunicaciones devuelve un error.</exception>
        public async Task<List<Empleados>> PorCargo(Empleados? entidad)
        {
            var lista = new List<Empleados>();
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Empleado/PorCargo"); // Verifica si el endpoint debe ser "Empleados/PorCargo"
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }

            lista = JsonConversor.ConvertirAObjeto<List<Empleados>>(JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        /// <summary>
        /// Guarda un nuevo empleado.
        /// </summary>
        /// <param name="entidad">El objeto Empleados a guardar. El Id debe ser 0 para un nuevo registro.</param>
        /// <returns>Una tarea que representa la operación asíncrona. El resultado es el Empleado guardado con su nuevo Id.</returns>
        /// <exception cref="Exception">Lanza una excepción si el Id de la entidad no es 0 o si el servicio de comunicaciones devuelve un error.</exception>
        public async Task<Empleados?> Guardar(Empleados? entidad)
        {
            if (entidad!.Id != 0)
            {
                throw new Exception("lbFaltaInformacion");
            }

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Empleados/Guardar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }

            entidad = JsonConversor.ConvertirAObjeto<Empleados>(JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        /// <summary>
        /// Modifica un empleado existente.
        /// </summary>
        /// <param name="entidad">El objeto Empleados a modificar. El Id debe ser distinto de 0.</param>
        /// <returns>Una tarea que representa la operación asíncrona. El resultado es el Empleado modificado.</returns>
        /// <exception cref="Exception">Lanza una excepción si el Id de la entidad es 0 o si el servicio de comunicaciones devuelve un error.</exception>
        public async Task<Empleados?> Modificar(Empleados? entidad)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Empleados/Modificar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }

            entidad = JsonConversor.ConvertirAObjeto<Empleados>(JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        /// <summary>
        /// Borra un empleado.
        /// </summary>
        /// <param name="entidad">El objeto Empleados a borrar. El Id debe ser distinto de 0.</param>
        /// <returns>Una tarea que representa la operación asíncrona. El resultado es el Empleado borrado (o una confirmación).</returns>
        /// <exception cref="Exception">Lanza una excepción si el Id de la entidad es 0 o si el servicio de comunicaciones devuelve un error.</exception>
        public async Task<Empleados?> Borrar(Empleados? entidad)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Empleados/Borrar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }

            entidad = JsonConversor.ConvertirAObjeto<Empleados>(JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
    }

}
