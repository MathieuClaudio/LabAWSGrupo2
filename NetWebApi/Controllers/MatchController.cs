using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;

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

        [HttpGet]
        public async Task<IActionResult> GetMatches()
        {
            throw new NotImplementedException();
        }

        // GET:
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMatch(int id)
        {
            throw new NotImplementedException();
        }

        // POST: 
        [HttpPost]
        public async Task<IActionResult> CreateMatch(Match match)
        {
            throw new NotImplementedException();
        }

        // PUT: 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMatch(int id, Match match)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Match/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            throw new NotImplementedException();
        }
    }
}
