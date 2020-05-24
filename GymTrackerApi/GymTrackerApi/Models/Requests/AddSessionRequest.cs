/********************************************************************************************
* AddSessionRequest.cs
* Created on: 24/05/2020
* Created by: Tom Gorton
*******************************************************************************************/

namespace GymTrackerApi.Models.Requests
{
    /// <summary>
    /// Defines the <see cref="AddSessionRequest" />.
    /// </summary>
    public class AddSessionRequest
    {
        /// <summary>
        /// Gets or sets the SessionName.
        /// </summary>
        public string SessionName { get; set; }

        /// <summary>
        /// Gets or sets the UserId.
        /// </summary>
        public int UserId { get; set; }
    }
}
