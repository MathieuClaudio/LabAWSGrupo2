using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using NetWebApi.DTOs;
using Repository;
using Repository.Repositories;
using System.Numerics;

namespace NetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlayerController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// Obtener todos los Jugadores
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllPlayers")]
        public async Task<ActionResult<List<PlayerDto>>> GetAllPlayers()
        {
            var players = await _unitOfWork.PlayerRepository.GetAll();

            var playersDto = new List<PlayerDto>();

            for (int i = 0; i < players.Count; i++)
            {
                var playerDto = new PlayerDto()
                {
                    Id = players[i].Id,
                    FullName = players[i].FullName,
                    Age = players[i].Age,
                    Number = players[i].Number,
                    ClubName = await _unitOfWork.ClubRepository.GetClubNameById(players[i].ClubId)
                };
                playersDto.Add(playerDto);
            }
           
            return Ok(playersDto);

        }

        /// <summary>
        /// Obtener jugador por su ID
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        [HttpGet("GetPlayerById/{playerId}")]
        public async Task<ActionResult<PlayerDto>> GetPlayerById(int playerId)
        {
            var player = await _unitOfWork.PlayerRepository.GetId(playerId);

            var playerDto = new PlayerDto
            {
                Id = playerId,
                FullName = player.FullName,
                Age = player.Age,
                Number = player.Number,
                ClubName = await _unitOfWork.ClubRepository.GetClubNameById(player.ClubId)
            };
            return Ok(playerDto);

        }

        /// <summary>
        /// Creando un jugador
        /// </summary>
        /// <param name="playerPostDto"></param>
        /// <returns></returns>
        [HttpPost("InsertPlayer")]
        [Authorize]
        public async Task<ActionResult> InsertPlayer(PlayerPostDto playerPostDto)
        {
            var player = new Player
            {
                FullName = playerPostDto.FullName,
                Age = playerPostDto.Age,
                Number = playerPostDto.Number,
                ClubId = playerPostDto.ClubId
            };

            await _unitOfWork.PlayerRepository.Insert(player);
            var result = await _unitOfWork.Save();
            return Ok(result >= 1);

        }


        [HttpPut("UpdatePlayer/{playerId}")]
        [Authorize]
        public async Task<ActionResult> UpdatePlayer(int playerId, PlayerDto playerDto)
        {
            if (playerDto == null || playerId != playerDto.Id)
            {
                return BadRequest("Datos no válidos para actualizar el jugador.");
            }

            var existingPlayer = await _unitOfWork.PlayerRepository.GetId(playerId);

            if (existingPlayer == null)
            {
                return NotFound();
            }

            // Actualizar datos
            existingPlayer.FullName = playerDto.FullName;
            existingPlayer.Age = playerDto.Age;
            existingPlayer.Number = playerDto.Number;

            await _unitOfWork.PlayerRepository.Update(existingPlayer);

            return Ok("Club actualizado correctamente.");
        }


        [HttpDelete("DeletePlayer/{playerId}")]
        [Authorize]
        public async Task<ActionResult> DeletePlayer(int playerId)
        {
            try
            {
                await _unitOfWork.PlayerRepository.Delete(playerId);
                return Ok("Player eliminado correctamente.");
            }
            catch (Exception ex)
            {
                // Manejar la excepción y devolver un código de respuesta adecuado
                if (ex.Message == "Player no encontrado.")
                {
                    return NotFound("Player no encontrado.");
                }
                else
                {
                    return StatusCode(500, "Error interno del servidor.");
                }
            }
        }

    }
}
