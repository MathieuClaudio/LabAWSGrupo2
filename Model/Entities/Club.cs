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
        public List<Player> Players { get; set; }
    }
}
