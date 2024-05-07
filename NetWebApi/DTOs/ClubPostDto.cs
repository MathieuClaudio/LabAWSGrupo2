using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetWebApi.DTOs
{
    public class ClubPostDto
    {
        // Nombre del Club
        [Required(ErrorMessage = "El nombre del club es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El nombre del club no puede tener más de 50 caracteres.")]
        public string Name { get; set; }
    }
}
