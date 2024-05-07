using Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetWebApi.DTOs
{
    public class StandingDto
    {
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public string Tournament { get; set; }
        public int IdClub { get; set; }
        public string Club { get; set; }
        public int MatchesPlayed { get; set; }
        public int Win { get; set; }
        public int Loss { get; set; }
        public int Draw { get; set; }
        public int Points { get; set; }
        
    }
}