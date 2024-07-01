using INDWalks.API.Data;
using INDWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace INDWalks.API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly INDWalksDbContext dbContext;

        public SQLRegionRepository(INDWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Region>> GetAllRegionAsync()
        {
           return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetRegionsByIdAync(Guid id)
        {
          return await dbContext.Regions.FirstOrDefaultAsync(x=> x.Id==id);
        }
    }
}
