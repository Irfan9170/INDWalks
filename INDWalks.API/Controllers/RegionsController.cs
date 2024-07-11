using AutoMapper;
using INDWalks.API.Data;
using INDWalks.API.Mapping;
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
        private readonly IMapper autoMapping;

        public RegionsController(INDWalksDbContext dbContext, IRegionRepository regionRepository,IMapper autoMapping)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.autoMapping = autoMapping;
        }

        public INDWalksDbContext DbContext { get; }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            
            //Get regions from database through entity framework using dbcontext class
            var regionDomains = await regionRepository.GetAllRegionAsync();

            //Map DTO class
            //var regionsDTO = new List<RegionDTO>();

            //foreach (var regionDomain in regionDomains)
            //{
            //    regionsDTO.Add(new RegionDTO()
            //    {
            //        Id = regionDomain.Id,
            //        Name = regionDomain.Name,
            //        Code = regionDomain.Code,
            //        RegionImageUrl= regionDomain.RegionImageUrl
            //    });
            //}
            //;
            return Ok(autoMapping.Map<List<RegionDTO>>(regionDomains));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetRegionById ([FromRoute] Guid id)
        {
            //Get regions from database through entity framework using dbcontext class
            var regionDomain = await regionRepository.GetRegionsByIdAync(id);

           // var region = dbContext.Regions.FirstOrDefault(x => x.Id ==id);

            //DTOs Mapping 

            //var regionDTO = new RegionDTO
            //{
            //    Id=regionDomain.Id,
            //    Name = regionDomain.Name,
            //    Code = regionDomain.Code,
            //    RegionImageUrl= regionDomain.RegionImageUrl
            //};
            var regionDTO = autoMapping.Map<RegionDTO>(regionDomain);
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
            //var regionDomain = new Region
            //{
            //    Name = addRegionDTO.Name,
            //    Code = addRegionDTO.Code,
            //    RegionImageUrl = addRegionDTO.RegionImageUrl
            //};

            var regionDomain = autoMapping.Map<Region>(addRegionDTO);
            regionDomain = await regionRepository.CreateRegionAsync(regionDomain);

            //Map domain to DTO again 

            //var regionDTO = new RegionDTO
            //{
            //    Id = regionDomain.Id,
            //    Name = regionDomain.Name,
            //    Code = regionDomain.Code,
            //    RegionImageUrl = regionDomain.RegionImageUrl
            //};

            var regionDTO = autoMapping.Map<RegionDTO>(regionDomain);
            return CreatedAtAction(nameof(GetRegionById), new { id = regionDTO.Id }, regionDTO);

        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionDTO UpdateRegionDTO)
        {


            //var regionDomain = new Region
            //{
            //    Code = UpdateRegionDTO.Code,
            //    RegionImageUrl = UpdateRegionDTO.RegionImageUrl,
            //    Name = UpdateRegionDTO.Name,

            //};
            var regionDomain = autoMapping.Map<Region>(UpdateRegionDTO);
            regionDomain= await regionRepository.UpdateRegionAsync(id, regionDomain);

            if (regionDomain== null)
            {
                return NotFound();
            }

            regionDomain.Name = UpdateRegionDTO.Name;
            regionDomain.Code = UpdateRegionDTO.Code;
            regionDomain.RegionImageUrl = UpdateRegionDTO.RegionImageUrl;

            await dbContext.SaveChangesAsync();
            //var regionDTO = new RegionDTO
            //{
            //    Id=regionDomain.Id,
            //    Name = regionDomain.Name,
            //    Code = regionDomain.Code,
            //    RegionImageUrl = regionDomain.RegionImageUrl
            //};
            var regionDTO = autoMapping.Map<RegionDTO>(regionDomain);
            return Ok(regionDTO);
            
        }
        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> deleteRegion([FromRoute] Guid id)
        {
            var regionDomain = await regionRepository.DeleteRegionAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }

            //var regionDTO = new RegionDTO
            //{
            //    Id = regionDomain.Id,
            //    Name = regionDomain.Name,
            //    Code = regionDomain.Code,
            //    RegionImageUrl = regionDomain.RegionImageUrl
            //};
            var regionDTO = autoMapping.Map<RegionDTO>(regionDomain);
            return Ok(regionDTO);
        }
    }
}
