using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using zeynerp.Application.Interfaces.Tanimlamalar;
using zeynerp.Web.Models.SatinAlmaYonetimi;
using zeynerp.Web.Models.Tanimlamalar;

namespace zeynerp.Web.Controllers
{
    public class SatinalmaYonetimiController : Controller
    {
        private readonly IStokGrupService _stokGrupService;
        private readonly IStokOzellikService _stokOzellikService;
        private readonly IStokService _stokService;
        private readonly IMapper _mapper;

        public SatinalmaYonetimiController(IStokGrupService stokGrupService, IStokOzellikService stokOzellikService, IStokService stokService, IMapper mapper)
        {
            _stokGrupService = stokGrupService;
            _stokOzellikService = stokOzellikService;
            _stokService = stokService;
            _mapper = mapper;
        }

        public IActionResult MalzemeTalepler()
        {
            return View();
        }

        public async Task<IActionResult> MalzemeTalepEkle()
        {
            MalzemeTaleplerViewModel malzemeTaleplerViewModel = new MalzemeTaleplerViewModel
            {
                StokGrups = _mapper.Map<IReadOnlyList<StokGrupViewModel>>(await _stokGrupService.GetStokGrupsAsync()),
                StokOzelliks = _mapper.Map<IReadOnlyList<StokOzellikViewModel>>(await _stokOzellikService.StokOzelliklerAsync()),
                Stoks = _mapper.Map<IReadOnlyList<StokViewModel>>(await _stokService.GetStoklarAsync())
            };
            return View(malzemeTaleplerViewModel);
        }

        public IActionResult MalzemeTalepleri()
        {
            return View();
        }
    }
}