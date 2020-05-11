using GymTrackerApi.Models;
using GymTrackerApi.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymTrackerApi.Repository
{
    public class ExerciseRepository : IExerciseRepository
    {

        private readonly GymTrackerContext context;

        public ExerciseRepository(GymTrackerContext context)
        {
            this.context = context;
        }
        public int AddExercise(Exercise exercise)
        {
            var result = context.Exercises.Add(exercise);

            return 0;
        }

        public int AddSessionExercise(SessionExercise sessionExercise)
        {
            var result = context.SessionExercises.Add(sessionExercise);

            return 0;
        }

        public int AddSessionHeader(SessionHeader sessionHeader)
        {
            var result = context.SessionHeaders.Add(sessionHeader);

            return 0;
        }

        public Exercise GetExercise(string Description)
        {
            return context.Exercises.FirstOrDefault(x => x.Description == Description);
        }

        public List<SessionExercise> GetSessionExercises(int headerId)
        {
            return context.SessionExercises.Where(x => x.HeaderId == headerId).ToList();
        }

        public List<SessionExerciseSet> GetSessionExerciseSets(int sessionExerciseId)
        {
            return context.SessionExerciseSets.Where(x => x.SessionExerciseID == sessionExerciseId).ToList();
        }

        public SessionHeader GetSessionHeader(int userId)
        {
            return context.SessionHeaders.FirstOrDefault(x => x.UserID == userId);
        }
    }
}
