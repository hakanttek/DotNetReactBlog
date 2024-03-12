using Microsoft.AspNetCore.Mvc;
using ReactWebBlogger.Contracts.Services;
using ReactWebBlogger.Application.DTOs; // Import GameDto
using Microsoft.AspNetCore.Authorization;

namespace ReactWebBlogger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class GameController : ControllerBase
    {
        private readonly IGameService<GameDto> _gameService;

        public GameController(IGameService<GameDto> gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var games = await _gameService.GetAllAsync();
            return Ok(games);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var game = await _gameService.GetByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GameDto gameDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _gameService.AddAsync(gameDto);
            return CreatedAtAction(nameof(GetById), new { id = gameDto.Id }, gameDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] GameDto gameDto)
        {
            if (id != gameDto.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _gameService.UpdateAsync(gameDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var game = await _gameService.GetByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            await _gameService.DeleteAsync(id);
            return NoContent();
        }
    }
}
