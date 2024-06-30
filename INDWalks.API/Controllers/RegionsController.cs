using INDWalks.API.Data;
using INDWalks.API.Models.Domain;
using INDWalks.API.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INDWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly INDWalksDbContext dbContext;
        public RegionsController(INDWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public INDWalksDbContext DbContext { get; }

        [HttpGet]
        public IActionResult GetAllRegions()
        {
            //var regions = new List<Region>
            //{
            //    new Region
            //    {
            //        Id = Guid.NewGuid(),
            //        Name= "North Region",
            //        Code="NR",
            //        RegionImageUrl ="someUrl.com"
            //    },
            //    new Region
            //    {
            //        Id = Guid.NewGuid(),
            //        Name= "Soth Region",
            //        Code="SR",
            //        RegionImageUrl ="someSouthUrl.com"
            //    }
            //};
            //Get regions from database through entity framework using dbcontext class
            var regionDomains = dbContext.Regions.ToList();

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
        public IActionResult GetRegionById ([FromRoute] Guid id)
        {
            //Get regions from database through entity framework using dbcontext class
            var regionDomain = dbContext.Regions.Find(id);

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

        public IActionResult CreateRegion([FromBody] AddRegionDTO addRegionDTO)
        {
            //Map or Convert DTO to Domain
            var regionDoamin = new Region
            {
                Name = addRegionDTO.Name,
                Code = addRegionDTO.Code,
                RegionImageUrl = addRegionDTO.RegionImageUrl
            };

            dbContext.Regions.Add(regionDoamin);
            dbContext.SaveChanges();

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
        public IActionResult UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionDTO UpdateRegionDTO)
        {
            var regionDomain = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (regionDomain== null)
            {
                return NotFound();
            }

            regionDomain.Name = UpdateRegionDTO.Name;
            regionDomain.Code = UpdateRegionDTO.Code;
            regionDomain.RegionImageUrl = UpdateRegionDTO.RegionImageUrl;

            dbContext.SaveChanges();
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

        public IActionResult deleteRegion([FromRoute] Guid id)
        {
            var regionDomain = dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            dbContext.Regions.Remove(regionDomain);
            dbContext.SaveChanges();
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
