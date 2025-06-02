using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_presentaciones.Implementaciones
{
    public class PedidosPresentacion : IPedidosPresentacion
    {
        private Comunicaciones? comunicaciones = null;

        /// <summary>
        /// Obtiene una lista de todos los pedidos.
        /// </summary>
        /// <returns>Una tarea que representa la operación asíncrona. El resultado de la tarea es una lista de Pedidos.</returns>
        /// <exception cref="Exception">Lanza una excepción si el servicio de comunicaciones devuelve un error.</exception>
        public async Task<List<Pedidos>> Listar()
        {
            var lista = new List<Pedidos>();
            var datos = new Dictionary<string, object>();

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Pedidos/Listar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }

            lista = JsonConversor.ConvertirAObjeto<List<Pedidos>>(JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        /// <summary>
        /// Obtiene una lista de pedidos filtrados por fecha.
        /// </summary>
        /// <param name="entidad">La entidad Pedidos que contiene la fecha a buscar.</param>
        /// <returns>Una tarea que representa la operación asíncrona. El resultado es una lista de Pedidos.</returns>
        /// <exception cref="Exception">Lanza una excepción si el servicio de comunicaciones devuelve un error.</exception>
        public async Task<List<Pedidos>> PorFecha(Pedidos? entidad)
        {
            var lista = new List<Pedidos>();
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Pedidos/PorFecha");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }

            lista = JsonConversor.ConvertirAObjeto<List<Pedidos>>(JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        /// <summary>
        /// Guarda un nuevo pedido.
        /// </summary>
        /// <param name="entidad">El objeto Pedidos a guardar. El Id debe ser 0 para un nuevo registro.</param>
        /// <returns>Una tarea que representa la operación asíncrona. El resultado es el Pedido guardado con su nuevo Id.</returns>
        /// <exception cref="Exception">Lanza una excepción si el Id de la entidad no es 0 o si el servicio de comunicaciones devuelve un error.</exception>
        public async Task<Pedidos?> Guardar(Pedidos? entidad)
        {
            if (entidad!.Id != 0)
            {
                throw new Exception("lbFaltaInformacion");
            }

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Pedidos/Guardar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }

            entidad = JsonConversor.ConvertirAObjeto<Pedidos>(JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        /// <summary>
        /// Modifica un pedido existente.
        /// </summary>
        /// <param name="entidad">El objeto Pedidos a modificar. El Id debe ser distinto de 0.</param>
        /// <returns>Una tarea que representa la operación asíncrona. El resultado es el Pedido modificado.</returns>
        /// <exception cref="Exception">Lanza una excepción si el Id de la entidad es 0 o si el servicio de comunicaciones devuelve un error.</exception>
        public async Task<Pedidos?> Modificar(Pedidos? entidad)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Pedidos/Modificar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }

            entidad = JsonConversor.ConvertirAObjeto<Pedidos>(JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        /// <summary>
        /// Borra un pedido.
        /// </summary>
        /// <param name="entidad">El objeto Pedidos a borrar. El Id debe ser distinto de 0.</param>
        /// <returns>Una tarea que representa la operación asíncrona. El resultado es el Pedido borrado (o una confirmación).</returns>
        /// <exception cref="Exception">Lanza una excepción si el Id de la entidad es 0 o si el servicio de comunicaciones devuelve un error.</exception>
        public async Task<Pedidos?> Borrar(Pedidos? entidad)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Pedidos/Borrar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }

            entidad = JsonConversor.ConvertirAObjeto<Pedidos>(JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
    }
}
