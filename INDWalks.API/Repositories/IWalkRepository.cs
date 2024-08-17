using INDWalks.API.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace INDWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<List<Walk>> GetAllWalksAsync(string? filterOn=null,string? filterQuery=null,
            string? sortBy=null,bool isAscending = true,[FromQuery] int page = 1, [FromQuery] int pageSize = 1000);
        Task<Walk> GetWalkByIdAsync(Guid id);
        Task<Walk>CreateAsync(Walk walk);

        Task<Walk?> UpdateWalkAsync(Guid id, Walk walk);
        Task<Walk?> DeleteWalkAsync(Guid id);
    }
}
