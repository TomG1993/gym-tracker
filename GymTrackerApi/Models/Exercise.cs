using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymTrackerApi.Models
{
    public class Exercise : BaseModel
    {
        public int Id { get; set; }

        public int BodyPartTypeId { get; set; }

        public string Description { get; set; }

        public bool Frozen { get; set; }

    }
}
