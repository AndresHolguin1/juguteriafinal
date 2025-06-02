using lib_dominio.Entidades;
namespace lib_aplicaciones.Interfaces
{
    public interface IPedidiosAplicacion
    {
        void Configurar(string StringConexion);
        List<Pedidos> PorFecha(Pedidos? entidad);
        List<Pedidos> Listar(); Pedidos? Guardar(Pedidos? entidad);
        Pedidos? Modificar(Pedidos? entidad);
        Pedidos? Borrar(Pedidos? entidad);
    }
}

