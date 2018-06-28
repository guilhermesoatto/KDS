using KDSApi.Dto.Comanda;
using KDSApi.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tnf.Application.Services;
using Tnf.Dto;

namespace KDSApi.Application.Services.Interfaces
{
    public interface IComandaAppService : IApplicationService
    {
        Task<ComandaDto> CreateComandaAsync(ComandaDto comanda);
        Task<ComandaDto> UpdateComandaAsync(int idComanda, ComandaDto comanda);
        Task DeleteComandaAsync(int idComanda);
        Task<ComandaDto> GetComandaAsync(DefaultRequestDto idComanda);
        Task<IListDto<ComandaDto>> GetAllProductAsync(ComandaRequestAllDto request);
    }
}
