using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities.DTOs
{
    public class PlayerPostDto
    {
        // Nombre completo
        public string FullName { get; set; }

        // Edad
        public int Age { get; set; }

        // Número
        public int Number { get; set; }
        
        // Club al que pertenece
        public int ClubId { get; set; }
    }
}
