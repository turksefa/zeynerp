using AutoMapper;
using zeynerp.Application.DTOs.Tanimlamalar;
using zeynerp.Application.Interfaces.Tanimlamalar;
using zeynerp.Core.Entities.Tanimlamalar;
using zeynerp.Core.Interfaces;

namespace zeynerp.Application.Services.Tanimlamalar
{
    public class OdemeVadeService : IOdemeVadeService
    {
        private readonly ITenantUnitOfWork _tenantUnitOfWork;
        private readonly IMapper _mapper;

        public OdemeVadeService(ITenantUnitOfWork tenantUnitOfWork, IMapper mapper)
        {
            _tenantUnitOfWork = tenantUnitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<OdemeVadeDto>> GetOdemeVadelerAsync() => _mapper.Map<IReadOnlyList<OdemeVadeDto>>(await _tenantUnitOfWork.OdemeVadeRepository.GetAllAsync());
        public async Task<(bool Success, string Message)> CreateOdemeVadeAsync(IReadOnlyList<OdemeVadeDto> odemeVadeDtos)
        {
            await _tenantUnitOfWork.OdemeVadeRepository.AddRangeAsync(_mapper.Map<IReadOnlyList<OdemeVade>>(odemeVadeDtos));
            return (true, "Ödeme Vadeleri oluşturuldu.");
        }        

        public async Task<(bool Success, string Message)> UpdateOdemeVadeAsync(OdemeVadeDto odemeVadeDto)
        {
            await _tenantUnitOfWork.OdemeVadeRepository.UpdateAsync(_mapper.Map<OdemeVade>(odemeVadeDto));
            return (true, "Ödeme Vadeleri güncelleştirildi.");
        }
    }
}