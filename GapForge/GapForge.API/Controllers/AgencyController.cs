using GapForge.Core.DTOs;
using GapForge.Core.InterFaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GapForge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AgencyController : ControllerBase
    {
        private readonly IAgencyService _agencyService;

        public AgencyController(IAgencyService agencyService)
        {
            _agencyService = agencyService;
        }

        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _agencyService.GetProfileAsync(userId);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAgency(UpdateAgencyDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _agencyService.UpdateAgencyAsync(userId, dto);
            return Ok(result);
        }

        [HttpPut("upgrade")]
        public async Task<IActionResult> UpgradePlan([FromBody] string planType)
        {
            var validPlans = new[] { "Starter", "Growth", "Pro" };
            if (!validPlans.Contains(planType))
                return BadRequest(new { message = "Invalid plan type" });

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _agencyService.UpgradePlanAsync(userId, planType);
            return Ok(result);
        }
    }
}
