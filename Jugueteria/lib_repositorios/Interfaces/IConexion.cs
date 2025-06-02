using lib_dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Runtime.CompilerServices;

namespace lib_repositorios.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        DbSet<Juguetes>? juguetes { get; set; }
        DbSet<Estantes>? Estantes { get; set; }
        DbSet<Auditoria>? Auditoria { get; set; }
        DbSet<Roles>? Roles { get; set; }
        DbSet<Usuarios>? Usuarios { get; set; }
        DbSet<Empleados>? Empleados { get; set; }
        DbSet<Permisos>? Permisos { get; set; }
        DbSet<Pedidos>? Pedidos { get; set; }
        DbSet<Proveedores>? Proveedores { get; set; }
        DbSet<Ventas>? Ventas { get; set; }
        DbSet<DetallesVenta>? DetallesVenta { get; set; }


        EntityEntry<T> Entry<T>(T entity) where T : class;
       
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        int SaveChanges();

    }
}
