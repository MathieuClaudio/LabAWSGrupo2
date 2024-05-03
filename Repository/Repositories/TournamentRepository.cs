using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Interfaces;

namespace Repository.Repositories
{
    public class TournamentRepository : Repository<Tournament>, ITournamentRepository
    {
        public TournamentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Tournament>> GetAll()
        {
            var result = await _context.Tournaments.ToListAsync();
            return result;
        }

        public async Task<Tournament> GetId(int id)
        {
            var result = await _context.Tournaments.FirstOrDefaultAsync(tournament => tournament.Id == id);
            return result;
        }

        public async Task<Tournament> Insert(Tournament tournament)
        {
            EntityEntry<Tournament> insertTournament = await _context.Tournaments.AddAsync(tournament);
            await _context.SaveChangesAsync();
            return insertTournament.Entity;
        }

        public async Task<Tournament> Update(Tournament tournament)
        {
            _context.Entry(tournament).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return tournament;
        }

        public async Task<Tournament> Delete(int id)
        {
            var tournament = await _context.Tournaments.FindAsync(id);
            if (tournament == null)
            {
                throw new InvalidOperationException("Tournament no encontrado.");
            }

            _context.Tournaments.Remove(tournament);
            await _context.SaveChangesAsync();
            return tournament;

        }

        public async Task<string> GetTournamentNameById(int id)
        {
            var tournament = await _context.Tournaments.Where(c => c.Id == id).FirstOrDefaultAsync();

            if (tournament == null)
            {
                throw new InvalidOperationException("Torneo no encontrado.");
            }

            var tournamentName = tournament.Name;

            return tournamentName;
        }

    }
}
