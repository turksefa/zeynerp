using AutoMapper;
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

        public async Task<IReadOnlyList<CariDto>> GetCarilerAsync() => _mapper.Map<IReadOnlyList<CariDto>>(await _tenantUnitOfWork.CariRepository.GetCarilerAsync());

        public async Task<CariDto> GetCariByIdAsync(int id) => _mapper.Map<CariDto>(await _tenantUnitOfWork.CariRepository.GetCariByIdAsync(id));

        public async Task<(bool Success, string Message)> CariOlusturAsync(CariDto cariDto)
        {
            List<CariTur> cariTurs = new List<CariTur>();
            if (cariDto.SelectedCariTurIds.Count() > 0)
            {
                foreach (var cariTurId in cariDto.SelectedCariTurIds)
                {
                    cariTurs.Add(await _tenantUnitOfWork.CariTurRepository.GetCariTurByIdAsync(cariTurId));
                }
            }

            var cari = new Cari
            {
                Adi = cariDto.Adi,
                KisaAdi = cariDto.KisaAdi,
                Telefon = cariDto.Telefon,
                Fax = cariDto.Fax,
                EPosta = cariDto.EPosta,
                VergiDairesi = cariDto.VergiDairesi,
                VergiNumarasi = cariDto.VergiNumarasi,
                FaturaAdresi = cariDto.FaturaAdresi,
                CariYetkililer = _mapper.Map<ICollection<CariYetkili>>(cariDto.CariYetkiliDtos),
                TeslimatAdresler = _mapper.Map<ICollection<TeslimatAdres>>(cariDto.TeslimatAdresDtos),
            };
            await _tenantUnitOfWork.CariRepository.AddAsync(cari);

            cari.CariTurler = cariTurs;
            await _tenantUnitOfWork.CariRepository.UpdateAsync(cari);

            return (true, "Cari oluşturuldu.");
        }

        public async Task<(bool Success, string Message)> CariGuncelleAsync(CariDto cariDto)
        {
            await _tenantUnitOfWork.CariRepository.DeleteCariTurlerByCariIdAsync(cariDto.Id);

            var cari = _mapper.Map<Cari>(cariDto);

            foreach (var cariTurId in cariDto.SelectedCariTurIds)
            {
                cari.CariTurler.Add(await _tenantUnitOfWork.CariTurRepository.GetCariTurByIdAsync(cariTurId));
            }

            await _tenantUnitOfWork.CariRepository.UpdateAsync(cari);

            return (true, $"{cariDto.Adi} cari güncelleştirildi.");
        }
    }
}