using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using NetWebApi.DTOs;
using Repository;
using Microsoft.AspNetCore.JsonPatch;
using Repository.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;


namespace NetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ClubController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClubController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// Obtener todos los Clubes
        /// </summary>
        /// AutoMapper.AutoMapperMappingException: Error mapping types.
        /// <returns></returns>
        [HttpGet("GetAll")]
        //[AllowAnonymous]
        public async Task<ActionResult<List<ClubDto>>> GetAll()
        {
            var clubs = await _unitOfWork.ClubRepository.GetAll();

            // Mapea los clubes a ClubDto:
            
            var clubsDto = new List<ClubDto>();

            // recorro clubs
            for (int i = 0; i < clubs.Count; i++)
            {
                // para cada club


                // preparo lista DTO jugadores para cada club
                var playersDto = new List<PlayerDto>();
                
                // traigo jugadores del club
                var players = await _unitOfWork.PlayerRepository.GetPlayersByClub(clubs[i].Id);

                // recorro lista jugadores de cada club y los guardo en nueva lista dto
                for (int j = 0; j < players.Count; j++)
                {
                    var playerDto = new PlayerDto()
                    {
                        Id = players[j].Id,
                        FullName = players[j].FullName,
                        Age = players[j].Age,
                        Number = players[j].Number,
                        ClubName = await _unitOfWork.ClubRepository.GetClubNameById(players[j].ClubId)
                    };
                    playersDto.Add(playerDto);
                }

                var clubDto = new ClubDto()
                {
                    Id = clubs[i].Id,
                    Name = clubs[i].Name,
                    Players = playersDto
                };
                clubsDto.Add(clubDto);
            }


            return Ok(clubsDto);
        }

        [HttpGet("GetClubById/{clubId}")]
        public async Task<ActionResult<ClubDto>> GetClubById(int clubId)
        {
            var club = await _unitOfWork.ClubRepository.GetId(clubId);
            var clubPlayers = await _unitOfWork.PlayerRepository.GetPlayersByClub(clubId);

            if (club == null)
            {
                return NotFound(); // Devuelve un 404 si el club no se encuentra
            }

            // se utiliza un Dto de Player para evitar bucle si se utilizara la entidad Player, que tiene atributo club id
            var players = new List<PlayerDto>();

            for (int i = 0; i < clubPlayers.Count; i++)
            {
                var playerDto = new PlayerDto
                {
                    Id = clubPlayers[i].Id,
                    FullName = clubPlayers[i].FullName,
                    Age = clubPlayers[i].Age,
                    Number = clubPlayers[i].Number,
                    ClubName = await _unitOfWork.ClubRepository.GetClubNameById(clubPlayers[i].ClubId),
                };
                players.Add(playerDto);
            }


            // Mapea el club a ClubDto
            var clubDto = new ClubDto
            {
                Id = club.Id,   
                Name = club.Name,
                Players =  players

            };

            return Ok(clubDto);
        }


        /// <summary>
        /// Creando un Club
        /// </summary>
        /// <param name="clubPostDto"></param>
        /// <returns></returns>
        [HttpPost("InsertClub")]
        public async Task<ActionResult> InsertClub(ClubPostDto clubPostDto)
        {
            if (clubPostDto == null)
            {
                return BadRequest("Datos NO válidos para crear clubes.");
            }

            var club = new Club
            {
                Name = clubPostDto.Name
            };
            await _unitOfWork.ClubRepository.Insert(club);
            var result = await _unitOfWork.Save();
            return Ok("Club creado");
        }


        [HttpPut("UpdateClub/{clubId}")]
        public async Task<ActionResult> UpdateClub(int clubId, ClubUpdateDto clubUpdateDto)
        {
            if (clubUpdateDto == null || clubId != clubUpdateDto.Id)
            {
                return BadRequest("Datos no válidos para actualizar el club.");
            }

            var existingClub = await _unitOfWork.ClubRepository.GetId(clubId);

            if (existingClub == null)
            {
                return NotFound(); // El club no existe
            }

            // Actualizar los datos del club
            existingClub.Name = clubUpdateDto.Name;

            // Guardar los cambios en la base de datos
            await _unitOfWork.ClubRepository.Update(existingClub);

            return Ok("Club actualizado correctamente.");
        }


        [HttpDelete("DeleteClub/{clubId}")]
        public async Task<ActionResult> DeleteClub(int clubId)
        {
            try
            {
                await _unitOfWork.ClubRepository.Delete(clubId);
                return Ok("Club eliminado correctamente.");
            }
            catch (Exception ex)
            {
                // Manejar la excepción y devolver un código de respuesta adecuado
                if (ex.Message == "Club no encontrado.")
                {
                    return NotFound("Club no encontrado.");
                }
                else
                {
                    return StatusCode(500, "Error interno del servidor.");
                }
            }
        }

    }
}
