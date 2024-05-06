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
                // obtengo lista match results 
                var results = await _unitOfWork.MatchResultRepository.GetMatchResultsByStandingId(standing.IdClub);

                // seteo lista en objeto para calcular propiedades.
                standing.MatchResults = results;

                var standingDto = new StandingDto
                {
                    Id = standing.Id,
                    TournamentId = standing.TournamentId,
                    Tournament = (await _unitOfWork.TournamentRepository.GetTournamentNameById(standing.TournamentId)).ToString(),
                    IdClub = standing.IdClub,
                    Club = (await _unitOfWork.ClubRepository.GetClubNameById(standing.IdClub)).ToString(),
                    Win = standing.Win,
                    Loss = standing.Loss,
                    Draw = standing.Draw,
                    MatchesPlayed = standing.MatchesPlayed,
                    Points = standing.Points
                };

                standingsDtos.Add(standingDto);
            }

            return Ok(standingsDtos);
        }

        [HttpGet("GetStandingById/{standingId}")]
        public async Task<ActionResult<StandingDto>> GetStandingById(int standingId)
        {
            var standing = await _unitOfWork.StandingRepository.GetId(standingId);
                                    
            if (standing == null)
            {
                return NotFound();
            }

            
            // obtengo lista match results 
            var results = await _unitOfWork.MatchResultRepository.GetMatchResultsByStandingId(standing.IdClub);

            // seteo lista en objeto para calcular propiedades.
            standing.MatchResults = results;

            // mapeo de Dto para devolver respuesta
            var standingDto = new StandingDto
            {
                Id = standing.Id,
                TournamentId = standing.TournamentId,
                Tournament = (await _unitOfWork.TournamentRepository.GetTournamentNameById(standing.TournamentId)).ToString(),
                IdClub = standing.IdClub,
                Club = (await _unitOfWork.ClubRepository.GetClubNameById(standing.IdClub)).ToString(),
                Win = standing.Win,
                Loss = standing.Loss,
                Draw = standing.Draw,
                MatchesPlayed = standing.MatchesPlayed,
                Points = standing.Points
            };

            return Ok(standingDto);
        }

        

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