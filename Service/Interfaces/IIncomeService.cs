using Service.ViewModel;

namespace Service.Interfaces
{
    public interface IIncomeService
    {
        Task<List<IncomeViewModel>> GetAllIncomeAsync();
        Task<IncomeViewModel>AddIncomeAsync(IncomeViewModel incomeModel);
        Task<IncomeViewModel> UpdateIncomeAsync(IncomeViewModel incomeModel, int id);
        Task<bool> DeleteIncomeAsync(int id);
    }
}
