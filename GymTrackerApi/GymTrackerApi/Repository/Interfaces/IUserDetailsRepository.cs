/********************************************************************************************
* IUserDetailsRepository.cs
* Created on: 08/06/2020
* Created by: Tom Gorton
*******************************************************************************************/

namespace GymTrackerApi.Repository.Interfaces
{
    using GymTrackerApi.Models;
    using GymTrackerApi.Models.ReturnModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IUserDetailsRepository" />.
    /// </summary>
    public interface IUserDetailsRepository
    {
        /// <summary>
        /// The GetUserDetail.
        /// </summary>
        /// <param name="Email">The Email<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{UserDetail }"/>.</returns>
        public Task<UserDetail> GetUserDetail(string Email);

        /// <summary>
        /// The AddUser.
        /// </summary>
        /// <param name="user">The user<see cref="UserDetail"/>.</param>
        /// <returns>The <see cref="Task{UserDetail}"/>.</returns>
        public Task<UserDetail> AddUser(UserDetail user);

        /// <summary>
        /// The GetHeaders.
        /// </summary>
        /// <param name="userId">The userId<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{List{SessionHeader}}"/>.</returns>
        public Task<List<SessionHeader>> GetHeaders(int userId);

        /// <summary>
        /// The GetSession.
        /// </summary>
        /// <param name="headerId">The headerId<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{List{SessionExercise}}"/>.</returns>
        public Task<List<SessionExercise>> GetSession(int headerId);

        /// <summary>
        /// The AddSession.
        /// </summary>
        /// <param name="sessionName">The sessionName<see cref="string"/>.</param>
        /// <param name="userId">The userId<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{int}"/>.</returns>
        public Task<int> AddSession(string sessionName, int userId);

        /// <summary>
        /// The GetExercise.
        /// </summary>
        /// <param name="exerciseName">The exerciseName<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{Exercise}"/>.</returns>
        public Task<Exercise> GetExercise(string exerciseName);

        /// <summary>
        /// The AddExercise.
        /// </summary>
        /// <param name="ExerciseName">The ExerciseName<see cref="string"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public Task<Exercise> AddExercise(string ExerciseName);

        /// <summary>
        /// The AddSessionExercise.
        /// </summary>
        /// <param name="sessionHeaderId">The sessionHeaderId<see cref="int"/>.</param>
        /// <param name="exerciseId">The exerciseId<see cref="int"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public Task<int> AddSessionExercise(int sessionHeaderId, int exerciseId);

        /// <summary>
        /// The GetSessionExercises.
        /// </summary>
        /// <param name="sessionHeaderId">The sessionHeaderId<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{List{Exercise}}"/>.</returns>
        public Task<List<SessionExerciseReturnModel>> GetSessionExercises(int sessionHeaderId);

        /// <summary>
        /// Adds session exercise sets
        /// </summary>
        /// <param name="sessionExerciseId"></param>
        /// <param name="reps"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public Task<int> AddSessionExerciseSet(int sessionExerciseId, int reps, int weight);

        /// <summary>
        /// Gets session exercise sets
        /// </summary>
        /// <param name="sessionHeaderId"></param>
        /// <returns></returns>
        public Task<List<SessionExerciseSet>> GetSessionExerciseSets(int sessionExerciseId);

    }
}
