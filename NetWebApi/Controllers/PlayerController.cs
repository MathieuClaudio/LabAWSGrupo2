using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Model.Entities.DTOs;

namespace NetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(ILogger<PlayerController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetPlayers")]
        public IEnumerable<PlayerDto> GetPlayers()
        {
            _logger.LogInformation("Obtener todos los jugadores");
            return new List<PlayerDto>
            {
                new PlayerDto{Id=1, FullName="Claudio Mathieu", Age=35, Number=10, IdClub=1, CurrentClub=new Club{Id=1, Name="Club A"}},
                new PlayerDto{Id=2, FullName="Nicolás Madeo", Age=26, Number=7, IdClub=2, CurrentClub=new Club{Id=2, Name="Club B"}},
                new PlayerDto{Id=3, FullName="Emanuel Gonzalez", Age=25, Number=5, IdClub=1, CurrentClub=new Club{Id=1, Name="Club A"}}
            };
        }


    }
}
