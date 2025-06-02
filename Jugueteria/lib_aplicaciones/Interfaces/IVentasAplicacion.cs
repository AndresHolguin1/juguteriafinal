using lib_dominio.Entidades;
namespace lib_aplicaciones.Interfaces
{
    public interface IVentasAplicacion
    {
        void Configurar(string StringConexion);
        List<Ventas> PorFecha(Ventas? entidad);
        List<Ventas> Listar(); Ventas? Guardar(Ventas? entidad);
        Ventas? Modificar(Ventas? entidad);
        Ventas? Borrar(Ventas? entidad);
    }
}