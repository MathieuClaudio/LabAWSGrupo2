using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;
using Model.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ClubRepository : IClubRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        public ClubRepository(ApplicationDbContext context, IServiceProvider serviceProvider) 
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public override async Task<List<Club>> GetAll()
        {
            return await _context.Clubs.Include(club => club.Players).ToListAsync();
        }

        public override async Task<Club> GetClubById(int id)
        {
            var club = await _context.Clubs.FirstOrDefaultAsync(club => club.Id == id);

            return club; 
        }

        public override async Task<Club> GetClubByName(string name)
        {
            var club = await _context.Clubs.FirstOrDefaultAsync(club => club.Name == name);

            return club;
        }

        public override async Task<Club> InsertClub(Club club)
        {
            EntityEntry<Club> insertClub = await _context.Clubs.AddAsync(club);
            await _context.SaveChangesAsync();
            return insertClub.Entity;
        }

        // Falta que actualice o agregue nuevos jugadores
        public override async Task UpdateClub(Club club)
        {
            _context.Entry(club).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public override async Task DeleteClub(int id)
        {
            var club = await _context.Clubs.FindAsync(id);
            if (club == null)
            {
                throw new InvalidOperationException("Club no encontrado.");
            }

            _context.Clubs.Remove(club);
            await _context.SaveChangesAsync();
        }


        public override async Task<Club> UpdateClubPatch(int id, JsonPatchDocument<Club> patchDoc)
        {
            var club = await _context.Clubs.FindAsync(id);
            if (club == null)
            {
                throw new InvalidOperationException("Club no encontrado.");
            }

            patchDoc.ApplyTo(club);

            // Validar los cambios
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(club);
            Validator.TryValidateObject(club, context, validationResults, true);

            if (validationResults.Count > 0)
            {
                throw new InvalidOperationException("Datos de actualización no válidos.");
            }

            await _context.SaveChangesAsync();
            return club; // Devolvemos el club actualizado
        }

    }
}
