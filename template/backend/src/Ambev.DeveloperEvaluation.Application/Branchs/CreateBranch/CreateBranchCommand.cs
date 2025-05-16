using MediatR;
using System;
using Ambev.DeveloperEvaluation.Domain.Enums;

// Comando para criar uma filial
namespace Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch
{
    public class CreateBranchCommand : IRequest<CreateBranchResult>
    {
        public string? Name { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public string? BranchCode { get; set; } = string.Empty;
        public BranchStatus Status { get; set; }
    }
}
