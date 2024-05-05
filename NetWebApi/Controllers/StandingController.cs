using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using NetWebApi.DTOs;
using System.Numerics;

namespace NetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandingController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public StandingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<StandingDto>>> GetAll()
        {
            var standings = await _unitOfWork.StandingRepository.GetAll();
            

            // Mapea los standings a StandingDto
            var standingsDtos = new List<StandingDto>();

            foreach (var standing in standings)
            {
                var standingDto = new StandingDto
                {
                    Id = standing.Id,
                    TournamentId = standing.TournamentId,
                    Tournament = (await _unitOfWork.TournamentRepository.GetTournamentNameById(standing.TournamentId)).ToString(),
                    IdClub = standing.IdClub,
                    Club = (await _unitOfWork.ClubRepository.GetClubNameById(standing.IdClub)).ToString(),
                   //Win = standing.Win
                };

                standingsDtos.Add(standingDto);
            }

            return Ok(standingsDtos);
        }

        [HttpGet("GetStandingById/{standingId}")]
        public async Task<ActionResult<StandingDto>> GetStandingById(int standingId)
        {
            var standing = await _unitOfWork.StandingRepository.GetId(standingId);
            var matches = await _unitOfWork.MatchRepository.GetMatchesByTournamentId(standing.TournamentId);

            if (standing == null)
            {
                return NotFound();
            }

            var standingDto = new StandingDto
            {
                Id = standing.Id,
                TournamentId = standing.TournamentId,
                Tournament = (await _unitOfWork.TournamentRepository.GetTournamentNameById(standing.TournamentId)).ToString(),
                IdClub = standing.IdClub,
                Club = (await _unitOfWork.ClubRepository.GetClubNameById(standing.IdClub)).ToString(),
            };

            return Ok(standingDto);
        }

        //[HttpPost("InsertStanding")]
        //public async Task<ActionResult> InsertStanding(StandingPostDto standingPostDto)
        //{
        //    if (standingPostDto == null)
        //    {
        //        return BadRequest("Datos NO válidos para crear standing.");
        //    }

        //    var standing = new Standing
        //    {
        //        //Position = standingPostDto.Position,
        //        //Points = standingPostDto.Points,
        //        //MatchesPlayed = standingPostDto.MatchesPlayed,
        //        IdClub = standingPostDto.IdClub
        //    };
        //    await _unitOfWork.StandingRepository.Insert(standing);
        //    var result = await _unitOfWork.Save();
        //    return Ok("Standing creado");
        //}

        //[HttpPut("UpdateStanding/{standingId}")]
        //public async Task<ActionResult> UpdateStanding(int standingId, StandingUpdateDto standingUpdateDto)
        //{
        //    if (standingUpdateDto == null || standingId != standingUpdateDto.Id)
        //    {
        //        return BadRequest("Datos no válidos para actualizar el standing.");
        //    }

        //    var existingStanding = await _unitOfWork.StandingRepository.GetId(standingId);

        //    if (existingStanding == null)
        //    {
        //        return NotFound();
        //    }

        //    // Actualizar los datos del standing
        //    existingStanding.Position = standingUpdateDto.Position;
        //    existingStanding.Points = standingUpdateDto.Points;
        //    existingStanding.MatchesPlayed = standingUpdateDto.MatchesPlayed;

        //    // Guardar los cambios en la base de datos
        //    await _unitOfWork.StandingRepository.Update(existingStanding);

        //    return Ok("Standing actualizado correctamente.");
        //}

        [HttpDelete("DeleteStanding/{standingId}")]
        public async Task<ActionResult> DeleteStanding(int standingId)
        {
            try
            {
                await _unitOfWork.StandingRepository.Delete(standingId);
                return Ok("Standing eliminado correctamente.");
            }
            catch (Exception ex)
            {
                // Manejar la excepción y devolver un código de respuesta adecuado
                if (ex.Message == "Standing no encontrado.")
                {
                    return NotFound("Standing no encontrado.");
                }
                else
                {
                    return StatusCode(500, "Error interno del servidor.");
                }
            }
        }


    }
}