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

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetWalkByID([FromRoute] Guid id)
        {
            var walkDomain = await walkRepository.GetWalkByIdAsync(id);

            var walkDTO = mapper.Map<WalkDTO>(walkDomain);
            if (walkDTO == null)
            {
                return NotFound();
            }
            return Ok(walkDTO);
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

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateWalk([FromBody] UpdateWalkDTO updateWalkDTO, Guid id)
        {
            var walkDomain = mapper.Map<Walk>(updateWalkDTO);
            walkDomain = await walkRepository.UpdateWalkAsync(id, walkDomain);
            if(walkDomain == null) { return NotFound(); }
            return Ok(mapper.Map<WalkDTO>(walkDomain));

        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleateWalk (Guid id)
        {
            var walkDomain = await walkRepository.DeleteWalkAsync(id);
            if(walkDomain == null) { return NotFound();};

            return Ok(mapper.Map<WalkDTO>(walkDomain));

        }

    }
}
