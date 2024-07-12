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
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository walkRepository,IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllWalksAsync()
        {
            var walksDomain = await walkRepository.GetAllWalksAsync();
            return Ok(mapper.Map<List<WalkDTO>>(walksDomain));
        }
        
        [HttpPost]

        public async Task<IActionResult>  Create([FromBody] AddWalkDTO addWalkDTO)
        {
            var walkDomain = mapper.Map<Walk>(addWalkDTO);
            walkDomain = await walkRepository.CreateAsync(walkDomain);
            return Ok(mapper.Map<WalkDTO>(walkDomain));

        }

    }
}
