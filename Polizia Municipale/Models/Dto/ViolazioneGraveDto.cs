namespace Polizia_Municipale.Models.Dto
{
    public class ViolazioneGraveDto
    {
        public DateTime DataViolazione { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public decimal Importo { get; set; }
        public int DecurtamentoPunti { get; set; }
    }
}
