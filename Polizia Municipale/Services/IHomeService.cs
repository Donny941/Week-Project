using Polizia_Municipale.Models.Dto;
using Polizia_Municipale.ViewModels;

namespace Polizia_Municipale.Services
{
    public interface IHomeService
    {
        Task<List<VerbaliPerTrasgressoreDto>> GetVerbaliPerTrasgressoreAsync();
        Task<List<PuntiPerTrasgressoreDto>> GetPuntiPerTrasgressoreAsync();
        Task<List<ViolazioneGraveDto>> GetViolazioniOltre10PuntiAsync();
        Task<List<ViolazioneImportoAltoDto>> GetViolazioniOltre400EuroAsync();
        Task<DashboardViewModel> GetDashboardDataAsync();
    }
}
