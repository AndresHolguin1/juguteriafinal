using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class UsuariosPresentacion : IUsuariosPresentacion
    {
        private Comunicaciones? comunicaciones = null;
      
        public async Task<List<Usuarios>> Listar()
        {
            var lista = new List<Usuarios>();
            var datos = new Dictionary<string, object>();

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Usuarios/Listar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }

            lista = JsonConversor.ConvertirAObjeto<List<Usuarios>>(JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        /// <summary>
        /// Obtiene una lista de usuarios filtrados por dirección.
        /// </summary>
        /// <param name="entidad">La entidad Usuarios que contiene la dirección a buscar.</param>
        /// <returns>Una tarea que representa la operación asíncrona. El resultado es una lista de Usuarios.</returns>
        /// <exception cref="Exception">Lanza una excepción si el servicio de comunicaciones devuelve un error.</exception>
        public async Task<List<Usuarios>> PorCorreo(Usuarios? entidad)
        {
            var lista = new List<Usuarios>();
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Usuarios/PorCorreo");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }

            lista = JsonConversor.ConvertirAObjeto<List<Usuarios>>(JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }
       

        /// <summary>
        /// Guarda un nuevo usuario.
        /// </summary>
        /// <param name="entidad">El objeto Usuarios a guardar. El Id debe ser 0 para un nuevo registro.</param>
        /// <returns>Una tarea que representa la operación asíncrona. El resultado es el Usuario guardado con su nuevo Id.</returns>
        /// <exception cref="Exception">Lanza una excepción si el Id de la entidad no es 0 o si el servicio de comunicaciones devuelve un error.</exception>
        public async Task<Usuarios?> Guardar(Usuarios? entidad)
        {
            if (entidad!.Id != 0)
            {
                throw new Exception("lbFaltaInformacion");
            }

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Usuarios/Guardar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }

            entidad = JsonConversor.ConvertirAObjeto<Usuarios>(JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        /// <summary>
        /// Modifica un usuario existente.
        /// </summary>
        /// <param name="entidad">El objeto Usuarios a modificar. El Id debe ser distinto de 0.</param>
        /// <returns>Una tarea que representa la operación asíncrona. El resultado es el Usuario modificado.</returns>
        /// <exception cref="Exception">Lanza una excepción si el Id de la entidad es 0 o si el servicio de comunicaciones devuelve un error.</exception>
        public async Task<Usuarios?> Modificar(Usuarios? entidad)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Usuarios/Modificar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }

            entidad = JsonConversor.ConvertirAObjeto<Usuarios>(JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        /// <summary>
        /// Borra un usuario.
        /// </summary>
        /// <param name="entidad">El objeto Usuarios a borrar. El Id debe ser distinto de 0.</param>
        /// <returns>Una tarea que representa la operación asíncrona. El resultado es el Usuario borrado (o una confirmación).</returns>
        /// <exception cref="Exception">Lanza una excepción si el Id de la entidad es 0 o si el servicio de comunicaciones devuelve un error.</exception>
        public async Task<Usuarios?> Borrar(Usuarios? entidad)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Usuarios/Borrar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }

            entidad = JsonConversor.ConvertirAObjeto<Usuarios>(JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
    }

}
