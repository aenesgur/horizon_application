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
    public class FeedVisitService : IFeedVisitService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FeedVisitService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<FeedVisit>> GetAllFeedVisits(PaginationFilter filter)
        {
            return await _unitOfWork.FeedVisits.GetAllFeedVisitlAsync(filter);
        }

        public async Task CreateFeedVisit(FeedVisit feedVisit)
        {
            await _unitOfWork.FeedVisits
                .AddAsync(feedVisit);

            await _unitOfWork.CommitAsync();
        }

        public async Task<FeedVisit> GetFeedVisitById(int id)
        {
            return await _unitOfWork.FeedVisits.GetFeedVisitByIdAsync(id);
        }

        public async Task DeleteFeedVisit(FeedVisit feedVisit)
        {
            _unitOfWork.FeedVisits.Remove(feedVisit);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateFeedVisit(FeedVisit feedVisitToBeUpdated, FeedVisit feedVisit)
        {
            feedVisitToBeUpdated.Intake = feedVisit.Intake;
            feedVisitToBeUpdated.FeedingDate = feedVisit.FeedingDate;
            feedVisitToBeUpdated.AnimalId = feedVisit.AnimalId;
       
            await _unitOfWork.CommitAsync();
        }
    }
}
