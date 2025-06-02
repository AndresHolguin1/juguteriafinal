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
    public class JuguetesAplicacion : IJuguetesAplicacion
    {
        private IConexion? IConexion = null;

        public JuguetesAplicacion(IConexion iConexion)
        {
            IConexion = iConexion;
        }

        public Juguetes? Borrar(Juguetes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            this.IConexion!.juguetes!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Juguetes? Guardar(Juguetes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Calculos

            this.IConexion!.juguetes!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Juguetes> Listar()
        {
            return this.IConexion!.juguetes!.Take(20)
                .Include(x => x._Id_Estante)
                .ToList();
        }

        public Juguetes? Modificar(Juguetes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            var entry = this.IConexion!.Entry<Juguetes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Juguetes> PorDescripcion(Juguetes? entidad)
        {
            return this.IConexion!.juguetes!
                    .Where(x => x.Descripcion!.Contains(entidad!.Descripcion!))
                    .ToList();
        }
    }
}