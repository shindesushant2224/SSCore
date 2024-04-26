using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SSCore.API.CustomActionFilters;
using SSCore.API.Models.Domain;
using SSCore.API.Models.DTO;
using SSCore.API.Repositories.DifficultyRepository;

namespace SSCore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkDifficultyController : Controller
    {
        private readonly IWalkDifficultyRepository walkDifficulty;
        private readonly IMapper mapper;

        public WalkDifficultyController(IWalkDifficultyRepository walkDifficulty, IMapper mapper)
        {
            this.walkDifficulty = walkDifficulty;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walkDifficulties = await walkDifficulty.GetAllAsync();
            mapper.Map<List<WalkDifficultyDto>>(walkDifficulties);
            return Ok(walkDifficulties);
        }
        [HttpGet]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> Get([FromRoute ]Guid Id)
        {
            var walkDifficultyModel = await walkDifficulty.GetAsync(Id);

            if (walkDifficultyModel == null)
                return NotFound();

            var walkDifficultyDto =  mapper.Map<WalkDifficultyDto>(walkDifficultyModel);
            return Ok(walkDifficultyDto);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkDifficultyDto addWalkDifficulty)
        {
            var walkDifficultyModel = mapper.Map<WalkDifficulty>(addWalkDifficulty);

            walkDifficultyModel = await walkDifficulty.CreateAsync(walkDifficultyModel);

            if(walkDifficultyModel == null)
                return NotFound();

            var walkDifficultyDto = mapper.Map<WalkDifficultyDto>(walkDifficultyModel);

            return CreatedAtAction(nameof(Get), new { walkDifficultyDto.Id }, walkDifficultyDto);
        }
        [HttpPut]
        [Route("{Id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid Id, [FromBody] UpdateWalkDifficultyDto updateWalkDifficulty)
        {
            var walkDifficultyModel = mapper.Map<WalkDifficulty>(updateWalkDifficulty);

            walkDifficultyModel = await walkDifficulty.UpdateAsync(Id,walkDifficultyModel);

            if (walkDifficultyModel == null)
                return NotFound();

            var walkDifficultyDto = mapper.Map<WalkDifficultyDto>(walkDifficultyModel);
            return Ok(walkDifficultyDto);
        }
        [HttpDelete]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            var walkDifficultyModel = await walkDifficulty.DeleteAsync(Id);

            if (walkDifficultyModel == null)
                return NotFound();

            var walkDifficultyDto = mapper.Map<WalkDifficultyDto>(walkDifficultyModel);
            return Ok(walkDifficultyDto);
        }
    }
}
