using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.ViewModel;

namespace MAUIAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeService _incomeService;
        public IncomeController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }

        [HttpGet, Route("get")]
        public async Task<IActionResult> GetAllIncome() 
        {
            var response = await _incomeService.GetAllIncomeAsync();
            return Ok(response);
        }

        [HttpPost, Route("post")]
        public async Task<IActionResult> AddIncome(IncomeViewModel model)
        {
            var response = await _incomeService.AddIncomeAsync(model);
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut, Route("put/{id}")]
        public async Task<IActionResult> UpdateIncome(IncomeViewModel model, int id)
        {
            var response = await _incomeService.UpdateIncomeAsync(model, id);
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete, Route("delete/{id}")]
        public async Task<IActionResult> DeleteIncome(int id)
        {
            var response = await _incomeService.DeleteIncomeAsync(id);
            if (response)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
