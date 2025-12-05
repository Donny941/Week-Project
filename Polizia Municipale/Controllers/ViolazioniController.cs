using Microsoft.AspNetCore.Mvc;
using Polizia_Municipale.Models.Entities;
using Polizia_Municipale.Services;
using Polizia_Municipale.ViewModels;
using System.Threading.Tasks;

namespace Polizia_Municipale.Controllers
{
    public class ViolazioniController : Controller
    {
        private readonly ViolazioniService _violazioneService;

        public ViolazioniController(ViolazioniService violazioniService)
        {
            _violazioneService = violazioniService;
        }
        public async Task<IActionResult> Index()
        {
            List<Violazione> violazioni = await _violazioneService.VediViolazioni();

            List<ViolazioneViewModel> violazioniViewModel = violazioni.Select(
                v => new ViolazioneViewModel()
                {
                    Descrizione = v.Descrizione,
                    Verbali = v.Verbali
                }
                ).ToList();

            return View(violazioniViewModel);
        }
    }
}
