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
        // fecha y hora del partido
        public DateTime MatchDate { get; set; }

        // Equipo A
        [ForeignKey(nameof(Club))]
        public int IdTeamA { get; set; }
        public Club TeamA { get; set; }

        // Equipo B
        [ForeignKey(nameof(Club))]
        public int IdTeamB { get; set; }
        public Club TeamB { get; set; }

        // Estadio del evento
        [ForeignKey(nameof(Stadium))]
        public int StadiumId { get; set; }
        public Stadium Venue { get; set; }

        // Resultado del evento
        public string Result { get; set; }
    }
}
