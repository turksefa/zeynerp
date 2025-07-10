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

        public async Task<IReadOnlyList<MalzemeTalepleriDto>> GetMalzemeTalepleriAsync()
        {
            var malzemeTalepleriDtos = _mapper.Map<IReadOnlyList<MalzemeTalepleriDto>>(await _tenantUnitOfWork.MalzemeTalepleriRepository.GetMalzemeTalepleriAsync());
            return malzemeTalepleriDtos;
        }

        public async Task<IReadOnlyList<MalzemeTalepleriDto>> GetMalzemeTalepleriByCariYetkiliIdAsync(int id)
        {
            var malzemeTalepleri = _mapper.Map<IReadOnlyList<MalzemeTalepleriDto>>(await _tenantUnitOfWork.MalzemeTalepleriRepository.GetMalzemeTalepleriByCariYetkiliIdAsync(id));
            return malzemeTalepleri;
        }

        public async Task<(bool Success, string Message)> MalzemeTalepleriOlusturAsync(MalzemeTalepleriDto malzemeTalepleriDto)
        {
            var malzemeTalep = await _tenantUnitOfWork.MalzemeTalepRepository.GetMalzemeTalepByIdAsync(malzemeTalepleriDto.MalzemeTalepId);
            malzemeTalep.Durum = 1;
            await _tenantUnitOfWork.MalzemeTalepleriRepository.AddAsync(_mapper.Map<MalzemeTalepleri>(malzemeTalepleriDto));
            await _tenantUnitOfWork.MalzemeTalepRepository.UpdateAsync(malzemeTalep);
            return (true, "Malzeme talepleri oluşturuldu.");
        }

        public async Task<(bool Success, string Message)> MalzemeTalepleriGuncelleAsync(List<MalzemeTalepleriDto> malzemeTalepleriDtos)
        {
            for (int i = 0; i < malzemeTalepleriDtos.Count; i++)
            {
                var malzemeTalepleri = await _tenantUnitOfWork.MalzemeTalepleriRepository.GetMalzemeTalepleriByIdAsync(malzemeTalepleriDtos[i].Id);

                if (malzemeTalepleriDtos[i].Mevcut == true)
                {
                    malzemeTalepleri.Boyut1 = malzemeTalepleriDtos[i].Boyut1;
                    malzemeTalepleri.Boyut2 = malzemeTalepleriDtos[i].Boyut2;
                    malzemeTalepleri.Boyut3 = malzemeTalepleriDtos[i].Boyut3;
                    malzemeTalepleri.Boyut4 = malzemeTalepleriDtos[i].Boyut4;
                    malzemeTalepleri.BirimId = malzemeTalepleriDtos[i].BirimId;
                    malzemeTalepleri.BirimSayisi = malzemeTalepleriDtos[i].BirimSayisi;
                    malzemeTalepleri.BirimFiyat = malzemeTalepleriDtos[i].BirimFiyat;
                    malzemeTalepleri.KdvId = malzemeTalepleriDtos[i].KdvId;
                    malzemeTalepleri.Tutar = malzemeTalepleriDtos[i].Tutar;
                    malzemeTalepleri.ParaBirimId = malzemeTalepleriDtos[0].ParaBirimId;
                    malzemeTalepleri.OdemeVadeId = malzemeTalepleriDtos[0].OdemeVadeId;
                    malzemeTalepleri.TeslimatAdresId = malzemeTalepleriDtos[0].TeslimatAdresId;
                    malzemeTalepleri.TeslimatTarih = malzemeTalepleriDtos[0].TeslimatTarih;
                    malzemeTalepleri.TeslimatNot = malzemeTalepleriDtos[0].TeslimatNot;
                    malzemeTalepleri.Status = true;
                    malzemeTalepleri.Mevcut = true;

                    await _tenantUnitOfWork.MalzemeTalepleriRepository.UpdateAsync(malzemeTalepleri);
                }
                else if (malzemeTalepleriDtos[i].Mevcut == false)
                {
                    malzemeTalepleri.BirimId = null;
                    malzemeTalepleri.BirimSayisi = null;
                    malzemeTalepleri.BirimFiyat = null;
                    malzemeTalepleri.KdvId = null;
                    malzemeTalepleri.Tutar = 0;
                    malzemeTalepleri.Status = true;
                    malzemeTalepleri.Mevcut = false;

                    await _tenantUnitOfWork.MalzemeTalepleriRepository.UpdateAsync(malzemeTalepleri);
                }                
            }
            return (true, "");
        }
    }
}