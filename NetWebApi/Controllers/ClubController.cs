using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using NetWebApi.DTOs;
using Repository;
using Repository.Interfaces;
using NetWebApi;


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

    
        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Club>))]
        public IActionResult GetAll()
        {
            var clubs = _mapper.Map<List<ClubDto>>(_clubRepository.GetAll());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(clubs);
        }


        [HttpPost("CreateClub")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateClub(Club newClub)
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

            if (!_clubRepository.CreateClub(newClub))
            {
                ModelState.AddModelError("", "No se pudo guardar");
                return StatusCode(6500, ModelState);
            }

            return Ok("Club creado con éxito");
        }

      

    }
}
