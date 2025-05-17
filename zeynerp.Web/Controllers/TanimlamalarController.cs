using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using zeynerp.Application.DTOs.Tanimlamalar;
using zeynerp.Application.Interfaces.Tanimlamalar;
using zeynerp.Core.Entities;
using zeynerp.Core.Entities.Tanimlamalar;
using zeynerp.Web.Models.Tanimlamalar;

namespace zeynerp.Web.Controllers
{
    public class TanimlamalarController : Controller
    {
        private readonly IStokGrupService _stokGrupService;
        private readonly IStokOzellikService _stokOzellikService;
        private readonly IBirimService _birimService;
        private readonly IStokService _stokService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public TanimlamalarController(IStokGrupService stokGrupService,
            IStokOzellikService stokOzellikService,
            IBirimService birimService,
            IStokService stokService,
            UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {
            _stokGrupService = stokGrupService;
            _stokOzellikService = stokOzellikService;
            _birimService = birimService;
            _stokService = stokService;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
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

        public IActionResult Stoklar()
        {
            return View();
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

        [HttpPost]
        public async Task<IActionResult> StokEkle([FromForm] StokViewModel model)
        {
            if (ModelState.IsValid)
            {
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
    }
}