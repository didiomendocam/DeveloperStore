using System;
using System.Collections.Generic;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity, IComparable<BaseEntity>
    {
        public string? SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public Guid BranchId { get; set; }
        public Branch? Branch { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
        public ICollection<SaleItem>? Items { get; set; } // Fix: Added the missing "Items" property  
        public SaleStatus Status { get; set; }
    }
}
