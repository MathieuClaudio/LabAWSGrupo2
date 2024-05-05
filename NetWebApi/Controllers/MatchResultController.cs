using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using NetWebApi.DTOs;
using Repository;

namespace NetWebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MatchResultController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MatchResultController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Obtener todos los Resultado de los partidos
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllMatchResults")]
        public async Task<ActionResult<List<MatchResultDto>>> GetAllMatchResults()
        {

            var matchResults = await _unitOfWork.MatchResultRepository.GetAll();

            var matchResultDto = matchResults.Select(matchResult => new MatchResultDto
            {
                Id = matchResult.Id,
                MatchId = matchResult.MatchId,
                LocalClubGoals = matchResult.LocalClubGoals,
                VisitorClubGoals = matchResult.VisitorClubGoals

            }).ToList();

            return Ok(matchResultDto);
        }

    }
}
