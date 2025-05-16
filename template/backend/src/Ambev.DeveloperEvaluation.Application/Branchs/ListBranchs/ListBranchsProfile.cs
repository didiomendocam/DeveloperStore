using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Branchs.ListBranchs;

public class ListBranchsProfile : Profile
{
    public ListBranchsProfile()
    {
        CreateMap<Branch, BranchDto>();
    }
}
