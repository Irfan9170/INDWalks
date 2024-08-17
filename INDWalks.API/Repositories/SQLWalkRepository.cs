using INDWalks.API.Data;
using INDWalks.API.Models.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<List<Walk>> GetAllWalksAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, 
            bool isAscending = true, [FromQuery] int page = 1, [FromQuery] int pageSize = 1000)
        {
            var walksQuery =  dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();
            //Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walksQuery = walksQuery.Where(x=>x.Name.Contains(filterQuery));

                }
            }
            //Sorting 
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walksQuery = isAscending ?walksQuery.OrderBy(x=>x.Name) : walksQuery.OrderByDescending(x=>x.Name) ;
                }
                else if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    walksQuery = isAscending ? walksQuery.OrderBy(x => x.LengthInKm) : walksQuery.OrderByDescending(x => x.LengthInKm);
                }
            }
            //Pagination 
            var skipresult = (page - 1) * pageSize;

            return await walksQuery.Skip(skipresult).Take(pageSize).ToListAsync();
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
