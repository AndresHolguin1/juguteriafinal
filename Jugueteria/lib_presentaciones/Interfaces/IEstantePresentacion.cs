using lib_dominio.Entidades;
namespace lib_presentaciones.Interfaces
{
    public interface IEstantesPresentacion
    {
        Task<List<Estantes>> Listar();
        Task<List<Estantes>> PorDirrecion(Estantes? entidad);
        Task<Estantes> Guardar(Estantes? entidad);
        Task<Estantes> Modificar(Estantes? entidad);
        Task<Estantes> Borrar(Estantes? entidad);
    }
}
