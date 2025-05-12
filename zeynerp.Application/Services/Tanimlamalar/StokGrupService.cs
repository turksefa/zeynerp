using AutoMapper;
using zeynerp.Application.DTOs.Tanimlamalar;
using zeynerp.Application.Interfaces.Tanimlamalar;
using zeynerp.Core.Entities.Tanimlamalar;
using zeynerp.Core.Interfaces;

namespace zeynerp.Application.Services.Tanimlamalar
{
    public class StokGrupService : IStokGrupService
    {
        private readonly ITenantUnitOfWork _tenantUnitOfWork;
        private readonly IMapper _mapper;

        public StokGrupService(ITenantUnitOfWork tenantUnitOfWork, IMapper mapper)
        {
            _tenantUnitOfWork = tenantUnitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<StokGrupDto>> GetStokGrupsAsync() => _mapper.Map<IReadOnlyList<StokGrupDto>>(await _tenantUnitOfWork.StokGrupRepository.GetAllAsync());

        public async Task<(bool Success, string Error)> CreateStokGrupAsync(IReadOnlyList<StokGrupDto> stokGrupDtos)
        {
            await _tenantUnitOfWork.StokGrupRepository.AddRangeAsync(_mapper.Map<IReadOnlyList<StokGrup>>(stokGrupDtos));
            await _tenantUnitOfWork.SaveChangesAsync();
            return (true, string.Empty);
        }
    }
}