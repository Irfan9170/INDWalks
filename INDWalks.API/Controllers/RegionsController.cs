using INDWalks.API.Data;
using INDWalks.API.Models.Domain;
using INDWalks.API.Models.DTOs;
using INDWalks.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace INDWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly INDWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;

        public RegionsController(INDWalksDbContext dbContext, IRegionRepository regionRepository)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
        }

        public INDWalksDbContext DbContext { get; }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            
            //Get regions from database through entity framework using dbcontext class
            var regionDomains = await regionRepository.GetAllRegionAsync();

            //Map DTO class
            var regionsDTO = new List<RegionDTO>();

            foreach (var regionDomain in regionDomains)
            {
                regionsDTO.Add(new RegionDTO()
                {
                    Id = regionDomain.Id,
                    Name = regionDomain.Name,
                    Code = regionDomain.Code,
                    RegionImageUrl= regionDomain.RegionImageUrl
                });
            }
            return Ok(regionsDTO);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetRegionById ([FromRoute] Guid id)
        {
            //Get regions from database through entity framework using dbcontext class
            var regionDomain = await dbContext.Regions.FindAsync(id);

           // var region = dbContext.Regions.FirstOrDefault(x => x.Id ==id);

            //DTOs Mapping 

            var regionDTO = new RegionDTO
            {
                Id=regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl= regionDomain.RegionImageUrl
            };
            if (regionDTO == null)
            {
                return NotFound();
            }
            return Ok(regionDTO);
        }

        [HttpPost]

        public async Task<IActionResult> CreateRegion([FromBody] AddRegionDTO addRegionDTO)
        {
            //Map or Convert DTO to Domain
            var regionDoamin = new Region
            {
                Name = addRegionDTO.Name,
                Code = addRegionDTO.Code,
                RegionImageUrl = addRegionDTO.RegionImageUrl
            };

           await dbContext.Regions.AddAsync(regionDoamin);
            await dbContext.SaveChangesAsync();

            //Map domain to DTO again 

            var regionDTO = new RegionDTO
            {
                Id = regionDoamin.Id,
                Name = regionDoamin.Name,
                Code = regionDoamin.Code,
                RegionImageUrl = regionDoamin.RegionImageUrl
            };

            return CreatedAtAction(nameof(GetRegionById), new { id = regionDTO.Id }, regionDTO);

        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionDTO UpdateRegionDTO)
        {
            var regionDomain = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (regionDomain== null)
            {
                return NotFound();
            }

            regionDomain.Name = UpdateRegionDTO.Name;
            regionDomain.Code = UpdateRegionDTO.Code;
            regionDomain.RegionImageUrl = UpdateRegionDTO.RegionImageUrl;

            await dbContext.SaveChangesAsync();
            var regionDTO = new RegionDTO
            {
                Id=regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl
            };

            return Ok(regionDTO);
            
        }
        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> deleteRegion([FromRoute] Guid id)
        {
            var regionDomain = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            dbContext.Regions.Remove(regionDomain);
           await dbContext.SaveChangesAsync();
            var regionDTO = new RegionDTO
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl
            };
            return Ok(regionDTO);
        }
    }
}
