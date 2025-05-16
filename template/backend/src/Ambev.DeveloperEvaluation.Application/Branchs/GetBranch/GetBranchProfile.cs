using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;

public class GetBranchProfile : Profile
{
    public GetBranchProfile()
    {
        CreateMap<Branch, GetBranchResult>();
    }
}
