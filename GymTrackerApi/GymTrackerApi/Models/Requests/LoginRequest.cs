/********************************************************************************************
* LoginRequest.cs
* Created on: 12/05/2020
* Created by: Tom Gorton
*******************************************************************************************/

namespace GymTrackerApi.Models.Requests
{
    /// <summary>
    /// Defines the <see cref="LoginRequest" />.
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Password.
        /// </summary>
        public string Password { get; set; }
    }
}
