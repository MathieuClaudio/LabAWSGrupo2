namespace NetWebApi.DTOs
{
    public class MatchUpdateDto
    {
        public int Id { get; set; }
        public DateTime MatchDate { get; set; }

        // Resultado del evento
        public string Result { get; set; }
    }
}
