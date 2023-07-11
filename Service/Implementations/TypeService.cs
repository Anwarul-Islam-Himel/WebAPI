using AutoMapper;
using Domain.EntityModel;
using Microsoft.EntityFrameworkCore;
using Service.AppDb;
using Service.Interfaces;
using Service.ViewModel;

namespace Service.Implementations
{
    public class TypeService : ITypeSevice
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public TypeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<TypeViewModel> AddTypeAsync(TypeViewModel typeModel)
        {
            try
            {
                var type = _mapper.Map<IncomeOrExpenditureType>(typeModel);
                await _context.IncomeOrExpenditureTypes.AddAsync(type);
                await _context.SaveChangesAsync();
                return _mapper.Map<TypeViewModel>(type);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> DeleteTypeAsync(int id)
        {
            try
            {
                var type = await _context.IncomeOrExpenditureTypes.FindAsync(id);
                if(type != null)
                {
                    _context.IncomeOrExpenditureTypes.Remove(type);
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

        public async Task<List<TypeViewModel>> GetallTypesAsync()
        {
            try
            {
                var types = await _context.IncomeOrExpenditureTypes.ToListAsync();
                return _mapper.Map<List<TypeViewModel>>(types);
            }
            catch (Exception ex)
            {
                return new List<TypeViewModel>();
            }
        }

        public async Task<TypeViewModel> UpdateTypeAsync(TypeViewModel typeModel, int id)
        {
            try
            {
                var type = await _context.IncomeOrExpenditureTypes.FindAsync(id);
                if(type != null)
                {
                    var updateValue = _mapper.Map<TypeViewModel, IncomeOrExpenditureType>(typeModel, type);
                    _context.IncomeOrExpenditureTypes.Update(updateValue);
                    await _context.SaveChangesAsync();
                    return _mapper.Map<TypeViewModel>(updateValue);
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
