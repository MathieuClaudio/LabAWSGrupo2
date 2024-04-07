using Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities.DTOs
{
    public class TournamentDto
    {
        // Nombre del Torneo (Copa Argentina)
        public string Name { get; set; }

        // Tabla de posición
        [ForeignKey(nameof(Standing))]
        public int IdStanding { get; set; }
        public Standing Standing { get; set; } // Relación de composición

        // Lista de partidos
        public List<Match> Matches { get; set; } // Relación de agregación

        // Lista de clubes
        public List<Club> Clubs { get; set; } // Relación de agregación
    }
}
