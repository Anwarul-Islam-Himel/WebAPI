using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.ViewModel;

namespace MAUIAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly ITypeSevice _typeService;
        public TypeController(ITypeSevice typeSevice)
        {
            _typeService = typeSevice;
        }
        [HttpGet, Route("get")]
        public async Task<IActionResult> GetAllTypes() 
        {
            var response = await _typeService.GetallTypesAsync();
            return Ok(response);
        }

        [HttpPost, Route("post")]
        public async Task<IActionResult> AddType(TypeViewModel model)
        {
            var response = await _typeService.AddTypeAsync(model);
            if(response != null)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut, Route("put/{id}")]
        public async Task<IActionResult> UpdateType(TypeViewModel model, int id)
        {
            var response = await _typeService.UpdateTypeAsync(model, id);
            if(response != null)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete, Route("delete/{id}")]
        public async Task<IActionResult> DeleteType(int id)
        {
            var response = await _typeService.DeleteTypeAsync(id);
            if (response)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
