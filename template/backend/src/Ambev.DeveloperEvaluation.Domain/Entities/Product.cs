using System;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Product : BaseEntity
    {
        /// <summary>
        /// Name of the product.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Unique code identifying the product.
        /// </summary>
        public string? ProductCode { get; set; }

        /// <summary>
        /// Unit price of the product.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Status of the product.
        /// </summary>
        public ProductStatus Status { get; set; }
    }
}
