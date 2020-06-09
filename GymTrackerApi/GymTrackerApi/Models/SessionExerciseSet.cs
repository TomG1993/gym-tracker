/********************************************************************************************
* SessionExerciseSet.cs
* Created on: 31/05/2020
* Created by: Tom Gorton
*******************************************************************************************/

namespace GymTrackerApi.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="SessionExerciseSet" />.
    /// </summary>
    public class SessionExerciseSet : BaseModel
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the SessionExerciseID.
        /// </summary>
        public int SessionExerciseID { get; set; }

        /// <summary>
        /// Gets or sets the Weight.
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Gets or sets the Repetitions.
        /// </summary>
        public int Repetitions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Frozen.
        /// </summary>
        public bool Frozen { get; set; }
    }
}
