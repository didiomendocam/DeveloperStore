using System;
using System.Collections.Generic;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity
    {
        /// <summary>
        /// Unique identifier for the sale.
        /// </summary>
        public string? SaleNumber { get; set; }

        /// <summary>
        /// Date and time when the sale was made.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Identifier of the customer who made the purchase.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Customer entity associated with the sale.
        /// </summary>
        public Customer? Customer { get; set; }

        /// <summary>
        /// Identifier of the branch where the sale occurred.
        /// </summary>
        public Guid BranchId { get; set; }

        /// <summary>
        /// Branch entity where the sale was made.
        /// </summary>
        public Branch? Branch { get; set; }

        /// <summary>
        /// Total amount of the sale.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Indicates whether the sale was cancelled.
        /// </summary>
        public bool IsCancelled { get; set; }

        /// <summary>
        /// Collection of items included in the sale.
        /// </summary>
        public ICollection<SaleItem>? SaleItems { get; set; }

        /// <summary>
        /// Status of the sale.
        /// </summary>
        public SaleStatus Status { get; set; }
    }
}
