using AutoMapper;
using TreasuryApp.API.Domain.Models;
using TreasuryApp.API.Domain.Models.Queries;
using TreasuryApp.API.Resources;

namespace TreasuryApp.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();
            CreateMap<SaveCompanyResource, Company>();

            CreateMap<SaveProductResource, Product>()
                .ForMember(src => src.UnitOfMeasurement, opt => opt.MapFrom(src => (EUnitOfMeasurement)src.UnitOfMeasurement));

            CreateMap<ProductsQueryResource, ProductsQuery>();
        }
    }
}