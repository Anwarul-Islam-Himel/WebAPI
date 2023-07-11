using AutoMapper;
using Domain.EntityModel;
using Service.ViewModel;

namespace MauiAPI.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Income, IncomeViewModel>()
                .ForMember(dest => dest.IncomeTypeName, opt => opt.MapFrom(src => src.IncomeOrExpenditureType.Name))
                .ForMember(dest => dest.IncomeTypeId, opt => opt.MapFrom(src => src.IncomeOrExpenditureTypeId));
            CreateMap<IncomeViewModel, Income>()
                .ForMember(dest => dest.IncomeOrExpenditureTypeId, opt => opt.MapFrom(src => src.IncomeTypeId));

            CreateMap<Expenditure, ExpenditureViewModel>()
                .ForMember(dest => dest.ExpenditureTypeName, opt => opt.MapFrom(src => src.IncomeOrExpenditureType.Name))
                .ForMember(dest => dest.ExpenditureTypeId, opt => opt.MapFrom(src => src.IncomeOrExpenditureTypeId));
            CreateMap<ExpenditureViewModel, Expenditure>()
                .ForMember(dest => dest.IncomeOrExpenditureTypeId, opt => opt.MapFrom(src => src.ExpenditureTypeId));

            CreateMap<TypeViewModel, IncomeOrExpenditureType>();
            CreateMap<IncomeOrExpenditureType, TypeViewModel>();
        }
    }
}
