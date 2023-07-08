using AutoMapper;
using Domain.EntityModel;
using MauiAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using Service.AppDb;
using Shared.ViewModel;

namespace MauiAPI.Implementations
{
    public class ItemService : IItemService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ItemService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ItemViewModel> AddItemAsync(ItemViewModel itemViewModel)
        {
            try
            {
                var item = _mapper.Map<Item>(itemViewModel);
                await _context.Items.AddAsync(item);
                await _context.SaveChangesAsync();
                return _mapper.Map<ItemViewModel>(item);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ItemViewModel>> GetItemAsync()
        {
            try
            {
                var items = await _context.Items.ToListAsync();
                return _mapper.Map<List<ItemViewModel>>(items);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> RemoveItemAsync(int id)
        {
            try
            {
                var item = await _context.Items.FindAsync(id);
                if(item != null)
                {
                    _context.Items.Remove(item);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
