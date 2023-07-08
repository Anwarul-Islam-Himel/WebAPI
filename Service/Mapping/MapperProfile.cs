using AutoMapper;
using Domain.EntityModel;
using Shared.ViewModel;

namespace MauiAPI.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Item, ItemViewModel>();
            CreateMap<ItemViewModel, Item>();
        }
    }
}
