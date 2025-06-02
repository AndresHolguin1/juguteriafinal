using lib_dominio.Entidades;
namespace lib_aplicaciones.Interfaces
{
    public interface IEstantesAplicacion
    {
        void Configurar(string StringConexion);
        List<Estantes> PorDirrecion(Estantes? entidad);
        List<Estantes> Listar(); Estantes? Guardar(Estantes? entidad);
        Estantes? Modificar(Estantes? entidad);
        Estantes? Borrar(Estantes? entidad);
    }
}