using Service.Enum;

namespace Service.ViewModel
{
    public class TypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public IncomeOrExpenditureEnum IncomeOrExpenditureEnum { get; set; }
    }
}
