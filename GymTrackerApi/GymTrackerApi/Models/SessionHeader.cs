/********************************************************************************************
* SessionHeader.cs
* Created on: 15/05/2020
* Created by: Tom Gorton
*******************************************************************************************/

namespace GymTrackerApi.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="SessionHeader" />.
    /// </summary>
    public class SessionHeader : BaseModel
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the UserID.
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the SessionNumber.
        /// </summary>
        public int SessionNumber { get; set; }

        /// <summary>
        /// Gets or sets the SessionName.
        /// </summary>
        public string SessionName { get; set; }
    }
}
