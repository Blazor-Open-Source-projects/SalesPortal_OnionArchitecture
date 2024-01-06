using AutoMapper;
using SalesPortal.Api.Domain.Models;
using SalesPortal.Common.Models.Queries;
using SalesPortal.Common.Models.RequestModels;

namespace SalesPortal.Api.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //source --> Detination
        CreateMap<CreateEnvanterCommand, Envanter>().ReverseMap();
        CreateMap<CreateSalesUnitCommand, SalesUnit>().ReverseMap();
        CreateMap<CreateProductCommand, SalesProduct>()
            //.ForMember(src => src.SalesUnits, dest => dest.MapFrom(p => p.SalesUnits))
            .ReverseMap(); ;

        CreateMap<Envanter, GetEnvantersViewModel>()
            .ForMember(p => p.BrandName, src => src.MapFrom(p => p.Brand.Name));

        CreateMap<SalesProduct, GetProductViewModel>()
            .ForMember(p => p.SalesUnits, src => src.MapFrom(p => p.SalesUnits));

        CreateMap<CreateCompanyCommand, Company>();
        CreateMap<Company, LoginCompanyViewModel>();

        CreateMap<Brand, GetBrandsViewModel>()
            .ForMember(dest => dest.BrandName, src=>src.MapFrom(p=>p.Name));
        CreateMap<Category, GetCategoryViewModel>();

        CreateMap<SalesUnit, GetSalesUnitViewModel>()
            .ForMember(dest => dest.Name, src => src.MapFrom(p => p.Envanter.Name));
    }
}
