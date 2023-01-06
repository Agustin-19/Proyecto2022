using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Apellido { get; set; }

        public int DNI { get; set; }
        [Required]
        public string? Telefono { get; set; }
        [Required]
        public string? Dirección { get; set; }
        public int LocalidadId { get; set; }
        public string? Localidad { get; set; }
        public string? Email { get; set; }

        [NotMapped]
        public string NombreCompleto
        {
            get { return Nombre + " " + Apellido; }
        }
    }
}
