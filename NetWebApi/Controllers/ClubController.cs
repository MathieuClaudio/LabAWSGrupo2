using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using NetWebApi.DTOs;
using Repository;
using System.Reflection;
using Repository.Interfaces;
using Microsoft.AspNetCore.JsonPatch;


namespace NetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly IClubRepository _clubRepository;

        public ClubController(IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;
        }


        /// <summary>
        /// Obtener todos los Clubes
        /// </summary>
        /// AutoMapper.AutoMapperMappingException: Error mapping types.
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<ClubDto>>> GetAll()
        {
            var clubs = await _clubRepository.GetAll();

            // Mapea los clubes a ClubDto
            var clubDto = clubs.Select(club => new ClubDto
            {
                Name = club.Name,
                Players = club.Players.Select(player => new Player
                {
                    FullName = player.FullName,
                    Age = player.Age,
                    Number = player.Number,
                    ClubId = player.Id
                }).ToList()
            }).ToList();

            return Ok(clubDto);
        }

        [HttpGet("GetClubById/{clubId}")]
        public async Task<ActionResult<ClubDto>> GetClubById(int clubId)
        {
            var club = await _clubRepository.GetClubById(clubId);

            if (club == null)
            {
                return NotFound(); // Devuelve un 404 si el club no se encuentra
            }

            // Mapea el club a ClubDto
            var clubDto = new ClubDto
            {
                Name = club.Name,
                // Si agrego la lista de player falla
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

        [HttpGet("GetClubByName/{name}")]
        public async Task<ActionResult<ClubDto>> GetClubByName(string name)
        {
            

            if (name == null)
            {
                return NotFound(); // Devuelve un 404 si el club no se encuentra
            }

            var club = await _clubRepository.GetClubByName(name);

            if (club == null)
            {
                return NotFound(); // Devuelve un 404 si el club no se encuentra
            }

            // Mapea el club a ClubDto
            var clubDto = new ClubDto
            {
                Name = club.Name,
                // Si agrego la lista de player falla
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
            await _clubRepository.InsertClub(club);
            return Ok("Club creado");
        }


        [HttpPut("UpdateClub/{id}")]
        public async Task<ActionResult> UpdateClub(int id, ClubUpdateDto clubUpdateDto)
        {
            if (clubUpdateDto == null || id != clubUpdateDto.Id)
            {
                return BadRequest("Datos no válidos para actualizar el club.");
            }

            var existingClub = await _clubRepository.GetClubById(id);

            if (existingClub == null)
            {
                return NotFound(); // El club no existe
            }

            // Actualizar los datos del club
            existingClub.Name = clubUpdateDto.Name;
            // Aquí puedes manejar la actualización de jugadores si es necesario

            // Guardar los cambios en la base de datos
            await _clubRepository.UpdateClub(existingClub);

            return Ok("Club actualizado correctamente.");
        }


        [HttpDelete("DeleteClub/{id}")]
        public async Task<ActionResult> DeleteClub(int id)
        {
            try
            {
                await _clubRepository.DeleteClub(id);
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

        [HttpPatch("UpdateClubPatch/{id}")]
        public async Task<IActionResult> UpdateClubPatch(int id, [FromBody] JsonPatchDocument<Club> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest("Datos de actualización no proporcionados.");
            }

            try
            {
                var updatedClub = await _clubRepository.UpdateClubPatch(id, patchDoc);
                return Ok(updatedClub);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



    }
}
