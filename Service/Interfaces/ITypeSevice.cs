using Service.ViewModel;

namespace Service.Interfaces
{
    public interface ITypeSevice
    {
        Task<List<TypeViewModel>> GetallTypesAsync();
        Task<TypeViewModel>AddTypeAsync(TypeViewModel typeModel);
        Task<TypeViewModel>UpdateTypeAsync(TypeViewModel typeModel, int id);
        Task<bool>DeleteTypeAsync(int id);
    }
}
