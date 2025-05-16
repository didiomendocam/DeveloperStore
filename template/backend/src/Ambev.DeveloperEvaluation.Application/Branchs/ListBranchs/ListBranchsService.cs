using Ambev.DeveloperEvaluation.Domain.Branchs;
using Ambev.DeveloperEvaluation.Domain.Branchs.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Branchs.ListBranchs;

public class ListBranchsService
{
    private readonly IBranchRepository _branchRepository;

    public ListBranchsService(IBranchRepository branchRepository)
    {
        _branchRepository = branchRepository;
    }

    public async Task<PaginatedBranchListDto> Execute(ListBranchsDto dto)
    {
        var branches = string.IsNullOrWhiteSpace(dto.SearchTerm)
            ? await _branchRepository.GetAll()
            : await _branchRepository.GetBySearchTerm(dto.SearchTerm);

        if (dto.OnlyActive == true)
        {
            branches = branches.Where(b => b.IsActive);
        }

        var totalItems = branches.Count();
        var totalPages = (int)Math.Ceiling(totalItems / (double)dto.PageSize);
        var page = Math.Max(1, Math.Min(dto.Page, totalPages));
        var pageSize = Math.Max(1, Math.Min(dto.PageSize, 100));

        var items = branches
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(b => new BranchListItemDto
            {
                Id = b.Id,
                Name = b.Name,
                Cnpj = b.Cnpj,
                Address = b.Address,
                Phone = b.Phone,
                Email = b.Email,
                IsActive = b.IsActive
            })
            .ToList();

        return new PaginatedBranchListDto
        {
            Items = items,
            TotalItems = totalItems,
            Page = page,
            PageSize = pageSize,
            TotalPages = totalPages
        };
    }
} 