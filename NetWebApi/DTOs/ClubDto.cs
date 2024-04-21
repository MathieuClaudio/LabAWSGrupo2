using Model.Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetWebApi.DTOs
{
    public class ClubDto
    {
        public int Id { get; set; }
        // Nombre del Club
        public string Name { get; set; }

        // Listado de Jugadores
        public List<PlayerDto> Players { get; set; }
    }
}
