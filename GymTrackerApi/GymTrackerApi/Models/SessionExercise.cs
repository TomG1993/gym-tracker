using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymTrackerApi.Models
{
    public class SessionExercise : BaseModel
    {
        public int Id { get; set; }

        public int HeaderId { get; set; }

        public int ExerciseId { get; set; }

    }
}
