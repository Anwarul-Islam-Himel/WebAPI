using Shared.ViewModel;

namespace MauiAPI.Interfaces
{
    public interface IItemService
    {
        Task<List<ItemViewModel>> GetItemAsync();
        Task<ItemViewModel> AddItemAsync(ItemViewModel itemViewModel);
        Task<bool> RemoveItemAsync(int id);
    }
}
