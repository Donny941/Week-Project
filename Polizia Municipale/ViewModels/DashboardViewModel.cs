using Polizia_Municipale.Models.Dto;

namespace Polizia_Municipale.ViewModels
{
    public class DashboardViewModel
    {
        public List<VerbaliPerTrasgressoreDto> VerbaliPerTrasgressore { get; set; }
        public List<PuntiPerTrasgressoreDto> PuntiPerTrasgressore { get; set; }
        public List<ViolazioneGraveDto> ViolazioniOltre10Punti { get; set; }
        public List<ViolazioneImportoAltoDto> ViolazioniOltre400Euro { get; set; }
    }
}
