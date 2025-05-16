using MediatR;
using System;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Branchs.UpdateBranch;

public class UpdateBranchCommand : IRequest<UpdateBranchResult>
{
    public Guid Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public string? Address { get; set; } = string.Empty;
    public string? BranchCode { get; set; } = string.Empty;
    public BranchStatus Status { get; set; }
}
