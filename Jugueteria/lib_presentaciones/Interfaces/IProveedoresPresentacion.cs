using lib_dominio.Entidades;
namespace lib_presentaciones.Interfaces
{
    public interface IProoveedoresPresentacion
    {
        Task<List<Proveedores>> Listar();
        Task<List<Proveedores>> PorCorreo(Proveedores? entidad);
        Task<Proveedores> Guardar(Proveedores? entidad);
        Task<Proveedores> Modificar(Proveedores? entidad);
        Task<Proveedores> Borrar(Proveedores? entidad);
    }
}