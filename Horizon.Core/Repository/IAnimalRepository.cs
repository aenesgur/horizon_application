using Horizon.API.Model.PaginationFilter;
using Horizon.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Horizon.Core.Repository
{
    public interface IAnimalRepository : IRepository<Animal>
    {
        Task<IEnumerable<Animal>> GetAllAnimalAsync(PaginationFilter filter);
        Task<Animal> GetAnimalByIdAsync(int id);
    }
}
