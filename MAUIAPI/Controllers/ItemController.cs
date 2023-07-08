using MauiAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.ViewModel;

namespace MauiAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet,Route("get")]
        public async Task<IActionResult> GetItem()
        {
            var response = await _itemService.GetItemAsync();
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        //[HttpPost]
        //public async Task<IActionResult> AddItem(ItemViewModel model)
        //{
        //    var response = await _itemService.AddItemAsync(model);
        //    if(response == null)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(response);
        //}


        //[HttpDelete, Route("{id}")]
        //public async Task<IActionResult> DeleteItem(int id)
        //{
        //    var response = await _itemService.RemoveItemAsync(id);
        //    if (!response)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(response);
        //}
    }
}
