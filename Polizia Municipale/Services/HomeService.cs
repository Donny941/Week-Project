// Services/HomeService.cs
using Microsoft.EntityFrameworkCore;
using Polizia_Municipale.Models.Dto;
using Polizia_Municipale.Models.Entities;
using Polizia_Municipale.ViewModels;

namespace Polizia_Municipale.Services
{


    public class HomeService : IHomeService
    {
        private readonly AppDbContext _appDbContext;

        public HomeService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<VerbaliPerTrasgressoreDto>> GetVerbaliPerTrasgressoreAsync()
        {
            return await _appDbContext.Verbali
                .Include(v => v.Anagrafica)
                .GroupBy(v => new { v.Anagrafica.Nome, v.Anagrafica.Cognome, v.Anagrafica.CodiceFiscale })
                .Select(g => new VerbaliPerTrasgressoreDto
                {
                    Nome = g.Key.Nome,
                    Cognome = g.Key.Cognome,
                    CodiceFiscale = g.Key.CodiceFiscale,
                    TotaleVerbali = g.Count()
                })
                .OrderByDescending(x => x.TotaleVerbali)
                .ToListAsync();
        }

        public async Task<List<PuntiPerTrasgressoreDto>> GetPuntiPerTrasgressoreAsync()
        {
            return await _appDbContext.Verbali
                .Include(v => v.Anagrafica)
                .GroupBy(v => new { v.Anagrafica.Nome, v.Anagrafica.Cognome, v.Anagrafica.CodiceFiscale })
                .Select(g => new PuntiPerTrasgressoreDto
                {
                    Nome = g.Key.Nome,
                    Cognome = g.Key.Cognome,
                    CodiceFiscale = g.Key.CodiceFiscale,
                    TotalePunti = g.Sum(v => v.DecurtamentoPunti)
                })
                .OrderByDescending(x => x.TotalePunti)
                .ToListAsync();
        }

        public async Task<List<ViolazioneGraveDto>> GetViolazioniOltre10PuntiAsync()
        {
            return await _appDbContext.Verbali
                .Include(v => v.Anagrafica)
                .Where(v => v.DecurtamentoPunti > 10)
                .Select(v => new ViolazioneGraveDto
                {
                    DataViolazione = v.DataViolazione.ToDateTime(TimeOnly.MinValue),
                    Nome = v.Anagrafica.Nome,
                    Cognome = v.Anagrafica.Cognome,
                    Importo = v.Importo,
                    DecurtamentoPunti = v.DecurtamentoPunti
                })
                .OrderByDescending(x => x.DecurtamentoPunti)
                .ToListAsync();
        }

        public async Task<List<ViolazioneImportoAltoDto>> GetViolazioniOltre400EuroAsync()
        {
            return await _appDbContext.Verbali
                .Include(v => v.Anagrafica)
                .Include(v => v.Violazione)
                .Where(v => v.Importo > 400)
                .Select(v => new ViolazioneImportoAltoDto
                {
                    DataViolazione = v.DataViolazione.ToDateTime(TimeOnly.MinValue),
                    Nome = v.Anagrafica.Nome,
                    Cognome = v.Anagrafica.Cognome,
                    CodiceFiscale = v.Anagrafica.CodiceFiscale,
                    Importo = v.Importo,
                    DescrizioneViolazione = v.Violazione.Descrizione
                })
                .OrderByDescending(x => x.Importo)
                .ToListAsync();
        }

        public async Task<DashboardViewModel> GetDashboardDataAsync()
        {
            return new DashboardViewModel
            {
                VerbaliPerTrasgressore = await GetVerbaliPerTrasgressoreAsync(),
                PuntiPerTrasgressore = await GetPuntiPerTrasgressoreAsync(),
                ViolazioniOltre10Punti = await GetViolazioniOltre10PuntiAsync(),
                ViolazioniOltre400Euro = await GetViolazioniOltre400EuroAsync()
            };
        }
    }
}