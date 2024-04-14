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
        public int Position { get; set; }
        public int Points { get; set; }
        public int MatchesPlayed { get; set; }
        public int IdClub { get; set; }
        public Club Club { get; set; }
    }
}
