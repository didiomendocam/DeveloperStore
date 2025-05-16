using Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Branchs;

public class GetBranchDtoTests
{
    [Fact]
    public void GetBranchDto_WithValidData_ShouldSetValuesCorrectly()
    {
        // Arrange
        var id = Guid.NewGuid();
        var createdAt = DateTime.UtcNow;
        var updatedAt = DateTime.UtcNow.AddHours(1);

        var dto = new GetBranchDto
        {
            Id = id,
            Name = "Filial São Paulo",
            Cnpj = "12345678901234",
            Address = "Av. Paulista, 1000",
            Phone = "(11) 99999-9999",
            Email = "sp@ambev.com.br",
            IsActive = true,
            CreatedAt = createdAt,
            UpdatedAt = updatedAt
        };

        // Assert
        Assert.Equal(id, dto.Id);
        Assert.Equal("Filial São Paulo", dto.Name);
        Assert.Equal("12345678901234", dto.Cnpj);
        Assert.Equal("Av. Paulista, 1000", dto.Address);
        Assert.Equal("(11) 99999-9999", dto.Phone);
        Assert.Equal("sp@ambev.com.br", dto.Email);
        Assert.True(dto.IsActive);
        Assert.Equal(createdAt, dto.CreatedAt);
        Assert.Equal(updatedAt, dto.UpdatedAt);
    }

    [Fact]
    public void GetBranchDto_WithNullUpdatedAt_ShouldSetValuesCorrectly()
    {
        // Arrange
        var id = Guid.NewGuid();
        var createdAt = DateTime.UtcNow;

        var dto = new GetBranchDto
        {
            Id = id,
            Name = "Filial São Paulo",
            Cnpj = "12345678901234",
            Address = "Av. Paulista, 1000",
            Phone = "(11) 99999-9999",
            Email = "sp@ambev.com.br",
            IsActive = true,
            CreatedAt = createdAt,
            UpdatedAt = null
        };

        // Assert
        Assert.Equal(id, dto.Id);
        Assert.Equal("Filial São Paulo", dto.Name);
        Assert.Equal("12345678901234", dto.Cnpj);
        Assert.Equal("Av. Paulista, 1000", dto.Address);
        Assert.Equal("(11) 99999-9999", dto.Phone);
        Assert.Equal("sp@ambev.com.br", dto.Email);
        Assert.True(dto.IsActive);
        Assert.Equal(createdAt, dto.CreatedAt);
        Assert.Null(dto.UpdatedAt);
    }

    [Fact]
    public void GetBranchDto_WithDefaultValues_ShouldHaveCorrectDefaults()
    {
        // Arrange & Act
        var dto = new GetBranchDto();

        // Assert
        Assert.Equal(Guid.Empty, dto.Id);
        Assert.Equal(string.Empty, dto.Name);
        Assert.Equal(string.Empty, dto.Cnpj);
        Assert.Equal(string.Empty, dto.Address);
        Assert.Equal(string.Empty, dto.Phone);
        Assert.Equal(string.Empty, dto.Email);
        Assert.False(dto.IsActive);
        Assert.Equal(default, dto.CreatedAt);
        Assert.Null(dto.UpdatedAt);
    }
} 