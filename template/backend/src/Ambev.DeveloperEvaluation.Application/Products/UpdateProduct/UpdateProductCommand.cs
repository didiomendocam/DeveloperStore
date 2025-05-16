using MediatR;
using System;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

public class UpdateProductCommand : IRequest<UpdateProductResult>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? ProductCode { get; set; }
    public decimal UnitPrice { get; set; }
    public ProductStatus Status { get; set; }
}
