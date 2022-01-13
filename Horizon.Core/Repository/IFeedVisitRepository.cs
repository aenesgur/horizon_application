using Horizon.API.Model.PaginationFilter;
using Horizon.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Horizon.Core.Repository
{
    public interface IFeedVisitRepository : IRepository<FeedVisit>
    {
        Task<IEnumerable<FeedVisit>> GetAllFeedVisitlAsync(PaginationFilter filter);
        Task<FeedVisit> GetFeedVisitByIdAsync(int id);
    }
}
