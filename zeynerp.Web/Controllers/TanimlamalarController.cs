using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using zeynerp.Application.DTOs.Tanimlamalar;
using zeynerp.Application.Interfaces.Tanimlamalar;
using zeynerp.Web.Models.Tanimlamalar;

namespace zeynerp.Web.Controllers
{
    public class TanimlamalarController : Controller
    {
        private readonly IStokGrupService _stokGrupService;
        private readonly IMapper _mapper;

        public TanimlamalarController(IStokGrupService stokGrupService, IMapper mapper)
        {
            _stokGrupService = stokGrupService;
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
            if(!ModelState.IsValid)
                return View(model);

            var result = await _stokGrupService.CreateStokGrupAsync(_mapper.Map<IReadOnlyList<StokGrupDto>>(model));
            if(result.Success)
                return RedirectToAction("UrunGruplar");

            return View(model);
        }

        public IActionResult Urunler()
        {
            return View();
        }

        public IActionResult UrunEkle()
        {
            return View();
        }

        public IActionResult UrunOzellikler()
        {
            return View();
        }

        public IActionResult UrunOzellikEkle()
        {
            return View();
        }

        public IActionResult MuhasebeTanimlar()
        {
            return View();
        }

        public IActionResult Birimler()
        {
            return View();
        }

        public IActionResult BirimEkle()
        {
            return View();
        }
    }
}