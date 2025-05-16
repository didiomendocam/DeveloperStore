using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Branchs.DeleteBranch;

public class DeleteBranchCommand : IRequest<DeleteBranchResult>
{
    public Guid Id { get; set; }
}
