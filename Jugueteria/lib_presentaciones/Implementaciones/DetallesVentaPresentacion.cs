using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_presentaciones.Implementaciones
{
    public class DetallesVentaPresentacion : IDetallesVentaPresentacion
    {
        private Comunicaciones? comunicaciones = null;
        public async Task<List<DetallesVenta>> Listar()
        {
            var lista = new List<DetallesVenta>();
            var datos = new Dictionary<string, object>();
            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "DetallesVenta/Listar");
            var respuesta = await comunicaciones!.Ejecutar(datos);
            if (respuesta.ContainsKey("Error"))
            { throw new Exception(respuesta["Error"].ToString()!); }
            lista = JsonConversor.ConvertirAObjeto<List<DetallesVenta>>(JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }
        public async Task<List<DetallesVenta>> PorCantidad(DetallesVenta? entidad)
        {
            var lista = new List<DetallesVenta>();
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "DetallesVenta/PorCantidad"); var respuesta = await comunicaciones!.Ejecutar(datos);
            if (respuesta.ContainsKey("Error"))
            { throw new Exception(respuesta["Error"].ToString()!); }
            lista = JsonConversor.ConvertirAObjeto<List<DetallesVenta>>(JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }
        public async Task<DetallesVenta?> Guardar(DetallesVenta? entidad)
        {
            if (entidad!.Id != 0)
            { throw new Exception("lbFaltaInformacion"); }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;
            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "DetallesVenta/Guardar");
            var respuesta = await comunicaciones!.Ejecutar(datos);
            if (respuesta.ContainsKey("Error"))
            { throw new Exception(respuesta["Error"].ToString()!); }
            entidad = JsonConversor.ConvertirAObjeto<DetallesVenta>(JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
        public async Task<DetallesVenta?> Modificar(DetallesVenta? entidad)
        {
            if (entidad!.Id == 0)
            { throw new Exception("lbFaltaInformacion"); }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;
            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "DetallesVenta/Modificar");
            var respuesta = await comunicaciones!.Ejecutar(datos);
            if (respuesta.ContainsKey("Error"))
            { throw new Exception(respuesta["Error"].ToString()!); }
            entidad = JsonConversor.ConvertirAObjeto<DetallesVenta>(JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
        public async Task<DetallesVenta?> Borrar(DetallesVenta? entidad)
        {
            if (entidad!.Id == 0)
            { throw new Exception("lbFaltaInformacion"); }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;
            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "DetallesVenta/Borrar");
            var respuesta = await comunicaciones!.Ejecutar(datos);
            if (respuesta.ContainsKey("Error")) { throw new Exception(respuesta["Error"].ToString()!); }
            entidad = JsonConversor.ConvertirAObjeto<DetallesVenta>(JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
    }
