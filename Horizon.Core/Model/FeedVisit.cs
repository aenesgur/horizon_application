using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Horizon.Core.Model
{
    public class FeedVisit
    {
        public int Id { get; set; }
        public DateTime FeedingDate { get; set; }
        public int Intake { get; set; }

        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
    }
}
