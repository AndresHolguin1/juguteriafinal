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
    public class AuditoriasAplicacion : IAuditoriasAplicacion
    {
        private IConexion? IConexion = null;

        public AuditoriasAplicacion(IConexion iConexion)
        {
            IConexion = iConexion;
        }

        public Auditoria? Borrar(Auditoria? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            this.IConexion!.Auditoria!.Remove(entidad);
            this.IConexion.SaveChangesAsync();
            return entidad;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Auditoria? Guardar(Auditoria? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Calculos

            this.IConexion!.Auditoria!.Add(entidad);
            this.IConexion.SaveChangesAsync();
            return entidad;
        }

        public List<Auditoria> Listar()
        {
            return this.IConexion!.Auditoria!
                .Take(20)
                .ToList();


        }

        public Auditoria? Modificar(Auditoria? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            var entry = this.IConexion!.Entry<Auditoria>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChangesAsync();
            return entidad;
        }

        public List<Auditoria> PorTabla(Auditoria? entidad)
        {
            return this.IConexion!.Auditoria!
    .Where(x => x.Tabla == entidad!.Tabla)
    .ToList();
        }
    }
}

