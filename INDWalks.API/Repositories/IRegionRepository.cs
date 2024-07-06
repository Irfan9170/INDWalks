using INDWalks.API.Models.Domain;

namespace INDWalks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllRegionAsync();
        Task<Region?> GetRegionsByIdAync(Guid id);

        Task <Region> CreateRegionAsync(Region region);

        Task<Region?> UpdateRegionAsync(Guid id,Region region);

        Task<Region?> DeleteRegionAsync(Guid id);
    }
}
