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
    public class EstantesAplicacion : IEstantesAplicacion
    {
        private IConexion? IConexion = null;

        public EstantesAplicacion(IConexion iConexion)
        {
            IConexion = iConexion;
        }

        public Estantes? Borrar(Estantes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            this.IConexion!.Estantes!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Estantes? Guardar(Estantes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Calculos

            this.IConexion!.Estantes!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Estantes> Listar()
        {
            return this.IConexion!.Estantes!.Take(20).ToList();
        }

        public Estantes? Modificar(Estantes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            var entry = this.IConexion!.Entry<Estantes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Estantes> PorDirrecion(Estantes? entidad)
        {
            return this.IConexion!.Estantes!
                           .Where(x => x.Ubicacion!.Contains(entidad!.Ubicacion!))
                           .ToList();
        }
    }
}
