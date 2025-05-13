using System;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem : BaseEntity
    {
        /// <summary>
        /// Identifier of the sale this item belongs to.
        /// </summary>
        public Guid SaleId { get; set; }

        /// <summary>
        /// Sale entity associated with this item.
        /// </summary>
        public Sale Sale { get; set; }

        /// <summary>
        /// Identifier of the product being sold.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Product entity associated with this item.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Quantity of the product being sold.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Unit price of the product.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Discount applied to this item.
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// Total amount for this item after applying discounts.
        /// </summary>
        public decimal TotalAmount { get; set; }
    }
}
