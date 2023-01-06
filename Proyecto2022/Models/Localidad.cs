using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Localidad
    {
        public int Id { get; set; }
        [Required]
        public string? NombreLocalidad { get; set; }
    }
}
