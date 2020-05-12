using GymTrackerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymTrackerApi.Repository.Interfaces
{
    public interface IExerciseRepository
    {
        public Exercise GetExercise(string Description);

        public int AddExercise(Exercise exercise);

        public SessionHeader GetSessionHeader(int userId);

        public int AddSessionHeader(SessionHeader sessionHeader);

        public List<SessionExercise> GetSessionExercises(int headerId);

        public int AddSessionExercise(SessionExercise sessionExercise);

        public List<SessionExerciseSet> GetSessionExerciseSets(int sessionExerciseId);
    }
}
