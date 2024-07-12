using INDWalks.API.Data;
using INDWalks.API.Models.Domain;
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

        public async Task<List<Walk>> GetAllWalksAsync()
        {
            return await dbContext.Walks.ToListAsync();
        }
    }
}
