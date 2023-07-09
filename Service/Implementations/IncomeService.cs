using AutoMapper;
using Domain.EntityModel;
using Microsoft.EntityFrameworkCore;
using Service.AppDb;
using Service.Interfaces;
using Service.ViewModel;

namespace Service.Implementations
{
    public class IncomeService : IIncomeService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public IncomeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IncomeViewModel> AddIncomeAsync(IncomeViewModel incomeModel)
        {
            try
            {
                var income = _mapper.Map<Income>(incomeModel);
                await _context.Incomes.AddAsync(income);
                await _context.SaveChangesAsync();
                return _mapper.Map<IncomeViewModel>(income);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> DeleteIncomeAsync(int id)
        {
            try
            {
                var income = await _context.Incomes.FindAsync(id);
                if(income != null)
                {
                    _context.Incomes.Remove(income);
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

        public async Task<List<IncomeViewModel>> GetAllIncomeAsync()
        {
            try
            {
                var incomes = await _context.Incomes
                .Include(x => x.IncomeOrExpenditureType)
                .ToListAsync();
                return _mapper.Map<List<IncomeViewModel>>(incomes);
            }
            catch (Exception ex)
            {
                return new List<IncomeViewModel>();
            }
        }

        public async Task<IncomeViewModel> UpdateIncomeAsync(IncomeViewModel incomeModel, int id)
        {
            try
            {
                var income = await _context.Incomes.FindAsync(id);
                if (income != null)
                {
                    var updateIncome = _mapper.Map<IncomeViewModel, Income>(incomeModel, income);
                    _context.Update(updateIncome);
                    await _context.SaveChangesAsync();
                    return _mapper.Map<IncomeViewModel>(updateIncome);
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
