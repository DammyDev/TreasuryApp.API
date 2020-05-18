using AutoMapper;
using TreasuryApp.API.Domain.Models;
using TreasuryApp.API.Domain.Models.Queries;
using TreasuryApp.API.Extensions;
using TreasuryApp.API.Resources;

namespace TreasuryApp.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();
            CreateMap<Company, CompanyResource>();

            CreateMap<Product, ProductResource>()
                .ForMember(src => src.UnitOfMeasurement,
                           opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString()));

            CreateMap<QueryResult<Product>, QueryResultResource<ProductResource>>();
        }
    }
}