using AutoMapper;
using Microsoft.VisualBasic;
using zeynerp.Application.DTOs.Tanimlamalar;
using zeynerp.Application.Interfaces.Tanimlamalar;
using zeynerp.Core.Entities.Tanimlamalar;
using zeynerp.Core.Interfaces;

namespace zeynerp.Application.Services.Tanimlamalar
{
    public class CariService : ICariService
    {
        private readonly ITenantUnitOfWork _tenantUnitOfWork;
        private readonly IMapper _mapper;

        public CariService(ITenantUnitOfWork tenantUnitOfWork, IMapper mapper)
        {
            _tenantUnitOfWork = tenantUnitOfWork;
            _mapper = mapper;
        }

        public async Task<(bool Success, string Message)> CariOlusturAsync(CariDto cariDto)
        {
            var cari = _mapper.Map<Cari>(cariDto);

            if (cariDto.CariYetkiliDtos.Count > 0)
                cari.CariYetkililer = _mapper.Map<ICollection<CariYetkili>>(cariDto.CariYetkiliDtos);

            if (cariDto.TeslimatAdresDtos.Count > 0)
                cari.TeslimatAdresler = _mapper.Map<ICollection<TeslimatAdres>>(cariDto.TeslimatAdresDtos);

            if (cariDto.SelectedCariTurIds.Count() > 0)
            {
                foreach (var cariTurId in cariDto.SelectedCariTurIds)
                {
                    var cariTur = await _tenantUnitOfWork.CariTurRepository.GetCariTurByIdAsync(cariTurId);
                    cari.CariTurler.Add(cariTur);
                }
            }

            await _tenantUnitOfWork.CariRepository.AddAsync(_mapper.Map<Cari>(cariDto));
            return (true, "Cari oluşturuldu.");
        }

        public Task<IReadOnlyList<CariDto>> GetCarilerAsync()
        {
            throw new NotImplementedException();
        }        
    }
}