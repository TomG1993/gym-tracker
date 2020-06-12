using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymTrackerApi.Models.ReturnModels
{
    public class SessionExerciseReturnModel
    {
        public int Id { get; set; }
        public int HeaderId { get; set; }
        public int ExerciseId { get; set; }
        public string Description { get; set; }
    }
}
