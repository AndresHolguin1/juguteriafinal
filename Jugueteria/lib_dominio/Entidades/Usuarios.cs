using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Usuarios
    {
        [Key]
        public int  Id { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }
        public string? Clave { get; set; }
        public string? Img { get; set; }
        public int RolId { get; set; }
        [ForeignKey("RolId")] public Roles? _Id_Rol { get; set; }

    }
}
