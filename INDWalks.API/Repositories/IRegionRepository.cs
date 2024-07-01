using INDWalks.API.Models.Domain;

namespace INDWalks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllRegionAsync();
    }
}
