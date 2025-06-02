using lib_dominio.Entidades;
namespace lib_presentaciones.Interfaces
{
    public interface IVentasPresentacion
    {
        Task<List<Ventas>> Listar();
        Task<List<Ventas>> PorFecha(Ventas? entidad);
        Task<Ventas> Guardar(Ventas? entidad);
        Task<Ventas> Modificar(Ventas? entidad);
        Task<Ventas> Borrar(Ventas? entidad);
    }
}
