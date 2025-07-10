using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using zeynerp.Application.DTOs.SatinalmaYonetimi;
using zeynerp.Application.Interfaces.SatinalmaYonetimi;
using zeynerp.Application.Interfaces.Tanimlamalar;
using zeynerp.Web.Models.SatinalmaYonetimi;
using zeynerp.Web.Models.Tanimlamalar;

namespace zeynerp.Web.Controllers
{
    public class SatinalmaYonetimiController : Controller
    {
        private readonly IMalzemeTalepService _malzemeTalepService;
        private readonly IMalzemeTalepleriService _malzemeTalepleriService;
        private readonly IStokGrupService _stokGrupService;
        private readonly IStokOzellikService _stokOzellikService;
        private readonly IStokService _stokService;
        private readonly ICariService _cariService;
        private readonly IParaBirimService _paraBirimService;
        private readonly IKDVService _kdvService;
        private readonly IOdemeVadeService _odemeVadeService;
        private readonly IBirimService _birimService;
        private readonly IMapper _mapper;

        public SatinalmaYonetimiController(
            IMalzemeTalepService malzemeTalepService,
            IMalzemeTalepleriService malzemeTalepleriService,
            IStokGrupService stokGrupService,
            IStokOzellikService stokOzellikService,
            IStokService stokService,
            ICariService cariService,
            IMapper mapper,
            IParaBirimService paraBirimService,
            IKDVService kdvService,
            IOdemeVadeService odemeVadeService,
            IBirimService birimService)
        {
            _malzemeTalepService = malzemeTalepService;
            _malzemeTalepleriService = malzemeTalepleriService;
            _stokGrupService = stokGrupService;
            _stokOzellikService = stokOzellikService;
            _stokService = stokService;
            _cariService = cariService;
            _mapper = mapper;
            _paraBirimService = paraBirimService;
            _kdvService = kdvService;
            _odemeVadeService = odemeVadeService;
            _birimService = birimService;
        }

        public async Task<IActionResult> MalzemeTalepler()
        {
            var result = _mapper.Map<IReadOnlyList<MalzemeTalepViewModel>>(await _malzemeTalepService.MalzemeTaleplerAsync());
            return View(result);
        }

