using Microsoft.AspNetCore.Mvc;
using Polizia_Municipale.Models.Entities;
using Polizia_Municipale.Services;
using Polizia_Municipale.ViewModels;
using System.Threading.Tasks;

namespace Polizia_Municipale.Controllers
{
    public class VerbaliController : Controller
    {
        private readonly VerbaliService _verbaliService;
        private readonly AnagraficaService _anagraficaService;
        private readonly ViolazioniService _violazioniService;

        public VerbaliController(
              VerbaliService verbaliService,
              AnagraficaService anagraficaService,
              ViolazioniService violazioniService)
        {
            _verbaliService = verbaliService;
            _anagraficaService = anagraficaService;
            _violazioniService = violazioniService;
        }

        public async Task<IActionResult> Index()
        {
            List<Verbale> verbali = await _verbaliService.VediVerbali();

            List<VerbaleViewModel> VerbaliViewModels = verbali.Select(
                v => new VerbaleViewModel()
                {
                    Id = v.Id,
                    DataTrascrizioneVerbale = v.DataTrascrizioneVerbale,
                    DataViolazione = v.DataViolazione,
                    DecurtamentoPunti = v.DecurtamentoPunti,
                    Importo = v.Importo,
                    NominativoAgente = v.NominativoAgente,
                    IndirizzoViolazione = v.IndirizzoViolazione,
                    AnagraficaId = v.AnagraficaId,
                    ViolazioneId = v.ViolazioneId
                }
                ).ToList();


            return View(VerbaliViewModels);
        }

        public async Task<IActionResult> Crea()
        {

            var anagrafiche = await _anagraficaService.VediAnagrafiche();
            var violazioni = await _violazioniService.VediViolazioni();


            ViewBag.Anagrafiche = anagrafiche;
            ViewBag.Violazioni = violazioni;

            return View(new VerbaleViewModel());
        }

        [HttpPost]

        public async Task<IActionResult> CreaVerbale(VerbaleViewModel verbaleViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (verbaleViewModel is not null)
                    {
                        var verbale = new Verbale
                        {
                            Id = verbaleViewModel.Id,
                            DataTrascrizioneVerbale = verbaleViewModel.DataTrascrizioneVerbale,
                            DataViolazione = verbaleViewModel.DataViolazione,
                            DecurtamentoPunti = verbaleViewModel.DecurtamentoPunti,
                            Importo = verbaleViewModel.Importo,
                            NominativoAgente = verbaleViewModel.NominativoAgente,
                            IndirizzoViolazione = verbaleViewModel.IndirizzoViolazione,
                            AnagraficaId = verbaleViewModel.AnagraficaId,
                            ViolazioneId = verbaleViewModel.ViolazioneId
                        };

                        bool salvato = await _verbaliService.CreaVerbale(verbale);

                        if (salvato)
                        {
                            TempData["SuccessMessage"] = "Verbale Creato!";
                            return RedirectToAction(nameof(Index));
                        }
                        else
                        {
                            TempData["ErrorMessage"] = "Errore Durante la Creazione!";
                            return RedirectToAction(nameof(Index));
                        }
                    }
                    return View(verbaleViewModel);

                }

                return View(verbaleViewModel);


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Si è verificato un errore: " + ex.Message);
                return View(verbaleViewModel);
            }

        }
    }
}
