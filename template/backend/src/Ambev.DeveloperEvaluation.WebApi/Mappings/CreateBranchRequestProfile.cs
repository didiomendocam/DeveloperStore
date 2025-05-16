using Ambev.DeveloperEvaluation.Application.Branches.CreateBranch;
using Ambev.DeveloperEvaluation.WebApi.Features.Branches.CreateBranch;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class CreateBranchRequestProfile : Profile
{
    public CreateBranchRequestProfile()
    {
        CreateMap<CreateBranchRequest, CreateBranchCommand>();
    }
}
