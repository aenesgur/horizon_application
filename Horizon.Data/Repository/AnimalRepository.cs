using Horizon.API.Model.PaginationFilter;
using Horizon.Core.Log;
using Horizon.Core.Model;
using Horizon.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizon.Data.Repository
{
    public class AnimalRepository : Repository<Animal>, IAnimalRepository
    {
        private readonly HorizonDbContext _context;
        private ILogService _logger;
        public AnimalRepository(HorizonDbContext context, ILogService logger)
            : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Animal>> GetAllAnimalAsync(PaginationFilter filter)
        {
            try
            {
                return await _context.Animals.Skip((filter.PageNumber - 1) * filter.PageSize)
                                             .Take(filter.PageSize)
                                             .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new Exception(ex.Message);
            }
           
        }

        public async Task<Animal> GetAnimalByIdAsync(int id)
        {
            try
            {
                return await _context.Animals
               .SingleOrDefaultAsync(a => a.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
