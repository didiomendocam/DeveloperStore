using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Branchs.UpdateBranch;

public class UpdateBranchProfile : Profile
{
    public UpdateBranchProfile()
    {
        CreateMap<UpdateBranchCommand, Branch>();
        CreateMap<Branch, UpdateBranchResult>();
    }
}
