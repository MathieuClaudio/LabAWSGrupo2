using Repository;

namespace NetWebApi.DTOs
{
    public class ClubUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PlayerDto> Players { get; set; }
    }
}