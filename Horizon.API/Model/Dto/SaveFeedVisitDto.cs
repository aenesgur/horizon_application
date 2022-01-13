using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Horizon.API.Model.Dto
{
    public class SaveFeedVisitDto
    {
        public DateTime FeedingDate { get; set; }
        public int Intake { get; set; }

        public int AnimalId { get; set; }
    }
}
