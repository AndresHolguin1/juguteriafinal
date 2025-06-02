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
    public class EmpleadosAplicacion : IEmpleadosAplicacion
    {
        private IConexion? IConexion = null;

        public EmpleadosAplicacion(IConexion iConexion)
        {
            IConexion = iConexion;
        }

        public Empleados? Borrar(Empleados? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            this.IConexion!.Empleados!.Remove(entidad);
            this.IConexion.SaveChangesAsync();
            return entidad;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Empleados? Guardar(Empleados? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Calculos

            this.IConexion!.Empleados!.Add(entidad);
            this.IConexion.SaveChangesAsync();
            return entidad;
        }

        public List<Empleados> Listar()
        {
            return this.IConexion!.Empleados!.Take(20)
                 .Include(x => x._Id_Rol)
                .ToList();
        }

        public Empleados? Modificar(Empleados? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            var entry = this.IConexion!.Entry<Empleados>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChangesAsync();
            return entidad;
        }

        public List<Empleados> PorCargo(Empleados? entidad)
        {
            return this.IConexion!.Empleados!
                    .Where(x => x.Cargo!.Contains(entidad!.Cargo!))
                    .ToList();
        }
    }
}