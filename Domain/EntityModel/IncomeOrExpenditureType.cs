namespace Domain.EntityModel
{
    public class IncomeOrExpenditureType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? IncomeOrExpenditureEnum { get; set; }
    }
}
