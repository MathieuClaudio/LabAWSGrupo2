using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Entities.DTOs;
using Repository;

namespace NetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        protected readonly ApplicationDbContext _context;

        public ClubController(ApplicationDbContext context) {  _context = context; }


        [HttpGet("GetAll")]
        public async Task<ActionResult<List<ClubDto>>> GetAll()
        {
            var clubs = await _context.Clubs.Include(c => c.Players).ToListAsync();

            // Mapea los clubes a ClubDto
            var clubDto = clubs.Select(club => new ClubDto
            {
                Name = club.Name,
                Players = club.Players.Select(player => new Player
                {
                    FullName = player.FullName,
                    Age = player.Age,
                    Number = player.Number
                }).ToList()
            }).ToList();

            return Ok(clubDto);
        }


    }
}
