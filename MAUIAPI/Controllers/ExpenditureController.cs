using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.ViewModel;

namespace MAUIAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenditureController : ControllerBase
    {
        private readonly IExpenditureService _expenditureService;
        public ExpenditureController(IExpenditureService expenditureService)
        {
            _expenditureService = expenditureService;
        }

        [HttpGet, Route("get")]
        public async Task<IActionResult> GetAllExpenditure() 
        { 
            var response = await _expenditureService.GetAllExpenditureAsync();
            return Ok(response);
        }

        [HttpPost, Route("post")]
        public async Task<IActionResult> AddExpenditure(ExpenditureViewModel model)
        {
            var response = await _expenditureService.AddExpenditureAsync(model);
            if(response != null)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut, Route("put/{id}")]
        public async Task<IActionResult> UpdateExpenditure(ExpenditureViewModel model, int id)
        {
            var response = await _expenditureService.UpdateExpenditureAsync(model, id);
            if(response != null)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete, Route("delete/{id}")]
        public async Task<IActionResult> DeleteExpenditure(int id)
        {
            var response = await _expenditureService.DeleteExpenditureAsync(id);
            if (response)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
