using AutoMapper;
using Domain.EntityModel;
using Microsoft.EntityFrameworkCore;
using Service.AppDb;
using Service.Interfaces;
using Service.ViewModel;

namespace Service.Implementations
{
    public class ExpenditureService : IExpenditureService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ExpenditureService(AppDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ExpenditureViewModel> AddExpenditureAsync(ExpenditureViewModel expenditureModel)
        {
            try
            {
                var expenditure = _mapper.Map<Expenditure>(expenditureModel);
                await _context.Expenditures.AddAsync(expenditure);
                await _context.SaveChangesAsync();
                return _mapper.Map<ExpenditureViewModel>(expenditure);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> DeleteExpenditureAsync(int id)
        {
            try
            {
                var expenditure = await _context.Expenditures.FindAsync(id);
                if (expenditure != null)
                {
                    _context.Expenditures.Remove(expenditure);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<ExpenditureViewModel>> GetAllExpenditureAsync()
        {
            try
            {
                var expenditures = await _context.Expenditures
                    .Include(x=>x.IncomeOrExpenditureType)
                    .ToListAsync();
                return _mapper.Map<List<ExpenditureViewModel>>(expenditures);
            }
            catch (Exception ex)
            {
                return new List<ExpenditureViewModel>();
            }
        }

        public async Task<ExpenditureViewModel> UpdateExpenditureAsync(ExpenditureViewModel expenditureModel, int id)
        {
            try
            {
                var expenditure = await _context.Expenditures.FindAsync(id);
                if(expenditure != null)
                {
                    var updateValue = _mapper.Map<ExpenditureViewModel, Expenditure>(expenditureModel, expenditure);
                    _context.Expenditures.Update(updateValue);
                    await _context.SaveChangesAsync();
                    return _mapper.Map<ExpenditureViewModel>(updateValue);
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
