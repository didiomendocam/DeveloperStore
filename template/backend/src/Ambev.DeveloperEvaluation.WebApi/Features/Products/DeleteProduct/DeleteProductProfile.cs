using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct;

public class DeleteProductProfile : Profile
{
    public DeleteProductProfile()
    {
        CreateMap<DeleteProductRequest, DeleteProductResponse>();
    }
}
