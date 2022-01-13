using AutoMapper;
using Horizon.API.Model.Dto;
using Horizon.API.Model.PaginationFilter;
using Horizon.API.Validator;
using Horizon.Core.Model;
using Horizon.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Horizon.API.Controllers
{
    [Route("api/feeding/visits")]
    [ApiController]
    public class FeedingVisitController : ControllerBase
    {
        private readonly IFeedVisitService _feedVisitService;
        private readonly IAnimalService _animalService;
        private readonly IMapper _mapper;

        public FeedingVisitController(IFeedVisitService feedVisitService, IAnimalService animalService, IMapper mapper)
        {
            _feedVisitService = feedVisitService;
            _animalService = animalService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeedVisits([FromQuery]  PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var feedVisits = await _feedVisitService.GetAllFeedVisits(validFilter);
            return Ok(feedVisits);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeedVisitsById(int id)
        {
            var feedVisit = await _feedVisitService.GetFeedVisitById(id);
            if(feedVisit == null)
            {
                return BadRequest("Feed visit could not found!");
            }
            return Ok(feedVisit);
        }

        [HttpPost]
        public async Task<ActionResult<FeedVisit>> CreateFeedVisit([FromBody] SaveFeedVisitDto saveFeedVisitDto)
        {
            var saveFeedVisitValidator = new SaveFeedVisitValidator();
            
            var validationResult = await saveFeedVisitValidator.ValidateAsync(saveFeedVisitDto);
            
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);


            var animal = await _animalService.GetAnimalById(saveFeedVisitDto.AnimalId);
            
            if(animal == null)
            {
                return BadRequest("AnimalId could not found!");
            }

            var feedVisit = _mapper.Map<SaveFeedVisitDto, FeedVisit>(saveFeedVisitDto);

            await _feedVisitService.CreateFeedVisit(feedVisit);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedVisit(int id)
        {
            var feedVisit = await _feedVisitService.GetFeedVisitById(id);
            if (feedVisit == null)
            {
                return BadRequest("Feed visit could not found!");
            }
            await _feedVisitService.DeleteFeedVisit(feedVisit);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeedVisit(int id, SaveFeedVisitDto saveFeedVisitDto)
        {
            var updatedFeedVisit = await _feedVisitService.GetFeedVisitById(id);
            if (updatedFeedVisit == null)
            {
                return BadRequest("Feed Visit could not found!");
            }

            var animal = await _animalService.GetAnimalById(saveFeedVisitDto.AnimalId);
            if (animal == null)
            {
                return BadRequest("AnimalId could not found!");
            }

            var feedVisit = _mapper.Map<SaveFeedVisitDto, FeedVisit>(saveFeedVisitDto);
            await _feedVisitService.UpdateFeedVisit(updatedFeedVisit, feedVisit);

            return NoContent();
        }
    }
}
