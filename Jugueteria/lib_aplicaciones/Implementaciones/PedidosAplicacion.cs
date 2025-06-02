using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_aplicaciones.Implementaciones
{
    public class PedidosAplicacion : IPedidiosAplicacion
    {
        private IConexion? IConexion = null;

        public PedidosAplicacion(IConexion iConexion)
        {
            IConexion = iConexion;
        }

        public Pedidos? Borrar(Pedidos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            this.IConexion!.Pedidos!.Remove(entidad);
            this.IConexion.SaveChangesAsync();
            return entidad;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Pedidos? Guardar(Pedidos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Calculos

            this.IConexion!.Pedidos!.Add(entidad);
            this.IConexion.SaveChangesAsync();
            return entidad;
        }

        public List<Pedidos> Listar()
        {
            return this.IConexion!.Pedidos!
                .Take(20)
                .Include(x => x._Id_Empleado)
                .Include(x => x._Id_Proovedor)
                .ToList();
        }

        public Pedidos? Modificar(Pedidos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            var entry = this.IConexion!.Entry<Pedidos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChangesAsync();
            return entidad;
        }

        public List<Pedidos> PorFecha(Pedidos? entidad)
        {
            return this.IConexion!.Pedidos!
    .Where(x => x.Fecha == entidad!.Fecha)
    .ToList();
        }
    }
}
