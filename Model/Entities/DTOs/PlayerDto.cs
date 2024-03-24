using Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities.DTOs
{
    public class PlayerDto
    {
        public int Id { get; set; }
        // Nombre completo
        public string FullName { get; set; }

        // Edad
        public int Age { get; set; }

        // Número
        public int Number { get; set; }

        // Club al que pertenece
        [ForeignKey(nameof(Club))]
        public int IdClub { get; set; }
        public Club CurrentClub { get; set; }
    }
}
