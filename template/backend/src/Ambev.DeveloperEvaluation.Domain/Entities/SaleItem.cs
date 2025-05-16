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

        /// <summary>
        /// Calculates the discount based on quantity and updates the total amount.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when quantity or unit price is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when quantity exceeds the maximum limit.</exception>
        public void CalculateDiscount()
        {
            if (Quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.", nameof(Quantity));

            if (UnitPrice <= 0)
                throw new ArgumentException("Unit price must be greater than zero.", nameof(UnitPrice));

            if (Quantity > 20)
                throw new InvalidOperationException("Cannot sell more than 20 identical items.");

            decimal subtotal = Quantity * UnitPrice;
            decimal discountPercentage = 0;

            if (Quantity >= 10)
                discountPercentage = 0.20m; // 20% discount for 10-20 items
            else if (Quantity >= 4)
                discountPercentage = 0.10m; // 10% discount for 4-9 items

            Discount = subtotal * discountPercentage;
            TotalAmount = subtotal - Discount;
        }
    }
}
