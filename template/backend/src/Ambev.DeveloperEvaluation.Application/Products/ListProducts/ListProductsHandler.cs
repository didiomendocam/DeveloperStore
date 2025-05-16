using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProducts;

public class ListProductsHandler : IRequestHandler<ListProductsQuery, ListProductsResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ListProductsHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ListProductsResult> Handle(ListProductsQuery query, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync(cancellationToken);
        return new ListProductsResult
        {
            Products = _mapper.Map<List<ProductDto>>(products)
        };
    }
}
