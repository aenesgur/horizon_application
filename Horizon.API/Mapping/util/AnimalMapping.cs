using Horizon.API.Model.Dto;
using Horizon.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Horizon.API.Mapping.util
{
    public static class AnimalMapping
    {
        public static AnimalDto convertToResource(Animal animal)
        {
            AnimalDto animalDto = new AnimalDto();

            animalDto.Id = animal.Id;
            animalDto.LifeNumber = animal.LifeNumber;
            animalDto.MotherLifeNumber = animal.MotherLifeNumber;
            animalDto.Name = animal.Name;
            animalDto.Gender = animal.Gender;
            animalDto.FatherLifeNumber = animal.FatherLifeNumber;
            animalDto.Description = animal.Description;
            animalDto.BirthDate = animal.BirthDate;

            return animalDto;
        }

        public static IEnumerable<AnimalDto> convetToResourceList(IEnumerable<Animal> animals)
        {
            IList<AnimalDto> animalDtos = new List<AnimalDto>();

            foreach(Animal animal in animals)
            {
                AnimalDto animalDto = new AnimalDto();


                animalDto.Id = animal.Id;
                animalDto.LifeNumber = animal.LifeNumber;
                animalDto.MotherLifeNumber = animal.MotherLifeNumber;
                animalDto.Name = animal.Name;
                animalDto.Gender = animal.Gender;
                animalDto.FatherLifeNumber = animal.FatherLifeNumber;
                animalDto.Description = animal.Description;
                animalDto.BirthDate = animal.BirthDate;

                animalDtos.Add(animalDto);
            }

            return animalDtos;
        }
    }
}
