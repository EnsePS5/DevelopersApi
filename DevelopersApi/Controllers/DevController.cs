using DevelopersApi.DTO;
using DevelopersApi.Entities_Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace DevelopersApi.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class DevController : ControllerBase {

        private readonly IDbService _dbService;

        public DevController(IDbService dbService) {
            _dbService = dbService;
        }

        [HttpGet("/{GameId}")]
        public async Task<ResultDTO> GetDevelopersByGameId(int GameId) {

            return await _dbService.GetDevelopersByGameId(GameId);
        }

        [HttpPost]
        [Route("/{developer}/{GameId}")]
        public async Task<IActionResult> AddDeveloperToGame(int developer, int GameId) {

            if (await _dbService.AddDeveloperToGame(developer, GameId)) {

                return StatusCode((int)HttpStatusCode.Created);
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("/{DeveloperId}")]
        public async Task<IActionResult> DeleteDeveloperFromGame(int DeveloperId) {

            if (await _dbService.DeleteDeveloperFromGame(DeveloperId)) {

                return StatusCode((int)HttpStatusCode.OK);
            }

            return BadRequest();
        }
    }
}