using Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Model.Entities
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        //public Standing Standing { get; set; }

        // relacion one to many (un torneo muchos partidos)
        public List<Match> Matches { get; set; }

        // relación many-to-many (un torneo muchos clubs, un clubs muchos torneos)
        public List<TournamentClub> TournamentsClubs { get; set; }
    }
}
