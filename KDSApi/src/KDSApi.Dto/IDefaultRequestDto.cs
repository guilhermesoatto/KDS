using System;
using Tnf.Dto;

namespace KDSApi.Dto
{
    public interface IDefaultRequestDto : IRequestDto
    {
        Guid Id { get; set; }
    }
}
