using lib_dominio.Entidades;
namespace lib_presentaciones.Interfaces
{
    public interface IJuguetesPresentacion
    {
        Task<List<Juguetes>> Listar();
        Task<List<Juguetes>> PorDescripcion(Juguetes? entidad);
        Task<Juguetes> Guardar(Juguetes? entidad);
        Task<Juguetes> Modificar(Juguetes? entidad);
        Task<Juguetes> Borrar(Juguetes? entidad);
    }
}