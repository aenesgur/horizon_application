using Horizon.API.Model.PaginationFilter;
using Horizon.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Horizon.Core.Service
{
    public interface IAnimalService
    {
        Task<IEnumerable<Animal>> GetAllAnimal(PaginationFilter filter);
        Task<Animal> GetAnimalById(int id);
        Task CreateAnimal(Animal animal);
        Task DeleteAnimal(Animal animal);
        Task UpdateAnimal(Animal animalToBeUpdated, Animal animal);
    }
}
