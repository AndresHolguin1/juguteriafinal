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
    public class VentasAplicacion : IVentasAplicacion
    {
        private IConexion? IConexion = null;

        public VentasAplicacion(IConexion iConexion)
        {
            IConexion = iConexion;
        }

        public Ventas? Borrar(Ventas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            this.IConexion!.Ventas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Ventas? Guardar(Ventas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Calculos

            this.IConexion!.Ventas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Ventas> Listar()
        {
            return this.IConexion!.Ventas!.Take(20)
                .Include(x=>x._Id_usuario)
                .Include(x=> x._Id_Empleado)
                .ToList();
        }

        public Ventas? Modificar(Ventas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            var entry = this.IConexion!.Entry<Ventas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Ventas> PorFecha(Ventas? entidad)
        {
            return this.IConexion!.Ventas!
    .Where(x => x.Fecha == entidad!.Fecha)
    .ToList();
        }
    }
}
