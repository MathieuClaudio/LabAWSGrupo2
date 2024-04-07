using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using NetWebApi.DTOs;
using Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        protected readonly ApplicationDbContext _context;

        public PlayerController(ApplicationDbContext context) 
        { 
            _context = context;
        }


        /// <summary>
        /// Obtener todos los Jugadores
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Creando un Jugador
        /// Nota: se debe conocer el ClubId (es obligatorio)
        /// </summary>
        /// <param name="playerPostDto"></param>
        /// <returns></returns>
        [HttpPost("CreatePlayer")]
        public async Task<ActionResult> CreatePlayer(PlayerPostDto playerPostDto)
        {
            var player = new Player
            {
                FullName = playerPostDto.FullName,
                Age = playerPostDto.Age,
                Number = playerPostDto.Number,
                ClubId = playerPostDto.ClubId
            };

            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            return Ok("El jugador se creo correctamente");

        }


    }
}
