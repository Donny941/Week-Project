using Polizia_Municipale.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Polizia_Municipale.ViewModels
{
    public class ViolazioneViewModel
    {
        public string Descrizione { get; set; }

        [InverseProperty(nameof(Verbale.Violazione))]
        public ICollection<Verbale> Verbali { get; set; }
    }
}
