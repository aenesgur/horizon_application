using Horizon.API.Model.PaginationFilter;
using Horizon.Core;
using Horizon.Core.Model;
using Horizon.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Horizon.Service
{
    public class AnimalService : IAnimalService 
    {
        private readonly IUnitOfWork _unitOfWork;
        public AnimalService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Animal>> GetAllAnimal(PaginationFilter filter)
        {
            return await _unitOfWork.Animals.GetAllAnimalAsync(filter);
        }

        public async Task CreateAnimal(Animal animal)
        {
            await _unitOfWork.Animals
                .AddAsync(animal);

            await _unitOfWork.CommitAsync();

        }

        public async Task<Animal> GetAnimalById(int id)
        {
            return await _unitOfWork.Animals.GetAnimalByIdAsync(id);
        }

        public async Task DeleteAnimal(Animal animal)
        {
            _unitOfWork.Animals.Remove(animal);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAnimal(Animal animalToBeUpdated, Animal animal)
        {
            animalToBeUpdated.BirthDate = animal.BirthDate;
            animalToBeUpdated.Description = animal.Description;
            animalToBeUpdated.FatherLifeNumber = animal.FatherLifeNumber;
            animalToBeUpdated.MotherLifeNumber = animal.MotherLifeNumber;
            animalToBeUpdated.Name = animal.Name;
            animalToBeUpdated.LifeNumber = animal.LifeNumber;

            await _unitOfWork.CommitAsync();
        }
    }
}
