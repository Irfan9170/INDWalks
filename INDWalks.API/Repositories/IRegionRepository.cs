using INDWalks.API.Models.Domain;

namespace INDWalks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllRegionAsync();
        Task<Region?> GetRegionsByIdAync(Guid id);
    }
}
