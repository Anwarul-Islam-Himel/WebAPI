namespace Domain.EntityModel
{
    public class Expenditure
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? VoucerNumber { get; set; }
        public double Amount { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? IncomeOrExpenditureTypeId { get; set; }
        public virtual IncomeOrExpenditureType IncomeOrExpenditureType { get; set; }
    }
}
