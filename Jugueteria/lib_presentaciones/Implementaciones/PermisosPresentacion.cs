using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class PermisosPresentacion : IPermisosPresentacion
    {
        private Comunicaciones? comunicaciones = null;

        /// <summary>
        /// Obtiene una lista de todos los permisos.
        /// </summary>
        /// <returns>Una tarea que representa la operación asíncrona. El resultado de la tarea es una lista de Permisos.</returns>
        /// <exception cref="Exception">Lanza una excepción si el servicio de comunicaciones devuelve un error.</exception>
        public async Task<List<Permisos>> Listar()
        {
            var lista = new List<Permisos>();
            var datos = new Dictionary<string, object>();

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Permisos/Listar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }

            lista = JsonConversor.ConvertirAObjeto<List<Permisos>>(JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        /// <summary>
        /// Obtiene una lista de permisos filtrados por nombre.
        /// </summary>
        /// <param name="entidad">La entidad Permisos que contiene el nombre a buscar.</param>
        /// <returns>Una tarea que representa la operación asíncrona. El resultado es una lista de Permisos.</returns>
        /// <exception cref="Exception">Lanza una excepción si el servicio de comunicaciones devuelve un error.</exception>
        public async Task<List<Permisos>> PorNombre(Permisos? entidad)
        {
            var lista = new List<Permisos>();
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Permisos/PorNombre");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }

            lista = JsonConversor.ConvertirAObjeto<List<Permisos>>(JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        /// <summary>
        /// Guarda un nuevo permiso.
        /// </summary>
        /// <param name="entidad">El objeto Permisos a guardar. El Id debe ser 0 para un nuevo registro.</param>
        /// <returns>Una tarea que representa la operación asíncrona. El resultado es el Permiso guardado con su nuevo Id.</returns>
        /// <exception cref="Exception">Lanza una excepción si el Id de la entidad no es 0 o si el servicio de comunicaciones devuelve un error.</exception>
        public async Task<Permisos?> Guardar(Permisos? entidad)
        {
            // Nota: la validación de Id != 0 estaba comentada en tu código original para Guardar.
            // Si necesitas que un nuevo permiso tenga Id == 0, puedes descomentarla.
            // if (entidad!.Id != 0) { throw new Exception("lbFaltaInformacion"); }

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Permisos/Guardar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }

            entidad = JsonConversor.ConvertirAObjeto<Permisos>(JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        /// <summary>
        /// Modifica un permiso existente.
        /// </summary>
        /// <param name="entidad">El objeto Permisos a modificar. El Id debe ser distinto de 0.</param>
        /// <returns>Una tarea que representa la operación asíncrona. El resultado es el Permiso modificado.</returns>
        /// <exception cref="Exception">Lanza una excepción si el Id de la entidad es 0 o si el servicio de comunicaciones devuelve un error.</exception>
        public async Task<Permisos?> Modificar(Permisos? entidad)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Permisos/Modificar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }

            entidad = JsonConversor.ConvertirAObjeto<Permisos>(JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        /// <summary>
        /// Borra un permiso.
        /// </summary>
        /// <param name="entidad">El objeto Permisos a borrar. El Id debe ser distinto de 0.</param>
        /// <returns>Una tarea que representa la operación asíncrona. El resultado es el Permiso borrado (o una confirmación).</returns>
        /// <exception cref="Exception">Lanza una excepción si el Id de la entidad es 0 o si el servicio de comunicaciones devuelve un error.</exception>
        public async Task<Permisos?> Borrar(Permisos? entidad)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Permisos/Borrar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }

            entidad = JsonConversor.ConvertirAObjeto<Permisos>(JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
    }

}
