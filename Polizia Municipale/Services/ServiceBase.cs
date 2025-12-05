using Polizia_Municipale.Models.Entities;

namespace Polizia_Municipale.Services
{
    public class ServiceBase
    {
        protected readonly AppDbContext _appDbContext;

        protected ServiceBase(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        protected async Task<bool> SaveAsync()
        {
            bool result = false;

            try
            {
                result = await _appDbContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
    }
}
