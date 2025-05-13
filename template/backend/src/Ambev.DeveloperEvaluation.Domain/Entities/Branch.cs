using System;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Branch : BaseEntity
    {
        /// <summary>
        /// Name of the branch.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Address of the branch.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Unique code identifying the branch.
        /// </summary>
        public string BranchCode { get; set; }
    }
}
