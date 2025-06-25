using AutoMapper;
using zeynerp.Application.DTOs.SatinalmaYonetimi;
using zeynerp.Application.Interfaces.SatinalmaYonetimi;
using zeynerp.Core.Entities.SatinalmaYonetimi;
using zeynerp.Core.Interfaces;

namespace zeynerp.Application.Services.SatinalmaYonetimi
{
    public class MalzemeTalepleriService : IMalzemeTalepleriService
    {
        private readonly ITenantUnitOfWork _tenantUnitOfWork;
        private readonly IMapper _mapper;

        public MalzemeTalepleriService(ITenantUnitOfWork tenantUnitOfWork, IMapper mapper)
        {
            _tenantUnitOfWork = tenantUnitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IReadOnlyList<MalzemeTalepleriDto>> GetMalzemeTalepleriAsync() =>
            _mapper.Map<IReadOnlyList<MalzemeTalepleriDto>>(await _tenantUnitOfWork.MalzemeTalepleriRepository.GetMalzemeTalepleriAsync());

        public async Task<(bool Success, string Message)> MalzemeTalepleriOlusturAsync(MalzemeTalepleriDto malzemeTalepleriDto)
        {
            foreach (var cari in malzemeTalepleriDto.SelectedCariCariYetkililer)
            {
                await _tenantUnitOfWork.MalzemeTalepleriRepository.AddAsync(new MalzemeTalepleri
                {
                    CariId = cari.CariId,
                    CariYetkiliId = cari.CariYetkiliId,
                    
                });
            }

            return (true, "");
        }
    }
}