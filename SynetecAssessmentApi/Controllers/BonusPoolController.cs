using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SynetecAssessmentApi.Domain.Dtos;
using SynetecAssessmentApi.Domain.Services.Interfaces;

namespace SynetecAssessmentApi.Controllers
{
    [Route("api/[controller]")]
    public class BonusPoolController : Controller
    {
        private readonly IBonusPoolService _bonusPoolService;

        public BonusPoolController(IBonusPoolService bonusPoolService)
        {
            _bonusPoolService = bonusPoolService;
        }
        
        [HttpGet("get-all")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<EmployeeDto>), 200)]
        public IActionResult GetAll()
        {
            var result = _bonusPoolService.GetEmployeesAsync();
            
            return Ok(result);
        }

        [HttpPost("calculate-bonus")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(BonusPoolCalculatorResultDto), 200)]
        public async Task<IActionResult> CalculateBonus([FromBody] CalculateBonusDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            
            var result = await _bonusPoolService.CalculateAsync(request);
            
            return Ok(result);
        }
    }
}
