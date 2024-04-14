using Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Model.Entities
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Date StartDate { get; set; }
        public Date EndDate { get; set; }
        public List<Standing> Standing { get; set; }
        public List<Match> Matches { get; set; }
        public List<Club> Clubs { get; set; }
    }
}
