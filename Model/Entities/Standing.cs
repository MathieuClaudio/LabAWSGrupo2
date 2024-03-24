using Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Standing
    {
        public int Id { get; set; }

        // Club al que pertenece
        [ForeignKey(nameof(Club))]
        //Clave foránea de Club
        public int IdClub { get; set; }
        // Asociación de agregación con Club
        public Club CurrentClub { get; set; }

        // Partidos ganados
        public int Wins { get; set; }

        // Partidos empatados
        public int Draws { get; set; }

        // Partidos perdidos
        public int Losses { get; set; }

        // Puntos acumulados
        public int Points { get; set; }

        // Partidos jugados
        public int MatchesPlayed { get; set; }

        // Goles a favor
        public int GoalsFor { get; set; }

        // Goles en contra
        public int GoalsAgainst { get; set; }
    }
}
