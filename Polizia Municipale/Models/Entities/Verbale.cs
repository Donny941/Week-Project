using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Polizia_Municipale.Models.Entities
{
    public class Verbale
    {
        [Key]
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

        [ForeignKey(nameof(AnagraficaId))]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Anagrafica Anagrafica { get; set; }

        [ForeignKey(nameof(ViolazioneId))]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Violazione Violazione { get; set; }

    }
}
