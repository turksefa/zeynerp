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
        private readonly IStokGrupService _stokGrupService;
        private readonly IStokOzellikService _stokOzellikService;
        private readonly IStokService _stokService;
        private readonly ICariService _cariService;
        private readonly IMapper _mapper;

        public SatinalmaYonetimiController(
            IMalzemeTalepService malzemeTalepService,
            IStokGrupService stokGrupService,
            IStokOzellikService stokOzellikService,
            IStokService stokService,
            ICariService cariService,
            IMapper mapper)
        {
            _malzemeTalepService = malzemeTalepService;
            _stokGrupService = stokGrupService;
            _stokOzellikService = stokOzellikService;
            _stokService = stokService;
            _cariService = cariService;
            _mapper = mapper;
        }

        public async Task<IActionResult> MalzemeTalepler()
        {
            var result = _mapper.Map<IReadOnlyList<MalzemeTalepViewModel>>(await _malzemeTalepService.MalzemeTaleplerAsync());
            return View(_mapper.Map<IReadOnlyList<MalzemeTalepViewModel>>(await _malzemeTalepService.MalzemeTaleplerAsync()));
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
        public async Task<IActionResult> MalzemeTalepEkle([FromForm] IReadOnlyList<MalzemeTalepViewModel> model)
        {
            if (ModelState.IsValid)
            {
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
            return View(malzemeTalepleriViewModels);
        }

        [HttpPost]
        public IActionResult MalzemeTalepleri([FromForm] MalzemeTalepleriViewModel model)
        {
            return View();
        }
    }
}