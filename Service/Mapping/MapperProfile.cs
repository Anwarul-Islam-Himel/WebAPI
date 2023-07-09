using AutoMapper;
using Domain.EntityModel;
using Service.ViewModel;

namespace MauiAPI.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Income, IncomeViewModel>();
            CreateMap<IncomeViewModel, Income>();

            CreateMap<Expenditure, ExpenditureViewModel>();
            CreateMap<ExpenditureViewModel, Expenditure>();
        }
    }
}
