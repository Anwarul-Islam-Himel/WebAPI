namespace Service.ViewModel
{
    public class ExpenditureViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? VoucerNumber { get; set; }
        public double Amount { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? ExpenditureTypeName { get; set; }
        public int? ExpenditureTypeId { get; set; }
    }
}
