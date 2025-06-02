using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_aplicaciones.Implementaciones
{
    public class DetallesVentaAplicacion :IDetallesVentaAplicacion
    {
        private IConexion? IConexion = null;

        public DetallesVentaAplicacion(IConexion iConexion)
        {
            IConexion = iConexion;
        }

        public DetallesVenta? Borrar(DetallesVenta? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            this.IConexion!.DetallesVenta!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public DetallesVenta? Guardar(DetallesVenta? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Calculos

            this.IConexion!.DetallesVenta!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<DetallesVenta> Listar()
        {
            return this.IConexion!.DetallesVenta!
                 .Take(20)
                .Include(x => x._Id_Venta)
                .Include(x => x._Id_Juguete)
                .ToList();


        }

        public DetallesVenta? Modificar(DetallesVenta? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            var entry = this.IConexion!.Entry<DetallesVenta>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<DetallesVenta> PorCantidad(DetallesVenta? entidad)
        {
            return this.IConexion!.DetallesVenta!
    .Where(x => x.Cantidad == entidad!.Cantidad)
    .ToList();
        }
    }
}
