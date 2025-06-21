using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using zeynerp.Application.DTOs.Tanimlamalar;
using zeynerp.Application.Interfaces.Tanimlamalar;
using zeynerp.Core.Entities;
using zeynerp.Core.Entities.Tanimlamalar;
using zeynerp.Web.Models;
using zeynerp.Web.Models.Tanimlamalar;

namespace zeynerp.Web.Controllers
{
    public class TanimlamalarController : Controller
    {
        private readonly IStokGrupService _stokGrupService;
        private readonly IStokOzellikService _stokOzellikService;
        private readonly IBirimService _birimService;
        private readonly IStokService _stokService;
        private readonly ICariTurService _cariTurService;
        private readonly ICariService _cariService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public TanimlamalarController(IStokGrupService stokGrupService,
            IStokOzellikService stokOzellikService,
            IBirimService birimService,
            IStokService stokService,
            ICariTurService cariTurService,
            ICariService cariService,
            UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {
            _stokGrupService = stokGrupService;
            _stokOzellikService = stokOzellikService;
            _birimService = birimService;
            _stokService = stokService;
            _cariTurService = cariTurService;
            _cariService = cariService;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GenelTanimlar()
        {
            return View();
        }

        public async Task<IActionResult> CariTanimlar()
        {
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }

            IReadOnlyList<CariViewModel> cariViewModel = _mapper.Map<IReadOnlyList<CariViewModel>>(await _cariService.GetCarilerAsync());

            return View(cariViewModel);
        }

        public async Task<IActionResult> CariEkle()
        {
            CariViewModel cariViewModel = new CariViewModel
            {
                CariTurViewModels = _mapper.Map<IReadOnlyList<CariTurViewModel>>(await _cariTurService.GetCariTurlerAsync())
            };
            return View(cariViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CariEkle([FromForm] CariViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cariDto = new CariDto
                {
                    Adi = model.Adi,
                    KisaAdi = model.KisaAdi,
                    Telefon = model.Telefon,
                    Fax = model.Fax,
                    EPosta = model.EPosta,
                    VergiDairesi = model.VergiDairesi,
                    VergiNumarasi = model.VergiNumarasi,
                    FaturaAdresi = model.FaturaAdresi,
                    SelectedCariTurIds = model.SelectedCariTurIds,
                    CariYetkiliDtos = _mapper.Map<ICollection<CariYetkiliDto>>(model.CariYetkiliViewModels),
                    TeslimatAdresDtos = _mapper.Map<ICollection<TeslimatAdresDto>>(model.TeslimatAdresViewModels)
                };

                var result = await _cariService.CariOlusturAsync(_mapper.Map<CariDto>(cariDto));
                if (result.Success)
                {
                    TempData["SuccessMessage"] = result.Message;
                    return RedirectToAction("CariTanimlar");
                }
            }

            return View(model);
        }

        public async Task<IActionResult> CariGuncelle([FromRoute] int id)
        {
            CariViewModel cariViewModel = _mapper.Map<CariViewModel>(await _cariService.GetCariByIdAsync(id));
            foreach (var cariTur in cariViewModel.CariTurViewModels)
            {
                cariViewModel.SelectedCariTurIds.Add(cariTur.Id);
            }
            cariViewModel.CariTurViewModels = _mapper.Map<IReadOnlyList<CariTurViewModel>>(await _cariTurService.GetCariTurlerAsync());
            return View(cariViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CariGuncelle([FromForm] CariViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cariDto = new CariDto
                {
                    Id = model.Id,
                    Adi = model.Adi,
                    KisaAdi = model.KisaAdi,
                    Telefon = model.Telefon,
                    Fax = model.Fax,
                    EPosta = model.EPosta,
                    VergiDairesi = model.VergiDairesi,
                    VergiNumarasi = model.VergiNumarasi,
                    FaturaAdresi = model.FaturaAdresi,
                    SelectedCariTurIds = model.SelectedCariTurIds,
                    CariYetkiliDtos = _mapper.Map<ICollection<CariYetkiliDto>>(model.CariYetkiliViewModels),
                    TeslimatAdresDtos = _mapper.Map<ICollection<TeslimatAdresDto>>(model.TeslimatAdresViewModels)
                };

                var result = await _cariService.CariGuncelleAsync(_mapper.Map<CariDto>(cariDto));
                if (result.Success)
                {
                    TempData["SuccessMessage"] = result.Message;
                    return RedirectToAction("CariTanimlar");
                }
            }

            return View(model);
        }

        public async Task<IActionResult> CariTurTanimlar()
        {
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }

            return View(_mapper.Map<IReadOnlyList<CariTurViewModel>>(await _cariTurService.GetCariTurlerAsync()));
        }

        public IActionResult CariTurEkle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CariTurEkle([FromForm] List<CariTurViewModel> model)
        {
            if (ModelState.IsValid)
            {
                model.ForEach(item => item.Status = Status.Aktif);

                var result = await _cariTurService.CariTurOlusturAsync(_mapper.Map<IReadOnlyList<CariTurDto>>(model));
                if (result.Success)
                {
                    TempData["SuccessMessage"] = result.Message;
                    return RedirectToAction("CariTurTanimlar");
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CariTurGuncelle([FromForm] CariTurViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _cariTurService.CariTurGuncelleAsync(_mapper.Map<CariTurDto>(model));
                if (result.Success)
                {
                    TempData["SuccessMessage"] = result.Message;
                    return RedirectToAction("CariTurTanimlar");
                }
            }

            return View(model);
        }

        public IActionResult StokTanimlar()
        {
            return View();
        }

        public async Task<IActionResult> UrunGruplar()
        {
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }

            var stokGrups = _mapper.Map<IReadOnlyList<StokGrupViewModel>>(await _stokGrupService.GetStokGrupsAsync());
            return View(stokGrups);
        }

        public IActionResult UrunGrupEkle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UrunGrupEkle([FromForm] List<StokGrupViewModel> model)
        {
            if (ModelState.IsValid)
            {
                model.ForEach(item => item.Status = Status.Aktif);

                var result = await _stokGrupService.CreateStokGrupAsync(_mapper.Map<IReadOnlyList<StokGrupDto>>(model));
                if (result.Success)
                {
                    TempData["SuccessMessage"] = result.Message;
                    return RedirectToAction("UrunGruplar");
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UrunGrupGuncelle([FromForm] StokGrupViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _stokGrupService.UpdateStokGrupAsync(_mapper.Map<StokGrupDto>(model));
                if (result.Success)
                {
                    TempData["SuccessMessage"] = result.Message;
                    return RedirectToAction("UrunGruplar");
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Stoklar()
        {
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }

            var stoks = _mapper.Map<IReadOnlyList<StokViewModel>>(await _stokService.GetStoklarAsync());
            return View(stoks);
        }

        public async Task<IActionResult> StokEkle()
        {
            StokViewModel stokViewModel = new StokViewModel
            {
                StokGrups = _mapper.Map<IReadOnlyList<StokGrupViewModel>>(await _stokGrupService.GetStokGrupsAsync()),
                Birims = _mapper.Map<IReadOnlyList<BirimViewModel>>(await _birimService.BirimlerAsync()),
                Users = _userManager.Users.ToList(),
            };

            return View(stokViewModel);
        }

        public async Task<IActionResult> StokGuncelle([FromRoute] int id)
        {
            StokViewModel stokViewModel = _mapper.Map<StokViewModel>(await _stokService.GetStokByIdAsync(id));

            stokViewModel.StokGrups = _mapper.Map<IReadOnlyList<StokGrupViewModel>>(await _stokGrupService.GetStokGrupsAsync());
            stokViewModel.Birims = _mapper.Map<IReadOnlyList<BirimViewModel>>(await _birimService.BirimlerAsync());
            stokViewModel.Users = _userManager.Users.ToList();

            return View(stokViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> StokEkle([FromForm] StokViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Status = Status.Aktif;
                var result = await _stokService.StokOlusturAsync(_mapper.Map<StokDto>(model));
                if (result.Success)
                {
                    TempData["SuccessMessage"] = result.Message;
                    return RedirectToAction("Stoklar");
                }
            }

            return View(model);
        }

        public async Task<IActionResult> StokOzellikler()
        {
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }

            var stokOzellikler = _mapper.Map<IReadOnlyList<StokOzellikViewModel>>(await _stokOzellikService.StokOzelliklerAsync());
            return View(stokOzellikler);
        }

        public IActionResult StokOzellikEkle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> StokOzellikEkle([FromForm] List<StokOzellikViewModel> model)
        {
            if (ModelState.IsValid)
            {
                model.ForEach(item => item.Status = Status.Aktif);

                var result = await _stokOzellikService.StokOzellikOlusturAsync(_mapper.Map<IReadOnlyList<StokOzellikDto>>(model));
                if (result.Success)
                {
                    TempData["SuccessMessage"] = result.Message;
                    return RedirectToAction("StokOzellikler");
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> StokOzellikGuncelle([FromForm] StokOzellikViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _stokOzellikService.StokOzellikGuncelleAsync(_mapper.Map<StokOzellikDto>(model));
                if (result.Success)
                {
                    TempData["SuccessMessage"] = result.Message;
                    return RedirectToAction("StokOzellikler");
                }
            }

            return View(model);
        }

        public IActionResult MuhasebeTanimlar()
        {
            return View();
        }

        public async Task<IActionResult> Birimler()
        {
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }

            var birimler = _mapper.Map<IReadOnlyList<BirimViewModel>>(await _birimService.BirimlerAsync());
            return View(birimler);
        }

        public IActionResult BirimEkle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BirimEkle([FromForm] List<BirimViewModel> model)
        {
            if (ModelState.IsValid)
            {
                model.ForEach(item => item.Status = Status.Aktif);

                var result = await _birimService.BirimOlusturAsync(_mapper.Map<IReadOnlyList<BirimDto>>(model));
                if (result.Success)
                {
                    TempData["SuccessMessage"] = result.Message;
                    return RedirectToAction("Birimler");
                }
            }

            return View(model);
        }

        public async Task<IActionResult> BirimGuncelle([FromForm] BirimViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _birimService.BirimGuncelleAsync(_mapper.Map<BirimDto>(model));
                if (result.Success)
                {
                    TempData["SuccessMessage"] = result.Message;
                    return RedirectToAction("Birimler");
                }
            }

            return View(model);
        }

        public IActionResult Test()
        {
            return View();
        }
    }
}