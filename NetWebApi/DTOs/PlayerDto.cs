using Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PlayerDto
    {
        // Nombre completo
        public string FullName { get; set; }

        // Edad
        public int Age { get; set; }

        // Número
        public int Number { get; set; }
    }
}
