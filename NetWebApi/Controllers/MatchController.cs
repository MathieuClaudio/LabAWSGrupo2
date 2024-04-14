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
            var matchs = await _unitOfWork.MatchRepository.GetAll();

            // Mapea los matches a MathDto
            var matchDto = matchs.Select(match => new MatchDto
            {
                Id = match.Id,
                MatchDate = match.MatchDate,
                IdClubA = match.IdClubA,
                IdClubB = match.IdClubB,
                IdStadium = match.IdStadium,
                Result = match.Result

            }).ToList();

            return Ok(matchDto);
        }


        [HttpGet("GetMatchById/{matchId}")]
        public async Task<ActionResult<MatchDto>> GetMatchById(int matchId)
        {
            var match = await _unitOfWork.MatchRepository.GetId(matchId);

            if (match == null)
            {
                return NotFound(); // Devuelve un 404 si el match no se encuentra
            }

            // Mapea el match a MatchDto
            var matchDto = new MatchDto
            {
                Id = match.Id,
                MatchDate = match.MatchDate,
                IdClubA = match.IdClubA,
                IdClubB = match.IdClubB,
                IdStadium = match.IdStadium,
                Result = match.Result
            };

            return Ok(matchDto);
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
                IdClubA = matchPostDto.IdClubA,
                IdClubB = matchPostDto.IdClubB,
                IdStadium = matchPostDto.IdStadium,
                Result = matchPostDto.Result
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
            existingMatch.Result = matchUpdateDto.Result;

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
