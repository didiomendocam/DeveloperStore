using System;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Customer : BaseEntity
    {
        /// <summary>
        /// Full name of the customer.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Document number of the customer (CPF or CNPJ).
        /// </summary>
        public string Document { get; set; }

        /// <summary>
        /// Contact information of the customer (e.g., phone or email).
        /// </summary>
        public string Contact { get; set; }
    }
}
