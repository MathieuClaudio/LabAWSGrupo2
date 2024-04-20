using Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    // virtualmente Stand(ing)
    public class TournamentClub
    {
        public int Id { get; set; }
        public int IdClub { get; set; }
        public Club Club { get; set; }
        public int IdTournament { get; set; }
        public Tournament Tournament { get; set; }
        public int Position { get; set; }
        public int Points { get; set; }
        public int MatchesPlayed { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public int Draws { get; set; }
        public int Goals { get; set; }
        public int GoalsAgainst {  get; set; }


    }
}
