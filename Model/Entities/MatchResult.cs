using Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model.Entities
{
    public class MatchResult
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public Match Match { get; set; }
        public int LocalClubGoals { get; set; }
        public int VisitorClubGoals { get; set;}
    }
}
