using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Reports.Queries.GetSalesReport;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Reports.SalesReport;

/// <summary>
/// Profile for mapping between request/response models and application models
/// </summary>
public class SalesReportProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for sales report feature
    /// </summary>
    public SalesReportProfile()
    {
        CreateMap<SalesReportRequest, GetSalesReportQuery>();
        CreateMap<GetSalesReportResult, SalesReportResponse>();
        CreateMap<SalesGroupResult, SalesGroup>();
        CreateMap<TopProductResult, TopProduct>();
        CreateMap<TopCustomerResult, TopCustomer>();
    }
} 