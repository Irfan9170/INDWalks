using INDWalks.API.Models.Domain;

namespace INDWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<List<Walk>> GetAllWalksAsync();
        Task<Walk> GetWalkByIdAsync(Guid id);
        Task<Walk>CreateAsync(Walk walk);

        Task<Walk?> UpdateWalkAsync(Guid id, Walk walk);
        Task<Walk?> DeleteWalkAsync(Guid id);
    }
}
