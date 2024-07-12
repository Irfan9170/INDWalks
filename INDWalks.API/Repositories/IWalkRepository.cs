using INDWalks.API.Models.Domain;

namespace INDWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<List<Walk>> GetAllWalksAsync();
        Task<Walk>CreateAsync(Walk walk);
    }
}
