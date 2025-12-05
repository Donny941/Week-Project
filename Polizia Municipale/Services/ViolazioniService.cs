using Microsoft.EntityFrameworkCore;
using Polizia_Municipale.Models.Entities;

namespace Polizia_Municipale.Services
{
    public class ViolazioniService : ServiceBase
    {
        public ViolazioniService(AppDbContext appDbContext) : base(appDbContext) { }


        public async Task<List<Violazione>> VediViolazioni()
        {
            return await _appDbContext.Violazioni.AsNoTracking().ToListAsync();
        }

        public async Task<bool> CreaViolazione(Violazione violazione)
        {
            _appDbContext.Violazioni.Add(violazione);
            return await SaveAsync();
        }
    }
}
