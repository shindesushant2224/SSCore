using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SSCore.API.Models.Domain;
using SSCore.API.Models.DTO;
using SSCore.API.Repositories.WalksRepository;

namespace SSCore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalksController : Controller
    {
        private readonly IWalksRepository walksRepository;
        private readonly IMapper mapper;

        public WalksController(IWalksRepository walksRepository, IMapper mapper)
        {
            this.walksRepository = walksRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetWalks()
        {

            var walksDomain = await walksRepository.GetWalksAsync();

            var walksDto = mapper.Map<List<WalkDto>>(walksDomain);

            return Ok(walksDto);
        }
        [HttpGet]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> GetWalkById([FromRoute] Guid Id)
        {

            var walkDomain = await walksRepository.GetWalkAsync(Id);

            if(walkDomain == null)
                return NotFound();

            var walkDto = mapper.Map<WalkDto>(walkDomain);

            return Ok(walkDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalksDto addWalksDto)
        {
            var WalkModel = mapper.Map<Walk>(addWalksDto);

            WalkModel = await walksRepository.AddAsync(WalkModel);

           if(WalkModel == null)
                return NotFound();

            var walkDto = mapper.Map<WalkDto>(WalkModel);

            return CreatedAtAction(nameof(GetWalkById), new { walkDto.Id }, walkDto);
        }
        [HttpPut]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid Id, UpdateWalksDto updateWalksDto)
        {
            var walkModel = mapper.Map<Walk>(updateWalksDto);
            walkModel = await walksRepository.UpdateAsync(Id, walkModel);

            if(walkModel == null)
                return NotFound();
            var walkDto = mapper.Map<Walk>(walkModel);

            return Ok(walkDto);
        }
        [HttpDelete]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {

            var walkDomain = await walksRepository.DeleteAsync(Id);

            if (walkDomain == null)
                return NotFound();

            var walkDto = mapper.Map<WalkDto>(walkDomain);

            return Ok(walkDto);
        }
    }
}
