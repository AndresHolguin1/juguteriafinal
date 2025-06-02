using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_aplicaciones.Interfaces
{
    public interface  IAuditoriasAplicacion
    {
        void Configurar(string StringConexion);
        List<Auditoria> PorTabla(Auditoria? entidad);
        List<Auditoria> Listar(); Auditoria? Guardar(Auditoria? entidad);
        Auditoria? Modificar(  Auditoria? entidad);
        Auditoria? Borrar(Auditoria? entidad);
    }
}
