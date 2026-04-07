using GapForge.Core.DTOs;
using GapForge.Core.InterFaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GapForge.API.Controllers
{
    [ApiController]
    [Route("api/client/{clientId}/competitors")]
    [Authorize]
    public class CompetitorController : ControllerBase
    {
        private readonly ICompetitorService _competitorService;

        public CompetitorController(ICompetitorService competitorService)
        {
            _competitorService = competitorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int clientId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _competitorService.GetAllAsync(clientId, userId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            int clientId, CreateCompetitorDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _competitorService
                .CreateAsync(clientId, userId, dto);
            return CreatedAtAction(nameof(GetAll),
                new { clientId = clientId }, result);
        }

        [HttpDelete("{competitorId}")]
        public async Task<IActionResult> Delete(int clientId, int competitorId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _competitorService.DeleteAsync(competitorId, userId);
            return NoContent();
        }
    }
}
