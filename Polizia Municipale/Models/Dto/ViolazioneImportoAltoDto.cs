namespace Polizia_Municipale.Models.Dto
{

    public class ViolazioneImportoAltoDto
    {
        public DateTime DataViolazione { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }
        public decimal Importo { get; set; }
        public string DescrizioneViolazione { get; set; }
    }
}
