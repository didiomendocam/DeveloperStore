using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;

public class GetBranchQuery : IRequest<GetBranchResult>
{
    public Guid Id { get; set; }
}
