using lib_dominio.Entidades;
namespace lib_aplicaciones.Interfaces
{
    public interface IJuguetesAplicacion
    {
        void Configurar(string StringConexion);
        List<Juguetes> PorDescripcion(Juguetes? entidad);
        List<Juguetes> Listar(); Juguetes? Guardar(Juguetes? entidad);
        Juguetes? Modificar(Juguetes? entidad);
        Juguetes? Borrar(Juguetes? entidad);
    }
}
