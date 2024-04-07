using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using NetWebApi.DTOs;
using NetWebApi;
using Repository.Interfaces;


namespace NetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly IClubRepository _clubRepository;
        private readonly IMapper _mapper;

        public ClubController(IClubRepository clubRepository, IMapper mapper)
        {
            _clubRepository = clubRepository;
            _mapper = mapper;
        }


    
        [HttpGet("GetClubs")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Club>))]
        public IActionResult GetClubs()
        {
            var clubs = _mapper.Map<List<ClubDto>>(_clubRepository.GetClubs());

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

            var club = _clubRepository.GetClubs()
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

        /// <summary>
        /// Creando varios Clubes
        /// </summary>
        /// <param name="clubPostDto"></param>
        /// <returns></returns>
        //[HttpPost("CreateClubs")]
        //public async Task<ActionResult> CreateClubs(ClubPostDto[] clubPostDto)
        //{
        //    if (clubPostDto == null || clubPostDto.Length == 0)
        //    {
        //        return BadRequest("Datos NO válidos para crear clubes.");
        //    }

        //    // Convertir cada ClubPostDto en un Club y agregarlos al contexto
        //    var clubsToAdd = clubPostDto.Select(dto => new Club
        //    {
        //        Name = dto.Name
        //    });

        //    _context.AddRange(clubsToAdd); // Debes agregar 'club' al contexto en lugar de 'clubPostDto'
        //    await _context.SaveChangesAsync();
        //    return Ok("Los clubes se han creado correctamente.");
        //}

    }
}
