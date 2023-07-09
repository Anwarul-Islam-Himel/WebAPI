﻿namespace Service.ViewModel
{
    public class IncomeViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? VoucerNumber { get; set; }
        public double Amount { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? IncomeTypeName { get; set; }
        public int? IncomeTypeId { get; set; }
    }
}