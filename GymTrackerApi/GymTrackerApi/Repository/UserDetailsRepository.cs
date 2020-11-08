/********************************************************************************************
* UserDetailsRepository.cs
* Created on: 15/05/2020
* Created by: Tom Gorton
*******************************************************************************************/

namespace GymTrackerApi.Repository
{
    using GymTrackerApi.Models;
    using GymTrackerApi.Models.Responses;
    using GymTrackerApi.Repository.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="UserDetailsRepository" />.
    /// </summary>
    public class UserDetailsRepository : IUserDetailsRepository
    {
        /// <summary>
        /// Defines the context.
        /// </summary>
        private readonly GymTrackerContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDetailsRepository"/> class.
        /// </summary>
        /// <param name="context">The context<see cref="GymTrackerContext"/>.</param>
        public UserDetailsRepository(GymTrackerContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// The GetUserDetail.
        /// </summary>
        /// <param name="Email">The Email<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{UserDetail}"/>.</returns>
        public async Task<UserDetail> GetUserDetail(string Email)
        {
            var user = await context.UserDetails.FirstOrDefaultAsync(x => x.Email == Email);

            return user;
        }

        /// <summary>
        /// The AddUser.
        /// </summary>
        /// <param name="user">The user<see cref="UserDetail"/>.</param>
        /// <returns>The <see cref="Task{UserDetail}"/>.</returns>
        public async Task<UserDetail> AddUser(UserDetail user)
        {
            var result = context.UserDetails.Add(user);
            await context.SaveChangesAsync();
            return user;
        }

        /// <summary>
        /// The GetHeaders.
        /// </summary>
        /// <param name="userId">The userId<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{List{SessionHeader}}"/>.</returns>
        public async Task<List<SessionHeader>> GetHeaders(int userId)
        {
            var headers = await context.SessionHeaders.Where(x => x.UserID == userId).ToListAsync();

            return headers;
        }

        /// <summary>
        /// The get session exercises repo.
        /// </summary>
        /// <param name="headerId">.</param>
        /// <returns>A list of session exercises based on the header id provided.</returns>
        public async Task<List<SessionExercise>> GetSession(int headerId)
        {
            var exercises = await context.SessionExercises.Where(x => x.HeaderId == headerId).ToListAsync();

            return exercises;
        }

        /// <summary>
        /// Add a new session.
        /// </summary>
        /// <param name="sessionName">.</param>
        /// <param name="userId">The userId<see cref="int"/>.</param>
        /// <returns>.</returns>
        public async Task<int> AddSession(string sessionName, int userId)
        {
            var sessionHeader = new SessionHeader()
            {
                SessionName = sessionName,
                UserID = userId,
                CreatedBy = "TGO",
                CreatedDate = System.DateTime.Now
            };

            await context.SessionHeaders.AddAsync(sessionHeader);
            await context.SaveChangesAsync();

            return sessionHeader.Id;
        }

        /// <summary>
        /// The GetExercise.
        /// </summary>
        /// <param name="exerciseName">The exerciseName<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{Exercise}"/>.</returns>
        public async Task<Exercise> GetExercise(string exerciseName)
        {
            var exercise = await context.Exercises.FirstOrDefaultAsync(x => x.Description.ToLower() == exerciseName.ToLower());

            return exercise;
        }

        /// <summary>
        /// The AddExercise.
        /// </summary>
        /// <param name="ExerciseName">The ExerciseName<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{Exercise}"/>.</returns>
        public async Task<Exercise> AddExercise(string ExerciseName)
        {
            var exercise = new Exercise()
            {
                Description = ExerciseName,
                BodyPartTypeId = 0,
                CreatedBy = "TGO",
                CreatedDate = System.DateTime.Now,
                Frozen = false
            };

            var result = await context.Exercises.AddAsync(exercise);

            await context.SaveChangesAsync();

            return exercise;
        }

        /// <summary>
        /// The AddSessionExercise.
        /// </summary>
        /// <param name="sessionHeaderId">The sessionHeaderId<see cref="int"/>.</param>
        /// <param name="exerciseId">The exerciseId<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{int}"/>.</returns>
        public async Task<int> AddSessionExercise(int sessionHeaderId, int exerciseId)
        {
            var sessionExercise = new SessionExercise()
            {
                HeaderId = sessionHeaderId,
                ExerciseId = exerciseId,
                CreatedBy = "TGO",
                CreatedDate = System.DateTime.Now
            };

            var result = await context.SessionExercises.AddAsync(sessionExercise);

            await context.SaveChangesAsync();

            return sessionExercise.Id;
        }

        /// <summary>
        /// The GetSessionExercises.
        /// </summary>
        /// <param name="sessionHeaderId">The sessionHeaderId<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{List{SessionExercise}}"/>.</returns>
        public async Task<List<SessionExerciseReturnModel>> GetSessionExercises(int sessionHeaderId)
        {
            var modelList = new List<SessionExerciseReturnModel>();

            if (sessionHeaderId > 0)
            {

                var exercises = await context.SessionExercises.Where(x => x.HeaderId == sessionHeaderId).ToListAsync();

                foreach (var exercise in exercises)
                {
                    var model = new SessionExerciseReturnModel()
                    {
                        Id = exercise.Id,
                        HeaderId = exercise.HeaderId,
                        ExerciseId = exercise.ExerciseId,
                        Description = this.GetExerciseDescription(exercise.ExerciseId)
                    };

                    modelList.Add(model);
                }

            }

            return modelList;
        }

        /// <summary>
        /// The get exercise description.
        /// </summary>
        /// <param name="exerciseId">The id.</param>
        /// <returns>The description string.</returns>
        private string GetExerciseDescription(int exerciseId)
        {
            return context.Exercises.FirstOrDefault(x => x.Id == exerciseId).Description;
        }

        /// <summary>
        /// Add session exercise set.
        /// </summary>
        /// <param name="sessionExerciseId">.</param>
        /// <param name="reps">.</param>
        /// <param name="weight">.</param>
        /// <returns>.</returns>
        public async Task<int> AddSessionExerciseSet(int sessionExerciseId, int reps, int weight)
        {
            if (sessionExerciseId < 0)
            {
                return 0;
            }

            var sessionExerciseSet = new SessionExerciseSet()
            {
                SessionExerciseID = sessionExerciseId,
                Repetitions = reps,
                Weight = weight,
                CreatedBy = "TGO",
                CreatedDate = System.DateTime.Now,
                Frozen = false,
            };

            var result = await this.context.SessionExerciseSets.AddAsync(sessionExerciseSet);

            await this.context.SaveChangesAsync();

            return result.Entity.Id;
        }

        /// <summary>
        /// Get all sets for a session exercise.
        /// </summary>
        /// <param name="sessionExerciseId">.</param>
        /// <returns>.</returns>
        public async Task<List<SessionExerciseSet>> GetSessionExerciseSets(int sessionExerciseId)
        {
            return await context.SessionExerciseSets.Where(x => x.SessionExerciseID == sessionExerciseId).ToListAsync();
        }

        /// <summary>
        /// The GetGyms.
        /// </summary>
        /// <returns>The <see cref="Task{List{Gym}}"/>.</returns>
        public async Task<List<Gym>> GetGyms()
        {
            return await context.Gyms.Where(x => x.Id > 0).ToListAsync();
        }

        /// <summary>
        /// The GetGym.
        /// </summary>
        /// <param name="GymId">The GymId<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{Gym}"/>.</returns>
        public async Task<Gym> GetGym(int GymId)
        {
            return await context.Gyms.FirstOrDefaultAsync(x => x.Id == GymId);
        }

        /// <summary>
        /// The GetMembersGym.
        /// </summary>
        /// <param name="UserId">The UserId<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{Gym}"/>.</returns>
        public async Task<Gym> GetMembersGym(int UserId)
        {
            var gym = await context.GymUsers.FirstOrDefaultAsync(y => y.UserId == UserId);
            return await context.Gyms.FirstOrDefaultAsync(x => x.Id == gym.Id);
        }

        /// <summary>
        /// The GetGymMembers.
        /// </summary>
        /// <param name="GymId">The GymId<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{List{UserDetail}}"/>.</returns>
        public async Task<List<UserDetail>> GetGymMembers(int GymId)
        {
            var gymUserIds = await context.GymUsers.Where(x => x.GymId == GymId).Select(y => y.UserId).ToListAsync();

            var users = await context.UserDetails.Where(x => gymUserIds.Contains(x.ID)).ToListAsync();

            return users;
        }
    }
}
