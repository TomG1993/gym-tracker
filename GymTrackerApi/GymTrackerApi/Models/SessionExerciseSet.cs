using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymTrackerApi.Models
{
    public class SessionExerciseSet : BaseModel
    {
        public int Id { get; set; }

        public int SessionExerciseID { get; set; }

        public int Weight { get; set; }

        public int Repetitions { get; set; }

        public bool Frozen { get; set; }


    }
}
