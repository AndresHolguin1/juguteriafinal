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
    public class RolesAplicacion : IRolesAplicacion
    {
        private IConexion? IConexion = null;

        public RolesAplicacion(IConexion iConexion)
        {
            IConexion = iConexion;
        }

        public Roles? Borrar(Roles? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            this.IConexion!.Roles!.Remove(entidad);
            this.IConexion.SaveChangesAsync();
            return entidad;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Roles? Guardar(Roles? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Calculos

            this.IConexion!.Roles!.Add(entidad);
            this.IConexion.SaveChangesAsync();
            return entidad;
        }

        public List<Roles> Listar()
        {
            return this.IConexion!.Roles!.Take(20)
               
                .ToList();
        }

        public Roles? Modificar(Roles? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            var entry = this.IConexion!.Entry<Roles>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChangesAsync();
            return entidad;
        }

        public List<Roles> PorNombre(Roles? entidad)
        {
            return this.IConexion!.Roles!
                    .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
                    .ToList();
        }
    }
}
