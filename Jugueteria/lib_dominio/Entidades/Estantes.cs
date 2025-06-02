using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Estantes
    {
        
        public int Id { get; set; }
        public string? Ubicacion { get; set; }
        public string? Seccion { get; set; }
        public string? Img { get; set; }
    }
}
