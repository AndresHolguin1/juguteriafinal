using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Pedidos
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int proveedores { get; set; }
        public int empleados { get; set; }
        public string? Img { get; set; }
        [ForeignKey("proveedores")] public Proveedores? _Id_Proovedor { get; set; }
        [ForeignKey("empleados")] public Empleados? _Id_Empleado { get; set; }
    }
}
