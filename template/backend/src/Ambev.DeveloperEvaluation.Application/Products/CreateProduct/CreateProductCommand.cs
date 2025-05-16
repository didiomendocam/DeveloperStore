using MediatR;
using System;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Command for creating a new product.
/// </summary>
public class CreateProductCommand : IRequest<CreateProductResult>
{
    public string? Name { get; set; }
    public string? ProductCode { get; set; }
    public decimal UnitPrice { get; set; }
    public ProductStatus Status { get; set; }
}
