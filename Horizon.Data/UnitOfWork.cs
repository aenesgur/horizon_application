using Horizon.Core;
using Horizon.Core.Log;
using Horizon.Core.Repository;
using Horizon.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Horizon.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HorizonDbContext _context;
        private AnimalRepository _animalRepository;
        private FeedVisitRepository _feedVisitRepository;
        private ILogService _logger;

        public UnitOfWork(HorizonDbContext context, ILogService logger)
        {
            _context = context;
            _logger = logger;
        }

        public IAnimalRepository Animals => _animalRepository = _animalRepository ?? new AnimalRepository(_context, _logger);
        public IFeedVisitRepository FeedVisits => _feedVisitRepository = _feedVisitRepository ?? new FeedVisitRepository(_context, _logger);


        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
