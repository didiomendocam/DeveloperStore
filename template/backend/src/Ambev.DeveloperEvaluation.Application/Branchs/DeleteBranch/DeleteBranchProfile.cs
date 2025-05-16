using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Branchs.DeleteBranch;

public class DeleteBranchProfile : Profile
{
    public DeleteBranchProfile()
    {
        CreateMap<Branch, DeleteBranchResult>();
    }
}
