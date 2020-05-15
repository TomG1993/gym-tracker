/********************************************************************************************
* UserDetail.cs
* Created on: 15/05/2020
* Created by: Tom Gorton
*******************************************************************************************/

namespace GymTrackerApi.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="UserDetail" />.
    /// </summary>
    public class UserDetail : BaseModel
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Password.
        /// </summary>
        public string Password { get; set; }
    }
}
