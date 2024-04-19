using Model.Entities;

namespace NetWebApi.DTOs
{
    public class MatchPostDto
    {
        public DateTime MatchDate { get; set; }

        // Equipo A
        public int IdClubA { get; set; }

        // Equipo B
        public int IdClubB { get; set; }

        // Estadio del evento
        public int IdStadium { get; set; }

        // Resultado del evento
        public string Result { get; set; }
    }
}
