using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class DetallesVenta
    {
        [Key]
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal Preciounitario { get; set; }
        public int ventas { get; set; }
        public int juguetes { get; set; }
        public string? Img { get; set; }
        
        [ForeignKey("ventas")] public Ventas? _Id_Venta { get; set; }
        [ForeignKey("juguetes")] public Juguetes? _Id_Juguete { get; set; }
       
    }
}
