using Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Standing
    {
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }

        public int Win
        {
            get
            {
                return this.MatchResults.Where(x => x.Match.LocalClubId == IdClub && x.LocalClubGoals > x.VisitorClubGoals).Count() + this.MatchResults.Where(x => x.Match.VisitorClubId == IdClub && x.VisitorClubGoals > x.LocalClubGoals).Count();
            }
        }
        public int Draw
        {
            get
            {
                return this.MatchResults.Where(x => x.Match.LocalClubId == IdClub && x.LocalClubGoals == x.VisitorClubGoals).Count() + this.MatchResults.Where(x => x.Match.VisitorClubId == IdClub && x.VisitorClubGoals == x.LocalClubGoals).Count();
            }
        }
        public int Loss
        {
            get
            {
                return this.MatchResults.Where(x => x.Match.LocalClubId == IdClub && x.LocalClubGoals < x.VisitorClubGoals).Count() + this.MatchResults.Where(x => x.Match.VisitorClubId == IdClub && x.VisitorClubGoals < x.LocalClubGoals).Count();
            }
        }

        public int MatchesPlayed
        {
            get
            {
                return this.Win + this.Loss + this.Draw;
            }
        }

        public int Points
        {
            get
            {
                return this.Draw + this.Win * 3;
            }
        }

        public int IdClub { get; set; }
        public Club Club { get; set; }

        

        public List<MatchResult> MatchResults { get; set; }

    }
}