using System.ComponentModel.DataAnnotations;

namespace Polizia_Municipale.ViewModels
{
    public class VerbaleViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public DateOnly DataViolazione { get; set; }
        [Required]
        public string IndirizzoViolazione { get; set; }
        [Required]
        public string NominativoAgente { get; set; }
        [Required]
        public DateOnly DataTrascrizioneVerbale { get; set; }
        [Required]
        public decimal Importo { get; set; }
        [Required]
        public int DecurtamentoPunti { get; set; }
        [Required]
        public Guid AnagraficaId { get; set; }
        [Required]
        public Guid ViolazioneId { get; set; }
    }
}
