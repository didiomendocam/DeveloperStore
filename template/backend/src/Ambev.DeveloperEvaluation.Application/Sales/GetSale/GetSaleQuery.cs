using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleQuery : IRequest<GetSaleResult>
{
    public Guid Id { get; set; }
}
