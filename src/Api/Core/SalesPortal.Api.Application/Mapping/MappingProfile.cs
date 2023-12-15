using AutoMapper;
using SalesPortal.Api.Domain.Models;
using SalesPortal.Common.Models.RequestModels;
using SalesPortal.Common.RequestModels;

namespace SalesPortal.Api.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //source --> Detination
        CreateMap<CreateEnvanterCommand, Envanter>();
        CreateMap<CreateSalesUnitCommand, SalesUnit>();
        CreateMap<CreateProductCommand, SalesProduct>();
    }
}
