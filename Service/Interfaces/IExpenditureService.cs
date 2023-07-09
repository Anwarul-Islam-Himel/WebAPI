using Service.ViewModel;

namespace Service.Interfaces
{
    public interface IExpenditureService
    {
        Task<List<ExpenditureViewModel>> GetAllExpenditureAsync();
        Task<ExpenditureViewModel> AddExpenditureAsync(ExpenditureViewModel expenditureModel);
        Task<ExpenditureViewModel> UpdateExpenditureAsync(ExpenditureViewModel expenditureModel, int id);
        Task<bool> DeleteExpenditureAsync(int id);
    }
}
