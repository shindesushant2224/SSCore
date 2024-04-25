using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SSCore.API.Data;
using SSCore.API.Models.Domain;
using SSCore.API.Models.DTO;
using SSCore.API.Repositories.RegionRepository;

namespace SSCore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        //Get All Regions
        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await regionRepository.GetRegions();
            var RegionsDto = mapper.Map<List<RegionDto>>(regions);

            return Ok(RegionsDto);
        }

        //Get Region ById
        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetRegionById([FromRoute] Guid Id)
        {
            var region = await regionRepository.GetRegion(Id);
            if(region == null)
            {
                return NotFound();
            }
            var RegionDto = mapper.Map<RegionDto>(region);

            return Ok(RegionDto);
        }

        //Create Region
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto regionRequestDto)
        {
            var regionModel = mapper.Map<Region>(regionRequestDto);

            regionModel = await regionRepository.CreateAsync(regionModel);

            var regionDto = mapper.Map<RegionDto>(regionModel);

            return CreatedAtAction(nameof(GetRegionById), new { regionDto.Id }, regionDto);
        }

        //Update Region
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,[FromBody] UpdateRegionRequestDto updateRegionRequest)
        {
            var regionModel = mapper.Map<Region>(updateRegionRequest);

            regionModel = await regionRepository.UpdateAsync(id,regionModel);

            if (regionModel == null)
                return NotFound();

            var regionUpdatedDto = mapper.Map<RegionDto>(regionModel);

            return Ok(regionUpdatedDto);
        }

        //Delete Region
        [HttpDelete]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var regionModel = await regionRepository.DeleteAsync(Id);

            if(regionModel == null)
                return NotFound();

            var deletedRegionDto = mapper.Map<RegionDto>(regionModel);

            return Ok(deletedRegionDto);
        }
    }
}
