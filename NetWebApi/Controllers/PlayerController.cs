﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using NetWebApi.DTOs;
using Repository;
using Repository.Interfaces;
using Repository.Repositories;

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
        public async Task<ActionResult<List<ClubDto>>> GetAllPlayers()
        {
            var players = await _unitOfWork.PlayerRepository.GetAll();

            var playerDto = players.Select(player => new PlayerDto{
                Id = player.Id,
                FullName = player.FullName,
                Age = player.Age,
                Number = player.Number
            }).ToList();
            return Ok(playerDto);

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
                FullName = player.FullName,
                Age = player.Age,
                Number = player.Number
            };
            return Ok(playerDto);

        }

        /// <summary>
        /// Creando un jugador
        /// </summary>
        /// <param name="playerPostDto"></param>
        /// <returns></returns>
        [HttpPost("InsertPlayer")]
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
