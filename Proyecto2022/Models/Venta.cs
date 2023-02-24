using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public int NumeroVenta { get; set; }
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public string? NombreCliente { get; set; }
        [Required]
        public int DNICliente { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal MontoPago { get; set; }
        public decimal MontoCambio { get; set; }
        public string? FechaRegistro { get; set; }
    }
}
