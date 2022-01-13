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
    public class FeedVisitRepository : Repository<FeedVisit>, IFeedVisitRepository
    {
        private readonly HorizonDbContext _context;
        private ILogService _logger;
        public FeedVisitRepository(HorizonDbContext context, ILogService logger)
            : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<FeedVisit>> GetAllFeedVisitlAsync(PaginationFilter filter)
        {
            try
            {
                return await _context.FeedVisits
                                        .Skip((filter.PageNumber - 1) * filter.PageSize)
                                        .Take(filter.PageSize)
                                        .Include(fd => fd.Animal)
                                        .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<FeedVisit> GetFeedVisitByIdAsync(int id)
        {
            try
            {
                return await _context.FeedVisits
                               .Include(fd => fd.Animal)
                               .SingleOrDefaultAsync(fd => fd.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
