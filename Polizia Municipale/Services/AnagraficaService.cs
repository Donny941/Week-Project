using Microsoft.EntityFrameworkCore;
using Polizia_Municipale.Models.Entities;

namespace Polizia_Municipale.Services
{
    public class AnagraficaService : ServiceBase
    {

        public AnagraficaService(AppDbContext appDbContext) : base(appDbContext) { }


        public async Task<List<Anagrafica>> VediAnagrafiche()
        {
            return await _appDbContext.Anagrafiche.AsNoTracking().ToListAsync();
        }
        public async Task<bool> CreaAnagrafica(Anagrafica anagrafica)
        {
            _appDbContext.Anagrafiche.Add(anagrafica);
            return await SaveAsync();
        }

    }
}
