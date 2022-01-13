using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Horizon.API.Model.Dto
{
    public class SaveAnimalDto
    {
        public string LifeNumber { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string FatherLifeNumber { get; set; }
        public string MotherLifeNumber { get; set; }
        public string Description { get; set; }

    }
}
