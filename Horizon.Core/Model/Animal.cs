using System;
using System.Collections.Generic;
using System.Text;

namespace Horizon.Core.Model
{
    public class Animal
    {
        public int Id { get; set; }
        public string LifeNumber { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string FatherLifeNumber { get; set; }
        public string MotherLifeNumber { get; set; }
        public string Description { get; set; }

        public FeedVisit FeedVisit { get; set; }
    }
}
