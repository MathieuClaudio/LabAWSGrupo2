using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using NetWebApi.DTOs;

namespace NetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadiumController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public StadiumController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAllStadium")]
        public async Task<ActionResult<List<StadiumDto>>> GetAllStadium()
        {
            var stadium = await _unitOfWork.StadiumRepository.GetAll();

            var stadiumDto = stadium.Select(stadium => new StadiumDto
            {
                Id = stadium.Id,
                Name = stadium.Name
            }).ToList();
            return Ok(stadiumDto);

        }

        [HttpGet("GetStadiumById/{stadiumId}")]
        public async Task<ActionResult<StadiumDto>> GetStadiumById(int stadiumId)
        {
            var stadium = await _unitOfWork.StadiumRepository.GetId(stadiumId);

            if (stadium == null)
            {
                return NotFound(); // Devuelve un 404 si el stadium no se encuentra
            }

            // Mapeo
            var stadiumDto = new StadiumDto
            {
                Id = stadium.Id,
                Name = stadium.Name
            };

            return Ok(stadiumDto);
        }

        [HttpPost("InsertStadiums")]
        public async Task<ActionResult> InsertStadiums(StadiumsPostDto stadiumsPostDto)
        {
            if (stadiumsPostDto == null)
            {
                return BadRequest("Datos NO válidos para crear stadiumses.");
            }

            var stadium = new Stadium
            {
                Name = stadiumsPostDto.Name
            };
            await _unitOfWork.StadiumRepository.Insert(stadium);
            var result = await _unitOfWork.Save();
            return Ok("Stadium creado");
        }

        [HttpPut("UpdateStadium/{stadiumId}")]
        public async Task<ActionResult> UpdateStadium(int stadiumId, StadiumDto stadiumDto)
        {
            if (stadiumDto == null || stadiumId != stadiumDto.Id)
            {
                return BadRequest("Datos no válidos para actualizar el stadium.");
            }

            var existingStadium = await _unitOfWork.StadiumRepository.GetId(stadiumId);

            if (existingStadium == null)
            {
                return NotFound(); // El stadium no existe
            }

            // Actualizar los datos del stadium
            existingStadium.Name = stadiumDto.Name;

            // Guardar los cambios en la base de datos
            await _unitOfWork.StadiumRepository.Update(existingStadium);

            return Ok("Stadium actualizado correctamente.");
        }

        [HttpDelete("DeleteStadium/{stadiumId}")]
        public async Task<ActionResult> DeleteStadium(int stadiumId)
        {
            try
            {
                await _unitOfWork.StadiumRepository.Delete(stadiumId);
                return Ok("Stadium eliminado correctamente.");
            }
            catch (Exception ex)
            {
                // Manejar la excepción y devolver un código de respuesta adecuado
                if (ex.Message == "Stadium no encontrado.")
                {
                    return NotFound("Stadium no encontrado.");
                }
                else
                {
                    return StatusCode(500, "Error interno del servidor.");
                }
            }
        }

    }
}
