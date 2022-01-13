using AutoMapper;
using Horizon.API.Mapping.util;
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
    [Route("api/animals")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _animalService;
        private readonly IMapper _mapper;

        public AnimalController(IAnimalService animalService, IMapper mapper)
        {
            _animalService = animalService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnimals([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var animals = await _animalService.GetAllAnimal(validFilter);
            var animalDtos = AnimalMapping.convetToResourceList(animals);

            return Ok(animalDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimalById(int id)
        {
            var animal = await _animalService.GetAnimalById(id);
            if (animal == null)
            {
                return BadRequest("Animal could not found!");
            }

            var animalDtos = AnimalMapping.convertToResource(animal);

            return Ok(animalDtos);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAnimal([FromBody] SaveAnimalDto saveAnimalDto)
        {
            var saveAnimalValidator = new SaveAnimalValidator();

            var validationResult = await saveAnimalValidator.ValidateAsync(saveAnimalDto);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var animal = _mapper.Map<SaveAnimalDto, Animal>(saveAnimalDto);

            await _animalService.CreateAnimal(animal);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            var animal = await _animalService.GetAnimalById(id);
            if(animal == null)
            {
                return BadRequest("Animal could not found!");
            }
            await _animalService.DeleteAnimal(animal);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAnimal(int id, SaveAnimalDto saveAnimalDto)
        {
            var updatedAnimal = await _animalService.GetAnimalById(id);
            if(updatedAnimal == null)
            {
                return BadRequest("Animal could not found!");
            }
            var animal = _mapper.Map<SaveAnimalDto, Animal>(saveAnimalDto);
            await _animalService.UpdateAnimal(updatedAnimal, animal);

            return NoContent();
        }

    }


}
