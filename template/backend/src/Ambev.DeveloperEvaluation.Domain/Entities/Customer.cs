using System;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Customer : BaseEntity, IComparable<BaseEntity>
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public string Contact { get; set; }

        // Adicionando a propriedade IsActive para corrigir o erro CS1061  
        public bool IsActive { get; set; }
    }
}
