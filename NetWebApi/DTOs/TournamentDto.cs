using Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetWebApi.DTOs
{
    public class TournamentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Standing> Standing { get; set; }
        public List<Match> Matches { get; set; }
        public List<Club> Clubs { get; set; }
    }
}
