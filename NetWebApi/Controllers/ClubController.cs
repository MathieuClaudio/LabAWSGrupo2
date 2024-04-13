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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClubController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

    
        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Club>))]
        public IActionResult GetAll()
        {
            var clubs = _mapper.Map<List<ClubDto>>(_unitOfWork.ClubRepository.GetAll());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(clubs);
        }

        // "ClubExists"
        [HttpGet("GetClubById/{clubId}")]
        public async Task<ActionResult<ClubDto>> GetClubById(int clubId)
        {
            var club = await _unitOfWork.ClubRepository.GetId(clubId);

            if (club == null)
            {
                return NotFound(); // Devuelve un 404 si el club no se encuentra
            }

            // Mapea el club a ClubDto
            var clubDto = new ClubDto
            {
                Name = club.Name,
                //Players = club.Players.Select(player => new Player
                //{
                //    FullName = player.FullName,
                //    Age = player.Age,
                //    Number = player.Number,
                //    ClubId = player.Id
                //}).ToList()
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


    //[HttpPost("CreateClub")]
    //[ProducesResponseType(204)]
    //[ProducesResponseType(400)]
    //public IActionResult CreateClub(Club newClub)
    //{
    //    if (newClub == null)
    //        return BadRequest(ModelState);

    //    var club = _clubRepository.GetAll()
    //        .Select(c => c.Name.Trim().ToUpper() == newClub.Name.TrimEnd().ToUpper())
    //        .FirstOrDefault();

    //    if (club != null)
    //    {
    //        ModelState.AddModelError("", "El Club ya existe");
    //        return StatusCode(422, ModelState);
    //    }

    //    if (!ModelState.IsValid)
    //        return BadRequest(ModelState);

    //    var clubMap = _mapper.Map<Club>(newClub);

    //    if (!_clubRepository.CreateClub(newClub))
    //    {
    //        ModelState.AddModelError("", "No se pudo guardar");
    //        return StatusCode(6500, ModelState);
    //    }

    //    return Ok("Club creado con éxito");
    //}



}

