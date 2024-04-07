using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using NetWebApi.DTOs;
using Repository;
using System.Reflection;
using Repository.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Repository.Repositories;

namespace NetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<PlayerDto>>> GetAll()
        {
            var players = await _playerRepository.GetAllPlayersAsync();
            var playerDtos = players.Select(p => new PlayerDto
            {
                FullName = p.FullName,
                Age = p.Age,
                Number = p.Number
            }).ToList();
            return Ok(playerDtos);
        }

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

            await _playerRepository.CreatePlayerAsync(player);
            return Ok("El jugador se creó correctamente");
        }

        [HttpPut("UpdatePlayer/{id}")]
        public async Task<ActionResult> UpdatePlayer(int id, PlayerPostDto playerPostDto)
        {
            var player = await _playerRepository.GetPlayerByIdAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            player.FullName = playerPostDto.FullName;
            player.Age = playerPostDto.Age;
            player.Number = playerPostDto.Number;
            player.ClubId = playerPostDto.ClubId;

            await _playerRepository.UpdatePlayerAsync(player);
            return Ok("El jugador se actualizó correctamente");
        }

        [HttpDelete("DeletePlayer/{id}")]
        public async Task<ActionResult> DeletePlayer(int id)
        {
            var player = await _playerRepository.GetPlayerByIdAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            await _playerRepository.DeletePlayerAsync(id);
            return Ok("El jugador se eliminó correctamente");
        }
    }
}
