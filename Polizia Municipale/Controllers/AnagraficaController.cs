using Microsoft.AspNetCore.Mvc;
using Polizia_Municipale.Models.Entities;
using Polizia_Municipale.Services;
using Polizia_Municipale.ViewModels;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Polizia_Municipale.Controllers
{
    public class AnagraficaController : Controller
    {
        private readonly AnagraficaSevice _anagraficaService;



        public IActionResult Crea()
        {
            return View(new AnagraficaViewModel());
        }
        public AnagraficaController(AnagraficaSevice anagraficaService)
        {
            _anagraficaService = anagraficaService;
        }

        public async Task<IActionResult> Index()
        {
            List<Anagrafica> anagrafiche = await _anagraficaService.VediAnagrafiche();

            List<AnagraficaViewModel> anagraficaViewModels = anagrafiche.Select(
                a => new AnagraficaViewModel()
                {
                    Id = a.Id,
                    Nome = a.Nome,
                    Cognome = a.Cognome,
                    Citta = a.Citta,
                    Cap = a.Cap,
                    CodiceFiscale = a.CodiceFiscale,
                    Indirizzo = a.Indirizzo
                }
                ).ToList();

            return View(anagraficaViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> CreaAnagrafica(AnagraficaViewModel anagraficaViewModel)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (anagraficaViewModel is not null)
                    {
                        var anagrafica = new Anagrafica
                        {
                            Id = Guid.NewGuid(),
                            Nome = anagraficaViewModel.Nome,
                            Cognome = anagraficaViewModel.Cognome,
                            Indirizzo = anagraficaViewModel.Indirizzo,
                            Citta = anagraficaViewModel.Citta,
                            Cap = anagraficaViewModel.Cap,
                            CodiceFiscale = anagraficaViewModel.CodiceFiscale
                        };

                        bool salvato = await _anagraficaService.CreaAnagrafica(anagrafica);

                        if (salvato)
                        {
                            TempData["SuccessMessage"] = "Anagrafica Creata!";
                            return RedirectToAction(nameof(Index));
                        }
                        else
                        {
                            TempData["ErrorMessage"] = "Errore Durante la Creazione!";
                            return RedirectToAction(nameof(Index));
                        }
                    }
                    return View(anagraficaViewModel);

                }

                return View(anagraficaViewModel);


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Si è verificato un errore: " + ex.Message);
                return View(anagraficaViewModel);
            }

        }



    }
}
