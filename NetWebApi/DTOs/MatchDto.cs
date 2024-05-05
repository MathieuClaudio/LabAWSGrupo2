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
        public int LocalClubId { get; set; }
        public string LocalClub { get; set; }

        // Equipo B
        public int VisitorClubId { get; set; }
        public string VisitorClub { get; set; }

        // Estadio del evento
        public int IdStadium { get; set; }
        public Stadium Venue { get; set; }

        public int LocalClubGoals { get; set; }
        public int VisitorClubGoals { get; set; }

    }
}
