using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace lib_repositorios.Implementaciones
{
    public partial class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }





        public DbSet<Juguetes>? juguetes { get; set; }
        public DbSet<Estantes>? Estantes { get; set; }

        public DbSet<Usuarios>? Usuarios { get; set; }
        public DbSet<Empleados>? Empleados { get; set; }
        public DbSet<Roles>? Roles { get; set; }
        public DbSet<Auditoria>? Auditoria { get; set; }
        public DbSet<Permisos>? Permisos { get; set; }
        public DbSet<Pedidos>? Pedidos { get; set; }
        public DbSet<Proveedores>? Proveedores { get; set; }
        public DbSet<Ventas>? Ventas { get; set; }
        public DbSet<DetallesVenta>? DetallesVenta { get; set; }

        public override int SaveChanges()
        {
            RegistrarCambiosAuditables();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            RegistrarCambiosAuditables();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void RegistrarCambiosAuditables()
        {
            var entradas = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added
                            || e.State == EntityState.Modified
                            || e.State == EntityState.Deleted)
                .ToList();  // Materializar la lista primero

            foreach (var entry in entradas)
            {
                var auditoria = new Auditoria
                {
                    Tabla = entry.Metadata.GetTableName() ?? entry.Entity.GetType().Name,
                    Accion = entry.State.ToString(),
                    Fecha = DateTime.UtcNow,
                    Usuario = ObtenerUsuarioActual(),
                    LlavePrimaria = ObtenerLlavePrimaria(entry),
                    Cambios = ObtenerCambios(entry)
                };

                Auditoria.Add(auditoria);
            }
        }

        private string ObtenerLlavePrimaria(Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entry)
        {
            if (entry.State == EntityState.Added)
            {
                return "N/A";
            }
            var llave = entry.Properties.FirstOrDefault(p => p.Metadata.IsPrimaryKey());
            return llave?.CurrentValue?.ToString() ?? "";
        }


        private string ObtenerCambios(Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entry)
        {
            var cambios = new List<string>();

            if (entry.State == EntityState.Added)
            {
                foreach (var prop in entry.Properties)
                {
                    cambios.Add($"{prop.Metadata.Name} = {prop.CurrentValue}");
                }
            }
            else if (entry.State == EntityState.Deleted)
            {
                foreach (var prop in entry.Properties)
                {
                    cambios.Add($"{prop.Metadata.Name} (original) = {prop.OriginalValue}");
                }
            }
            else if (entry.State == EntityState.Modified)
            {
                foreach (var prop in entry.Properties)
                {
                    if (prop.IsModified)
                    {
                        cambios.Add($"{prop.Metadata.Name}: {prop.OriginalValue} => {prop.CurrentValue}");
                    }
                }
            }

            return string.Join("; ", cambios);
        }

        private string ObtenerUsuarioActual()
        {
            // Implementa la lógica para obtener el usuario actual si es necesario
            return "usuario-sistema"; // Ejemplo placeholder
        }
    }
}
       
    

