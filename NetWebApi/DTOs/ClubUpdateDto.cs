using Repository;
using System.ComponentModel.DataAnnotations;

namespace NetWebApi.DTOs
{
    public class ClubUpdateDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del club es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El nombre del club no puede tener más de 50 caracteres.")]
        public string Name { get; set; }

        public List<PlayerDto> Players { get; set; }
    }
}
