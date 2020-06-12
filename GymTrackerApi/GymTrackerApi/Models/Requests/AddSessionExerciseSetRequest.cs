/********************************************************************************************
* AddSessionExerciseRequest.cs
* Created on: 08/06/2020
* Created by: Tom Gorton
*******************************************************************************************/

namespace GymTrackerApi.Models.Requests
{
    /// <summary>
    /// Defines the <see cref="AddSessionExerciseRequest" />.
    /// </summary>
    public class AddSessionExerciseSetRequest
    {
        /// <summary>
        /// Gets or sets the SessionHeaderId.
        /// </summary>
        public int SessionExerciseId { get; set; }

        /// <summary>
        /// Gets or sets the ExerciseName.
        /// </summary>
        public string WeightReps { get; set; }
    }
}
