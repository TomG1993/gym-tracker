/********************************************************************************************
* GymUsers.cs
* Created on: 08/11/2020
* Created by: Tom Gorton
*******************************************************************************************/

namespace GymTrackerApi.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="UserDetail" />.
    /// </summary>
    public class GymUsers : BaseModel
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the GymId.
        /// </summary>
        public int GymId { get; set; }

        /// <summary>
        /// Gets or sets the UserId.
        /// </summary>
        public int UserId { get; set; }
    }
}
