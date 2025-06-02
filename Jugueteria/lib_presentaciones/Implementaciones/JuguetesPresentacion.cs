using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class JuguetesPresentacion : IJuguetesPresentacion
    {
        private Comunicaciones? comunicaciones = null;

        /// <summary>
        /// Obtiene una lista de todos los juguetes.
        /// </summary>
        /// <returns>Una tarea que representa la operación asíncrona. El resultado de la tarea es una lista de Juguetes.</returns>
        /// <exception cref="Exception">Lanza una excepción si el servicio de comunicaciones devuelve un error.</exception>
        public async Task<List<Juguetes>> Listar()
        {
            var lista = new List<Juguetes>();
            var datos = new Dictionary<string, object>();

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Juguetes/Listar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }

            lista = JsonConversor.ConvertirAObjeto<List<Juguetes>>(JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        /// <summary>
        /// Obtiene una lista de juguetes filtrados por descripción.
        /// </summary>
        /// <param name="entidad">La entidad Juguetes que contiene la descripción a buscar.</param>
        /// <returns>Una tarea que representa la operación asíncrona. El resultado es una lista de Juguetes.</returns>
        /// <exception cref="Exception">Lanza una excepción si el servicio de comunicaciones devuelve un error.</exception>
        public async Task<List<Juguetes>> PorDescripcion(Juguetes? entidad)
        {
            var lista = new List<Juguetes>();
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Juguetes/PorDescripcion");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }

            lista = JsonConversor.ConvertirAObjeto<List<Juguetes>>(JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        /// <summary>
        /// Guarda un nuevo juguete.
        /// </summary>
        /// <param name="entidad">El objeto Juguetes a guardar. El Id debe ser 0 para un nuevo registro.</param>
        /// <returns>Una tarea que representa la operación asíncrona. El resultado es el Juguete guardado con su nuevo Id.</returns>
        /// <exception cref="Exception">Lanza una excepción si el Id de la entidad no es 0 o si el servicio de comunicaciones devuelve un error.</exception>
        public async Task<Juguetes?> Guardar(Juguetes? entidad)
        {
            if (entidad!.Id != 0)
            {
                throw new Exception("lbFaltaInformacion");
            }

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Juguetes/Guardar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }

            entidad = JsonConversor.ConvertirAObjeto<Juguetes>(JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        /// <summary>
        /// Modifica un juguete existente.
        /// </summary>
        /// <param name="entidad">El objeto Juguetes a modificar. El Id debe ser distinto de 0.</param>
        /// <returns>Una tarea que representa la operación asíncrona. El resultado es el Juguete modificado.</returns>
        /// <exception cref="Exception">Lanza una excepción si el Id de la entidad es 0 o si el servicio de comunicaciones devuelve un error.</exception>
        public async Task<Juguetes?> Modificar(Juguetes? entidad)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Juguetes/Modificar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }

            entidad = JsonConversor.ConvertirAObjeto<Juguetes>(JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        /// <summary>
        /// Borra un juguete.
        /// </summary>
        /// <param name="entidad">El objeto Juguetes a borrar. El Id debe ser distinto de 0.</param>
        /// <returns>Una tarea que representa la operación asíncrona. El resultado es el Juguete borrado (o una confirmación).</returns>
        /// <exception cref="Exception">Lanza una excepción si el Id de la entidad es 0 o si el servicio de comunicaciones devuelve un error.</exception>
        public async Task<Juguetes?> Borrar(Juguetes? entidad)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Juguetes/Borrar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }

            entidad = JsonConversor.ConvertirAObjeto<Juguetes>(JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
    }
}
