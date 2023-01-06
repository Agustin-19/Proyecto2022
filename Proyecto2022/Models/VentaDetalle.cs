using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class VentaDetalle
    {
        public int Id { get; set; }
        [Required]
        public int IdVenta { get; set; }
        [Required]
        public int IdProducto { get; set; }
        [Required]
        public string? Producto { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal SubTotal { get; set; }
        public DateTime FechaRegistro { get; set; }

        // datos Secunadrios

        public string? NombreCliente { get; set; }
        public int DNICliente { get; set; }
        public decimal MontoPago { get; set; }
        public decimal MontoCambio { get; set; }
        public decimal MontoTotal { get; set; }

    }
}
