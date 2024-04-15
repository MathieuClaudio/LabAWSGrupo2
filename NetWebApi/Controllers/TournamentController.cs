using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using NetWebApi.DTOs;

namespace NetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TournamentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAll")]
        [AllowAnonymous]
        public async Task<ActionResult<List<TournamentDto>>> GetAll()
        {
            var tournaments = await _unitOfWork.TournamentRepository.GetAll();

            var tournamentDto = tournaments.Select(tournament => new TournamentDto
            {
                Id = tournament.Id,
                Name = tournament.Name,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            }).ToList();

            return Ok(tournamentDto);
        }

    }
}
