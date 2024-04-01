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

        // Nombre del Club
        public string Name { get; set; }

        // Listado de Jugadores // HashSet es mas rápido para trabajar con colecciones de datos pero es dificil ordenar los datos
        public List<Player> Players { get; set; }
    }
}
