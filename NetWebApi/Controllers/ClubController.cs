using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using NetWebApi.DTOs;
using Repository;
using Repository.Interfaces;

namespace NetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly IClubRepository _clubRepository;
        private readonly IMapper _mapper;

        public ClubController(IClubRepository context, IMapper mapper)
        {
            _clubRepository = context;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Club>))]
        public IActionResult GetAll()
        {
            var clubs = _mapper.Map<List<ClubDto>>(_clubRepository.GetAll());

            //// Mapea los clubes a ClubDto
            //var clubDto = clubs.Select(club => new ClubDto
            //{
            //    Name = club.Name,
            //    Players = club.Players.Select(player => new Player
            //    {
            //        FullName = player.FullName,
            //        Age = player.Age,
            //        Number = player.Number
            //    }).ToList()
            //}).ToList();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(clubs);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateClub(ClubPostDto newClub)
        {
            if (newClub == null)
                return BadRequest(ModelState);

            var club = _clubRepository.GetAll()
                .Where(c => c.Name.Trim().ToUpper() == newClub.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (club != null)
            {
                ModelState.AddModelError("", "El Club ya existe");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var clubMap = _mapper.Map<Club>(newClub);

            if (!_clubRepository.CreateClub(clubMap))
            {
                ModelState.AddModelError("", "No se pudo guardar");
                return StatusCode(500, ModelState);
            }

            return Ok("Club creado con éxito");
        }

       

    }
}
