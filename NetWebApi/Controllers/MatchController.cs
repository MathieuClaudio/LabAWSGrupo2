using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using NetWebApi.DTOs;

namespace NetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MatchController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<List<MatchDto>>> GetAll()
        {
            var matches = await _unitOfWork.MatchRepository.GetAll();

            if (matches == null)
            {
                return NotFound(); // Devuelve un 404 si el match no se encuentra
            }


            // Mapea los matches a MatchDto
            var matchesDtos = new List<MatchDto>();

            foreach (var match in matches)
            {
                var matchResult = await _unitOfWork.MatchResultRepository.GetMatchResult(match.Id);

                var matchResultDto = new MatchResultDto
                {
                    Id = matchResult.Id,
                    MatchId = matchResult.MatchId,
                    LocalClubGoals = matchResult.LocalClubGoals,
                    VisitorClubGoals = matchResult.VisitorClubGoals
                };

                var matchDto = new MatchDto
                {
                    Id = match.Id,
                    MatchDate = match.MatchDate,
                    LocalClubId = match.LocalClubId,
                    LocalClub = await _unitOfWork.ClubRepository.GetClubNameById(match.LocalClubId),
                    VisitorClubId = match.VisitorClubId,
                    VisitorClub = await _unitOfWork.ClubRepository.GetClubNameById(match.VisitorClubId),
                    IdStadium = match.IdStadium,
                    LocalClubGoals = matchResultDto.LocalClubGoals,
                    VisitorClubGoals = matchResultDto.VisitorClubGoals
                    
                };

                matchesDtos.Add(matchDto);

            }

            return Ok(matchesDtos);
        }


        [HttpGet("GetMatchById/{matchId}")]
        public async Task<ActionResult<MatchDto>> GetMatchById(int matchId)
        {
            var match = await _unitOfWork.MatchRepository.GetId(matchId);
            var matchResult = await _unitOfWork.MatchResultRepository.GetMatchResult(match.Id);

            var matchResultDto = new MatchResultDto
            {
                Id = matchResult.Id,
                MatchId = matchResult.MatchId,
                LocalClubGoals = matchResult.LocalClubGoals,
                VisitorClubGoals = matchResult.VisitorClubGoals
            };

            if (match == null)
            {
                return NotFound(); // Devuelve un 404 si el match no se encuentra
            }

            // Mapea el match a MatchDto
            var matchDto = new MatchDto
            {
                Id = match.Id,
                MatchDate = match.MatchDate,
                LocalClubId = match.LocalClubId,
                LocalClub = await _unitOfWork.ClubRepository.GetClubNameById(match.LocalClubId),
                VisitorClubId = match.VisitorClubId,
                VisitorClub = await _unitOfWork.ClubRepository.GetClubNameById(match.VisitorClubId),
                IdStadium = match.IdStadium,
                LocalClubGoals = matchResultDto.LocalClubGoals,
                VisitorClubGoals = matchResultDto.VisitorClubGoals

            };

            return Ok(matchDto);
        }

        [HttpGet("GetMatchesByTournamentId/{tournamentId}")]
        public async Task<ActionResult<MatchDto>> GetMatchesByTournamentId(int tournamentId)
        {
            var tournamentMatches = await _unitOfWork.MatchRepository.GetMatchesByTournamentId(tournamentId);

            if (tournamentMatches == null)
            {
                return NotFound(); // Devuelve un 404 si el match no se encuentra
            }

            // Mapea los matches a MathDto
            var matchesDtos = new List<MatchDto>();

            foreach (var tournamentMatch in tournamentMatches)
            {
                var matchResult = await _unitOfWork.MatchResultRepository.GetMatchResult(tournamentMatch.Id);

                var matchResultDto = new MatchResultDto
                {
                    Id = matchResult.Id,
                    MatchId = matchResult.MatchId,
                    LocalClubGoals = matchResult.LocalClubGoals,
                    VisitorClubGoals = matchResult.VisitorClubGoals
                };

                var matchDto = new MatchDto
                {
                    Id = tournamentMatch.Id,
                    MatchDate = tournamentMatch.MatchDate,
                    LocalClubId = tournamentMatch.LocalClubId,
                    LocalClub = await _unitOfWork.ClubRepository.GetClubNameById(tournamentMatch.LocalClubId),
                    VisitorClubId = tournamentMatch.VisitorClubId,
                    VisitorClub = await _unitOfWork.ClubRepository.GetClubNameById(tournamentMatch.VisitorClubId),
                    IdStadium = tournamentMatch.IdStadium,
                    LocalClubGoals = matchResultDto.LocalClubGoals,
                    VisitorClubGoals = matchResultDto.VisitorClubGoals

                };

                matchesDtos.Add(matchDto);

            }

            return Ok(matchesDtos);

        }

        [HttpPost("InsertMatch")]
        public async Task<ActionResult> InsertMatch(MatchPostDto matchPostDto)
        {
            if (matchPostDto == null)
            {
                return BadRequest("Datos NO válidos para crear matches.");
            }

            var match = new Match
            {
                MatchDate = matchPostDto.MatchDate,
                LocalClubId = matchPostDto.IdClubA,
                VisitorClubId = matchPostDto.IdClubB,
                IdStadium = matchPostDto.IdStadium
                
            };
            await _unitOfWork.MatchRepository.Insert(match);
            var result = await _unitOfWork.Save();
            return Ok("Match creado");
        }

        [HttpPut("UpdateMatch/{matchId}")]
        public async Task<ActionResult> UpdateMatch(int matchId, MatchUpdateDto matchUpdateDto)
        {
            if (matchUpdateDto == null || matchId != matchUpdateDto.Id)
            {
                return BadRequest("Datos no válidos para actualizar el match.");
            }

            var existingMatch = await _unitOfWork.MatchRepository.GetId(matchId);

            if (existingMatch == null)
            {
                return NotFound(); // El match no existe
            }

            // Actualizar los datos del match
            existingMatch.MatchDate = matchUpdateDto.MatchDate;
           

            // Guardar los cambios en la base de datos
            await _unitOfWork.MatchRepository.Update(existingMatch);

            return Ok("Match actualizado correctamente.");
        }

        [HttpDelete("DeleteMatch/{matchId}")]
        public async Task<ActionResult> DeleteMatch(int matchId)
        {
            try
            {
                await _unitOfWork.MatchRepository.Delete(matchId);
                return Ok("Match eliminado correctamente.");
            }
            catch (Exception ex)
            {
                // Manejar la excepción y devolver un código de respuesta adecuado
                if (ex.Message == "Match no encontrado.")
                {
                    return NotFound("Match no encontrado.");
                }
                else
                {
                    return StatusCode(500, "Error interno del servidor.");
                }
            }
        }

    }
}
