using AutoMapper;
using KDSApi.Domain.Entities;
using KDSApi.Dto.Customer;
using KDSApi.Dto.Product;

namespace KDSApi.Infra.MapperProfiles
{
    public class KDSApiProfile : Profile
    {
        public KDSApiProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Product, ProductDto>();
        }
    }
}
