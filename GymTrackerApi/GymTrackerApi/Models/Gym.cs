/********************************************************************************************
* Gym.cs
* Created on: 08/11/2020
* Created by: Tom Gorton
*******************************************************************************************/

namespace GymTrackerApi.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="UserDetail" />.
    /// </summary>
    public class Gym : BaseModel
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Location.
        /// </summary>
        public string Location { get; set; }
    }
}
