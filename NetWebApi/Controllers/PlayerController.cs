using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Entities.DTOs;
using Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        protected readonly ApplicationDbContext _context;

        public PlayerController(ApplicationDbContext context) { _context = context; }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<ClubDto>>> GetAll()
        {
            var players = await _context.Players.ToListAsync();

            var playerDto = players.Select(player => new PlayerDto{
                FullName = player.FullName,
                Age = player.Age,
                Number = player.Number
            }).ToList();
            return Ok(playerDto);

        }

    }
}
