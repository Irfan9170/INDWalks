using AutoMapper;
using INDWalks.API.Models.Domain;
using INDWalks.API.Models.DTOs;

namespace INDWalks.API.Mapping
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Region,RegionDTO>().ReverseMap();
            CreateMap<Region, UpdateRegionDTO>().ReverseMap();
            CreateMap<Region,AddRegionDTO>().ReverseMap();
            CreateMap<AddWalkDTO,Walk>().ReverseMap();
        }
    }
}
