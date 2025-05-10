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
        public IActionResult UrunGrupEkle([FromForm] List<StokGrupViewModel> model)
        {
            // await _stokGrupService.CreateStokGrupAsync(_mapper.Map<StokGrupDto>(model));
            return View();
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