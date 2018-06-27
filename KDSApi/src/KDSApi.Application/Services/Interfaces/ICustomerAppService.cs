﻿using KDSApi.Dto;
using KDSApi.Dto.Customer;
using System;
using System.Threading.Tasks;
using Tnf.Application.Services;
using Tnf.Dto;

namespace KDSApi.Application.Services.Interfaces
{
    public interface ICustomerAppService : IApplicationService
    {
        Task<IListDto<CustomerDto>> GetAllAsync(CustomerRequestAllDto request);
        Task<CustomerDto> GetAsync(DefaultRequestDto request);
        Task<CustomerDto> CreateAsync(CustomerDto customerDto);
        Task<CustomerDto> UpdateAsync(Guid id, CustomerDto customerDto);
        Task DeleteAsync(Guid id);
    }
}
