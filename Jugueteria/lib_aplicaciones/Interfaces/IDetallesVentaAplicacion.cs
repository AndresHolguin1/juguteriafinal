using lib_dominio.Entidades;
namespace lib_aplicaciones.Interfaces
{
    public interface IDetallesVentaAplicacion
    {
        void Configurar(string StringConexion);
        List<DetallesVenta> PorCantidad(DetallesVenta? entidad);
        List<DetallesVenta> Listar(); DetallesVenta? Guardar(DetallesVenta? entidad);
        DetallesVenta? Modificar(DetallesVenta? entidad);
        DetallesVenta? Borrar(DetallesVenta? entidad);
    }
}
