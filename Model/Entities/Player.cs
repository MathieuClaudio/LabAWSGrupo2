using Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Player
    {
        public int Id { get; set; }

        // Nombre completo
        public string FullName { get; set; }

        // Edad
        public int Age { get; set; }

        // Número
        public int Number { get; set; }

        // Club al que pertenece
        public int ClubId { get; set; } // Esta por convención Entity+Id. No hace falta [ForeignKey(nameof(Club))]
        public Club Club { get; set;}
    }
}
