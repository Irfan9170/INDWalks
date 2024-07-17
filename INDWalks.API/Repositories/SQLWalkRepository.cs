using INDWalks.API.Data;
using INDWalks.API.Models.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace INDWalks.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly INDWalksDbContext dbContext;

        public SQLWalkRepository(INDWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
             await dbContext.Walks.AddAsync(walk);
             await dbContext.SaveChangesAsync();
             return walk;
        }

        public async Task<Walk?> DeleteWalkAsync(Guid id)
        {
            var walkDomainFound = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (walkDomainFound == null)
            {
                return null;
            }
             dbContext.Walks.Remove(walkDomainFound);
            await dbContext.SaveChangesAsync();
            return walkDomainFound;
        }

        public async Task<List<Walk>> GetAllWalksAsync()
        {
            return await dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walk> GetWalkByIdAsync(Guid id)
        {
            return await dbContext.Walks.FirstOrDefaultAsync(x => x.Id==id);
        }

        public async Task<Walk> UpdateWalkAsync(Guid id, Walk walk)
        {
            var walkDomain = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id==id);
            if (walkDomain == null) 
            {
                return null;
            }

            walkDomain.Name = walk.Name;
            walkDomain.LengthInKm = walk.LengthInKm;
         
            await dbContext.SaveChangesAsync();
            return walkDomain;
        }
    }
}
