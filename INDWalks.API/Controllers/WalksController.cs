using AutoMapper;
using INDWalks.API.Models.Domain;
using INDWalks.API.Models.DTOs;
using INDWalks.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INDWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public WalksController(IRegionRepository regionRepository,IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpPost]

        public async Task<IActionResult>  Create([FromBody] AddWalkDTO addWalkDTO)
        {
            var walkDomain = mapper.Map<Walk>(addWalkDTO);

        }
    }
}
