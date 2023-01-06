using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del Producto es requerido")]
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public string Marca { get; set; }
        public string Detalle { get; set; }

        [Required]
        public decimal Precio { get; set; }
    }
}
