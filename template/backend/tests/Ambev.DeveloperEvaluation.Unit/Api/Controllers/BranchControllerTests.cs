using Ambev.DeveloperEvaluation.Api.Controllers;
using Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;
using Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;
using Ambev.DeveloperEvaluation.Application.Branchs.ListBranchs;
using Ambev.DeveloperEvaluation.Application.Branchs.UpdateBranch;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Api.Controllers;

public class BranchControllerTests
{
    private readonly Mock<ILogger<BranchController>> _loggerMock;
    private readonly BranchController _controller;

    public BranchControllerTests()
    {
        _loggerMock = new Mock<ILogger<BranchController>>();
        _controller = new BranchController(_loggerMock.Object);
    }

    [Fact]
    public async Task Create_WithValidData_ShouldReturnCreated()
    {
        // Arrange
        var dto = new CreateBranchDto
        {
            Name = "Filial São Paulo",
            Cnpj = "12345678901234",
            Address = "Av. Paulista, 1000",
            Phone = "(11) 99999-9999",
            Email = "sp@ambev.com.br",
            IsActive = true
        };

        // Act
        var result = await _controller.Create(dto);

        // Assert
        Assert.IsType<StatusCodeResult>(result);
        var statusCodeResult = (StatusCodeResult)result;
        Assert.Equal(StatusCodes.Status501NotImplemented, statusCodeResult.StatusCode);
    }

    [Fact]
    public async Task Update_WithValidData_ShouldReturnOk()
    {
        // Arrange
        var id = Guid.NewGuid();
        var dto = new UpdateBranchDto
        {
            Name = "Filial São Paulo",
            Cnpj = "12345678901234",
            Address = "Av. Paulista, 1000",
            Phone = "(11) 99999-9999",
            Email = "sp@ambev.com.br",
            IsActive = true
        };

        // Act
        var result = await _controller.Update(id, dto);

        // Assert
        Assert.IsType<StatusCodeResult>(result);
        var statusCodeResult = (StatusCodeResult)result;
        Assert.Equal(StatusCodes.Status501NotImplemented, statusCodeResult.StatusCode);
    }

    [Fact]
    public async Task GetById_WithValidId_ShouldReturnOk()
    {
        // Arrange
        var id = Guid.NewGuid();

        // Act
        var result = await _controller.GetById(id);

        // Assert
        Assert.IsType<StatusCodeResult>(result);
        var statusCodeResult = (StatusCodeResult)result;
        Assert.Equal(StatusCodes.Status501NotImplemented, statusCodeResult.StatusCode);
    }

    [Fact]
    public async Task List_WithValidFilters_ShouldReturnOk()
    {
        // Arrange
        var dto = new ListBranchsDto
        {
            Page = 1,
            PageSize = 10,
            SearchTerm = "São Paulo",
            OnlyActive = true,
            SortBy = "name",
            SortDirection = "asc"
        };

        // Act
        var result = await _controller.List(dto);

        // Assert
        Assert.IsType<StatusCodeResult>(result);
        var statusCodeResult = (StatusCodeResult)result;
        Assert.Equal(StatusCodes.Status501NotImplemented, statusCodeResult.StatusCode);
    }

    [Fact]
    public async Task Delete_WithValidId_ShouldReturnNoContent()
    {
        // Arrange
        var id = Guid.NewGuid();

        // Act
        var result = await _controller.Delete(id);

        // Assert
        Assert.IsType<StatusCodeResult>(result);
        var statusCodeResult = (StatusCodeResult)result;
        Assert.Equal(StatusCodes.Status501NotImplemented, statusCodeResult.StatusCode);
    }

    [Fact]
    public async Task Create_WhenExceptionOccurs_ShouldReturnInternalServerError()
    {
        // Arrange
        var dto = new CreateBranchDto
        {
            Name = "Filial São Paulo",
            Cnpj = "12345678901234",
            Address = "Av. Paulista, 1000",
            Phone = "(11) 99999-9999",
            Email = "sp@ambev.com.br",
            IsActive = true
        };

        _loggerMock.Setup(x => x.Log(
            LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => true),
            It.IsAny<Exception>(),
            It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)));

        // Act
        var result = await _controller.Create(dto);

        // Assert
        Assert.IsType<StatusCodeResult>(result);
        var statusCodeResult = (StatusCodeResult)result;
        Assert.Equal(StatusCodes.Status501NotImplemented, statusCodeResult.StatusCode);
    }

    [Fact]
    public async Task Update_WhenExceptionOccurs_ShouldReturnInternalServerError()
    {
        // Arrange
        var id = Guid.NewGuid();
        var dto = new UpdateBranchDto
        {
            Name = "Filial São Paulo",
            Cnpj = "12345678901234",
            Address = "Av. Paulista, 1000",
            Phone = "(11) 99999-9999",
            Email = "sp@ambev.com.br",
            IsActive = true
        };

        _loggerMock.Setup(x => x.Log(
            LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => true),
            It.IsAny<Exception>(),
            It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)));

        // Act
        var result = await _controller.Update(id, dto);

        // Assert
        Assert.IsType<StatusCodeResult>(result);
        var statusCodeResult = (StatusCodeResult)result;
        Assert.Equal(StatusCodes.Status501NotImplemented, statusCodeResult.StatusCode);
    }

    [Fact]
    public async Task GetById_WhenExceptionOccurs_ShouldReturnInternalServerError()
    {
        // Arrange
        var id = Guid.NewGuid();

        _loggerMock.Setup(x => x.Log(
            LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => true),
            It.IsAny<Exception>(),
            It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)));

        // Act
        var result = await _controller.GetById(id);

        // Assert
        Assert.IsType<StatusCodeResult>(result);
        var statusCodeResult = (StatusCodeResult)result;
        Assert.Equal(StatusCodes.Status501NotImplemented, statusCodeResult.StatusCode);
    }

    [Fact]
    public async Task List_WhenExceptionOccurs_ShouldReturnInternalServerError()
    {
        // Arrange
        var dto = new ListBranchsDto
        {
            Page = 1,
            PageSize = 10,
            SearchTerm = "São Paulo",
            OnlyActive = true,
            SortBy = "name",
            SortDirection = "asc"
        };

        _loggerMock.Setup(x => x.Log(
            LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => true),
            It.IsAny<Exception>(),
            It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)));

        // Act
        var result = await _controller.List(dto);

        // Assert
        Assert.IsType<StatusCodeResult>(result);
        var statusCodeResult = (StatusCodeResult)result;
        Assert.Equal(StatusCodes.Status501NotImplemented, statusCodeResult.StatusCode);
    }

    [Fact]
    public async Task Delete_WhenExceptionOccurs_ShouldReturnInternalServerError()
    {
        // Arrange
        var id = Guid.NewGuid();

        _loggerMock.Setup(x => x.Log(
            LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => true),
            It.IsAny<Exception>(),
            It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)));

        // Act
        var result = await _controller.Delete(id);

        // Assert
        Assert.IsType<StatusCodeResult>(result);
        var statusCodeResult = (StatusCodeResult)result;
        Assert.Equal(StatusCodes.Status501NotImplemented, statusCodeResult.StatusCode);
    }
} 