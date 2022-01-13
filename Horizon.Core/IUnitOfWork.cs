using Horizon.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Horizon.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IAnimalRepository Animals { get; }

        IFeedVisitRepository FeedVisits { get; }

        Task<int> CommitAsync();
    }
}