        public async Task<IActionResult> MalzemeTalepEkle()
        {
            MalzemeTalepViewModel malzemeTaleplerViewModel = new MalzemeTalepViewModel
            {
                StokGrups = _mapper.Map<IReadOnlyList<StokGrupViewModel>>(await _stokGrupService.GetStokGrupsAsync()),
                StokOzelliks = _mapper.Map<IReadOnlyList<StokOzellikViewModel>>(await _stokOzellikService.StokOzelliklerAsync()),
                Stoks = _mapper.Map<IReadOnlyList<StokViewModel>>(await _stokService.GetStoklarAsync())
            };
            return View(malzemeTaleplerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> MalzemeTalepEkle([FromForm] List<MalzemeTalepViewModel> model)
        {
            if (ModelState.IsValid)
            {
                model.ForEach(m => { m.CreatedDate = DateTime.Now; });
                var result = await _malzemeTalepService.MalzemeTalepOlusturAsync(_mapper.Map<IReadOnlyList<MalzemeTalepDto>>(model));
                if (result.Success)
                {
                    TempData["SuccessMessage"] = result.Message;
                    return RedirectToAction("MalzemeTalepler");
                }
            }

            return View();
        }

        public async Task<IActionResult> MalzemeTalepleri()
        {
            MalzemeTalepleriViewModel malzemeTalepleriViewModels = new MalzemeTalepleriViewModel
            {
                MalzemeTalepViewModels = _mapper.Map<IReadOnlyList<MalzemeTalepViewModel>>(await _malzemeTalepService.MalzemeTaleplerAsync()),
                CariViewModels = _mapper.Map<IReadOnlyList<CariViewModel>>(await _cariService.GetCarilerAsync())
            };

            var malzemeTalepleriDtos = await _malzemeTalepleriService.GetMalzemeTalepleriAsync();
            foreach (var malzemeTalepDto in malzemeTalepleriDtos)
            {
                malzemeTalepleriViewModels.MalzemeTalepler.Add(new MalzemeTalepler
                {
                    CariId = malzemeTalepDto.CariId,
                    CariViewModel = _mapper.Map<CariViewModel>(malzemeTalepDto.Cari),
                    CariYetkiliId = malzemeTalepDto.CariYetkiliId,
                    CariYetkiliViewModel = _mapper.Map<CariYetkiliViewModel>(malzemeTalepDto.CariYetkili),
                    MalzemeTalepId = malzemeTalepDto.MalzemeTalepId,
                    MalzemeTalepViewModel = _mapper.Map<MalzemeTalepViewModel>(malzemeTalepDto.MalzemeTalep),
                    Status = malzemeTalepDto.Status
                });
            }
            return View(malzemeTalepleriViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> MalzemeTalepleri([FromForm] MalzemeTalepleriViewModel model)
        {
            if (ModelState.IsValid)
            {
                MalzemeTalepleriDto malzemeTalepleriDto = new MalzemeTalepleriDto();

                foreach (var malzemeTalep in model.SelectedMalzemeTalepler)
                {
                    if (malzemeTalep.IsSelected)
                    {
                        malzemeTalepleriDto.MalzemeTalepId = malzemeTalep.MalzemeTalepId;
                        foreach (var cariYetkili in model.SelectedCariCariYetkililer)
                        {
                            malzemeTalepleriDto.CariId = cariYetkili.CariId;
                            malzemeTalepleriDto.CariYetkiliId = cariYetkili.CariYetkiliId;
                            malzemeTalepleriDto.Status = false;
                            malzemeTalepleriDto.CreatedDate = DateTime.Now;

                            await _malzemeTalepleriService.MalzemeTalepleriOlusturAsync(malzemeTalepleriDto);
                        }
                    }
                }

                return RedirectToAction("MalzemeTalepleri");
            }
            return View();
        }

        public async Task<IActionResult> MalzemeTalepleriDetay([FromRoute] int id)
        {
            var MalzemeTalepleriDetayViewModel = new MalzemeTalepleriDetayViewModel()
            {
                MalzemeTalepleriViewModels = _mapper.Map<IReadOnlyList<MalzemeTalepleriViewModel>>(await _malzemeTalepleriService.GetMalzemeTalepleriByCariYetkiliIdAsync(id)),
                ParaBirimViewModels = _mapper.Map<IReadOnlyList<ParaBirimViewModel>>(await _paraBirimService.GetParaBirimlerAsync()),
                OdemeVadeViewModels = _mapper.Map<IReadOnlyList<OdemeVadeViewModel>>(await _odemeVadeService.GetOdemeVadelerAsync()),
                KDVViewModels = _mapper.Map<IReadOnlyList<KDVViewModel>>(await _kdvService.GetKDVlerAsync()),
                BirimViewModels = _mapper.Map<IReadOnlyList<BirimViewModel>>(await _birimService.BirimlerAsync()),
            };

            foreach (var malzemeTalep in MalzemeTalepleriDetayViewModel.MalzemeTalepleriViewModels)
            {
                MalzemeTalepleriDetayViewModel.TeslimatAdresViewModels = _mapper.Map<IReadOnlyList<TeslimatAdresViewModel>>(malzemeTalep.Cari.TeslimatAdresler);
            }
            return View(MalzemeTalepleriDetayViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> MalzemeTalepleriDetay([FromForm] MalzemeTalepleriDetayViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _malzemeTalepleriService.MalzemeTalepleriGuncelleAsync(_mapper.Map<List<MalzemeTalepleriDto>>(model.MalzemeTalepleriViewModels));

                return RedirectToAction("MalzemeTalepleri");
            }

            return View(model);
        }

        public IActionResult FiyatKarsilastirma()
        {
            return View();
        }
    }
}