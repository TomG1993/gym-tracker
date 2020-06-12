/********************************************************************************************
* SessionExerciseSetReturnModel.cs
* Created on: 10/06/2020
* Created by: Tom Gorton
*******************************************************************************************/

namespace GymTrackerApi.Models.ReturnModels
{
    /// <summary>
    /// Defines the <see cref="SessionExerciseSetReturnModel" />.
    /// </summary>
    public class SessionExerciseSetReturnModel
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// Gets or sets the ExerciseId.
        /// </summary>
        public int ExerciseId { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string Description { get; set; }
    }
}
