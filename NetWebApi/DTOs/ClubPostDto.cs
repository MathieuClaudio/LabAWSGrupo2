using System.ComponentModel.DataAnnotations;

namespace NetWebApi.DTOs
{
    public class ClubPostDto
    {
        [StringLength(maximumLength: 150)]
        public string Name { get; set; }
    }
}
