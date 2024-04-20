using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Relación One-to-Many
        public List<Player> Players { get; set; }

        // relación many-to-many (un torneo muchos clubs, un clubs muchos torneos) - "Torneos que juega o jugó el club"
        public List<TournamentClub> Tournaments { get; set; }
    }
}
