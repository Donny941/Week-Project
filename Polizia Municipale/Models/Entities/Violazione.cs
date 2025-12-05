using System.ComponentModel.DataAnnotations.Schema;

namespace Polizia_Municipale.Models.Entities
{
    public class Violazione
    {
        public Guid Id { get; set; }

        public string Descrizione { get; set; }

        [InverseProperty(nameof(Verbale.Violazione))]
        public ICollection<Verbale> Verbali { get; set; }
    }
}
