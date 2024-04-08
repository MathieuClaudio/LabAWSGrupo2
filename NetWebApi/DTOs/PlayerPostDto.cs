using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetWebApi.DTOs
{
    public class PlayerPostDto
    {
        // Nombre completo
        [StringLength(maximumLength: 150)]
        public string FullName { get; set; }

        // Edad
        [Range(0, 99, ErrorMessage = "La edad debe ser entre 0 y 99.")]
        public int Age { get; set; }

        // Número
        [Range(0, 99, ErrorMessage = "El número debe ser entre 0 y 99.")]
        public int Number { get; set; }
        
        // Club al que pertenece
        public int ClubId { get; set; }
    }
}
