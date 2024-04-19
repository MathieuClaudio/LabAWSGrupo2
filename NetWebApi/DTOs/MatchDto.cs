using Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetWebApi.DTOs
{
    public class MatchDto
    {
        public int Id { get; set; }

        // fecha y hora del partido
        public DateTime MatchDate { get; set; }

        // Equipo A
        public int IdClubA { get; set; }
        public Club ClubA { get; set; }

        // Equipo B
        public int IdClubB { get; set; }
        public Club ClubB { get; set; }

        // Estadio del evento
        public int IdStadium { get; set; }
        public Stadium Venue { get; set; }

        // Resultado del evento
        public string Result { get; set; }
    }
}
