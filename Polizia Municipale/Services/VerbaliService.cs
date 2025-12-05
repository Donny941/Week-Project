using Microsoft.EntityFrameworkCore;
using Polizia_Municipale.Models.Entities;

namespace Polizia_Municipale.Services
{
    public class VerbaliService : ServiceBase
    {

        public VerbaliService(AppDbContext appDbContext) : base(appDbContext) { }
        public async Task<List<Verbale>> VediVerbali()
        {
            return await _appDbContext.Verbali.AsNoTracking().ToListAsync();
        }
        public async Task<bool> CreaVerbale(Verbale verbale)
        {
            _appDbContext.Verbali.Add(verbale);
            return await SaveAsync();
        }
    }
}
