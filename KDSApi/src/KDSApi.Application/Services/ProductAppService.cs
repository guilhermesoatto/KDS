using KDSApi.Application.Services.Interfaces;
using KDSApi.Domain.Entities;
using KDSApi.Domain.Interfaces.Services;
using KDSApi.Dto;
using KDSApi.Dto.Product;
using KDSApi.Infra.ReadInterfaces;
using System;
using System.Threading.Tasks;
using Tnf.Application.Services;
using Tnf.Dto;
using Tnf.Notifications;

namespace KDSApi.Application.Services
{
    public class ProductAppService : ApplicationService, IProductAppService
    {
        private readonly IProductDomainService _domainService;
        private readonly IProductReadRepository _readRepository;

        public ProductAppService(IProductDomainService domainService, IProductReadRepository readRepository, INotificationHandler notificationHandler)
            : base(notificationHandler)
        {
            _domainService = domainService;
            _readRepository = readRepository;
        }

        public async Task<ProductDto> CreateProductAsync(ProductDto dto)
        {
            if (!ValidateDto<ProductDto>(dto))
                return null;

            var builder = Product.Create(Notification)
                .WithDescription(dto.Description)
                .WithValue(dto.Value);

            var entity = await _domainService.InsertProductAsync(builder);

            if (Notification.HasNotification())
                return null;

            return entity.MapTo<ProductDto>();
        }

        public async Task<ProductDto> UpdateProductAsync(Guid id, ProductDto dto)
        {
            if (!ValidateDtoAndId(dto, id))
                return null;

            var builder = Product.Create(Notification)
                .WithId(id)
                .WithDescription(dto.Description)
                .WithValue(dto.Value);

            await _domainService.UpdateProductAsync(builder);

            dto.Id = id;
            return dto;
        }

        public async Task DeleteProductAsync(Guid id)
        {
            if (!ValidateId(id))
                return;

            await _domainService.DeleteProductAsync(id);
        }

        public async Task<ProductDto> GetProductAsync(DefaultRequestDto id)
        {
            if (!ValidateRequestDto(id) || !ValidateId<Guid>(id.Id))
                return null;

            var entity = await _readRepository.GetProductAsync(id);

            return entity.MapTo<ProductDto>();
        }

        public async Task<IListDto<ProductDto>> GetAllProductAsync(ProductRequestAllDto request)
            => await _readRepository.GetAllProductsAsync(request);
    }
}
