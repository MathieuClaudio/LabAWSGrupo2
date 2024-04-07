using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using NetWebApi.DTOs;
using Repository;

namespace NetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClubController(ApplicationDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Obtener todos los Clubes
        /// </summary>
        /// AutoMapper.AutoMapperMappingException: Error mapping types.
        /// <returns></returns>
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


        /// <summary>
        /// Creando un Club
        /// </summary>
        /// <param name="clubPostDto"></param>
        /// <returns></returns>
        [HttpPost("CreateClub")]
        public async Task<ActionResult> CreateClub(ClubPostDto clubPostDto)
        {
            if (clubPostDto == null)
            {
                return BadRequest("Datos NO válidos para crear clubes.");
            }

            var club = new Club
            {
                Name = clubPostDto.Name
            };
            _context.Add(club);
            await _context.SaveChangesAsync();
            return Ok("Club creado");
        }

        /// <summary>
        /// Creando varios Clubes
        /// </summary>
        /// <param name="clubPostDto"></param>
        /// <returns></returns>
        [HttpPost("CreateClubs")]
        public async Task<ActionResult> CreateClubs(ClubPostDto[] clubPostDto)
        {
            if (clubPostDto == null || clubPostDto.Length == 0)
            {
                return BadRequest("Datos NO válidos para crear clubes.");
            }

            var clubsToAdd = clubPostDto.Select(dto => new Club
            {
                Name = dto.Name
            });

            _context.AddRange(clubsToAdd);
            await _context.SaveChangesAsync();
            return Ok("Los clubes se han creado correctamente.");
        }

    }
}
