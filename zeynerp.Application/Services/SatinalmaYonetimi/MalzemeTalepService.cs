using AutoMapper;
using zeynerp.Application.DTOs.SatinalmaYonetimi;
using zeynerp.Application.Interfaces.SatinalmaYonetimi;
using zeynerp.Core.Entities.SatinalmaYonetimi;
using zeynerp.Core.Interfaces;

namespace zeynerp.Application.Services.SatinalmaYonetimi
{
    public class MalzemeTalepService : IMalzemeTalepService
    {
        private readonly ITenantUnitOfWork _tenantUnitOfWork;
        private readonly IMapper _mapper;

        public MalzemeTalepService(ITenantUnitOfWork tenantUnitOfWork, IMapper mapper)
        {
            _tenantUnitOfWork = tenantUnitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IReadOnlyList<MalzemeTalepDto>> MalzemeTaleplerAsync() =>
            _mapper.Map<IReadOnlyList<MalzemeTalepDto>>(await _tenantUnitOfWork.MalzemeTalepRepository.GetMalzemeTaleplerAsync());

        public async Task<(bool Success, string Message)> MalzemeTalepOlusturAsync(IReadOnlyList<MalzemeTalepDto> malzemeTalepDtos)
        {
            await _tenantUnitOfWork.MalzemeTalepRepository.AddRangeAsync(_mapper.Map<IReadOnlyList<MalzemeTalep>>(malzemeTalepDtos));
            return (true, "Malzeme talep oluşturuldu.");
        }
    }
}