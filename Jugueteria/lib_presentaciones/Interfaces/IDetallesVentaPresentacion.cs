using lib_dominio.Entidades;
namespace lib_presentaciones.Interfaces
{
    public interface IDetallesVentaPresentacion
    {
        Task<List<DetallesVenta>> Listar();
        Task<List<DetallesVenta>> PorCantidad(DetallesVenta? entidad);
        Task<DetallesVenta> Guardar(DetallesVenta? entidad);
        Task<DetallesVenta> Modificar(DetallesVenta? entidad);
        Task<DetallesVenta> Borrar(DetallesVenta? entidad);
    }
}
