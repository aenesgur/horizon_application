using Horizon.API.Model.PaginationFilter;
using Horizon.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Horizon.Core.Service
{
    public interface IFeedVisitService
    {
        Task<IEnumerable<FeedVisit>> GetAllFeedVisits(PaginationFilter filter);
        Task<FeedVisit> GetFeedVisitById(int id);
        Task CreateFeedVisit(FeedVisit feedVisit);
        Task DeleteFeedVisit(FeedVisit feedVisit);
        Task UpdateFeedVisit(FeedVisit feedVisitToBeUpdated, FeedVisit feedVisit);
    }
}
