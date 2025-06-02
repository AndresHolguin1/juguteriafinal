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
    public class ProveedoresAplicacion : IProveedoresAplicacion
    
    {
        private IConexion? IConexion = null;

        public ProveedoresAplicacion(IConexion iConexion)
        {
            IConexion = iConexion;
        }

        public Proveedores? Borrar(Proveedores? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            this.IConexion!.Proveedores!.Remove(entidad);
            this.IConexion.SaveChangesAsync();
            return entidad;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Proveedores? Guardar(Proveedores? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Calculos

            this.IConexion!.Proveedores!.Add(entidad);
            this.IConexion.SaveChangesAsync();
            return entidad;
        }

        public List<Proveedores> Listar()
        {
            return this.IConexion!.Proveedores!.Take(20).ToList();
        }

        public Proveedores? Modificar(Proveedores? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            var entry = this.IConexion!.Entry<Proveedores>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChangesAsync();
            return entidad;
        }

        public List<Proveedores> PorCorreo(Proveedores? entidad)
        {
            return this.IConexion!.Proveedores!
                 .Where(x => x.Correo!.Contains(entidad!.Correo!))
                 .ToList();
        }
    }
}
