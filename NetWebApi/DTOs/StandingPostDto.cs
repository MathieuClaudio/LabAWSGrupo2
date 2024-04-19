using Model.Entities;

namespace NetWebApi.DTOs
{
    public class StandingPostDto
    {
        public int Position { get; set; }
        public int Points { get; set; }
        public int MatchesPlayed { get; set; }
        public int IdClub { get; set; }
    }
}
