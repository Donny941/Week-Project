using System.ComponentModel.DataAnnotations;

namespace Polizia_Municipale.ViewModels
{
    public class AnagraficaViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cognome { get; set; }
        [Required]
        public string Indirizzo { get; set; }
        [Required]
        public string Citta { get; set; }
        [Required]
        public string Cap { get; set; }
        [Required]

        public string CodiceFiscale { get; set; }
    }
}
