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

        public async  Task<Region> CreateRegionAsync(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteRegionAsync(Guid id)
        {
            var regionFound = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (regionFound == null)
            {
                return null;
            }
             dbContext.Regions.Remove(regionFound);
            await dbContext.SaveChangesAsync();
            return regionFound;
        }

        public async Task<List<Region>> GetAllRegionAsync()
        {
           return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetRegionsByIdAync(Guid id)
        {
          return await dbContext.Regions.FirstOrDefaultAsync(x=> x.Id==id);
        }

        public async Task<Region> UpdateRegionAsync(Guid id,Region region)
        {
           var regionFound = await dbContext.Regions.FirstOrDefaultAsync(x=> x.Id == id);
            if (regionFound == null) 
            {
                return null;
            }
            regionFound.Name = region.Name;
            regionFound.Code = region.Code;
            regionFound.RegionImageUrl = region.RegionImageUrl;
            await dbContext.SaveChangesAsync();
            return regionFound;

        }
    }
}
